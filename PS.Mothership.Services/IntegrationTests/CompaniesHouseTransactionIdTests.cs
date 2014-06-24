using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Moq;
using NUnit.Framework;
using PS.Mothership.Core.Common.Config;
using PS.Mothership.Core.Common.Dto.CompaniesHouse;
using PS.Mothership.Core.Common.SessionHandling;
using PS.Mothership.DAL.Common.Contracts;
using PS.Mothership.DAL.Contracts;
using PS.Mothership.DAL.Data.Comm;
using PS.Mothership.DAL.Implementations;
using PS.Mothership.Service.Config;
using PS.Mothership.ThirdParty.CompaniesHouse.Contracts;
using PS.Mothership.ThirdParty.CompaniesHouse.Data;
using PS.Mothership.ThirdParty.CompaniesHouse.Implementations;
using PS.Mothership.ThirdParty.CompaniesHouse.Models;
using PS.Mothership.ThirdParty.Contracts;
using PS.Mothership.ThirdParty.Implementations;
using PS.Mothership.ThirdParty.Mappings;

namespace IntegrationTests
{
    //TODO when integration tests fixed... move to integration tests and delete project
    [TestFixture]
    public class CompaniesHouseTransactionIdTests
    {
        private Mock<ICompaniesHouseCredentials> _mockCredentials;
        private Mock<ICompaniesHouseGatewayConnection> _mockGatewayConnection;
        private Mock<ICompaniesHouseGatewayResponse> _mockGatewayResponse;
        private GovTalkMessage _govTalkMessage;

        private ICompaniesHouseGatewayServiceFacade _companiesHouseGatewayServiceFacade;
        private ICompaniesHouseGatewayService _companiesHouseGatewayService;
        private ICompaniesHouseTransactionIdManager _transactionIdManager;
        private ICompaniesHouseRepository _companiesHouseRepository;
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<SYSTEM_VALUE_MST, MSDbContextType> _genericRepository;
        private IWindsorContainer _windsorContainer;
        private IDatabaseFactory _databaseFactory;

        [SetUp]
        public void Initialize()
        {
        }

        [TearDown]
        public void TearDown()
        {
            _mockCredentials = null;
            _mockGatewayConnection = null;
            _companiesHouseGatewayServiceFacade = null;
            _companiesHouseGatewayService = null;
            _transactionIdManager = null;
            _companiesHouseRepository = null;
            _unitOfWork = null;
            _genericRepository = null;
            _mockGatewayResponse = null;
            _govTalkMessage = null;
            _windsorContainer = null;
        }

        [Test]
        public void TestDbTransactionIdIncrementation()
        {
            using (var transactionScope = new TransactionScope())
            {
                SetConfig();
                var transactionIdBefore = _transactionIdManager.GetTransactionId();
                _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto());
                var transactionIdAfter = _transactionIdManager.GetTransactionId();

                Assert.That(transactionIdAfter, Is.EqualTo(transactionIdBefore + 1));
                //roll back
            }
        }

        [Test]
        public void TestMultipleTransactionIdIncrementation()
        {
            using (var transactionScope = new TransactionScope())
            {
                SetConfig();
                var transactionIdBefore = _transactionIdManager.GetTransactionId();

                var tasks = new List<Task>
                {
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                    new Task(() => _companiesHouseGatewayServiceFacade.NumberSearch(new NumberSearchRequestDto())),
                };

                tasks.ForEach(x => x.Start());

                Task.WaitAll(tasks.ToArray());
                var transactionIdAfter = _transactionIdManager.GetTransactionId();
                Assert.That(transactionIdAfter, Is.EqualTo(transactionIdBefore + 11));
                //roll back
            }
        }

        private void SetConfig()
        {
            AutoMapping.Configure(new IocBuildSettings()
                .WithAutoMapperProfile(new CompaniesHouseDtoMappingProfile()));

            _mockCredentials = new Mock<ICompaniesHouseCredentials>();
            _mockCredentials.Setup(x => x.UserId).Returns("22075804094818262698720017563970");
            _mockCredentials.Setup(x => x.Password).Returns("6znnj4vnziaqcrgjg9ufbo0cqs0hl0b9");
            _mockCredentials.Setup(x => x.IsValid).Returns(true);

            _govTalkMessage = GetGovTalkMessage();
            _mockGatewayResponse = new Mock<ICompaniesHouseGatewayResponse>();
            _mockGatewayResponse.Setup(x => x.Response).Returns(_govTalkMessage);
            _mockGatewayConnection = new Mock<ICompaniesHouseGatewayConnection>();
            _mockGatewayConnection.Setup(x => x.RequestDataFromGateway(It.IsAny<GatewayRequest<NumberSearchRequest>>()))
                .Returns(_mockGatewayResponse.Object);
            
            _windsorContainer = new WindsorContainer();

            _windsorContainer.Register(Component.For<ISessionManager>()
                .ImplementedBy<SessionManager>().LifeStyle.HybridPerWcfOperationTransient());

            _databaseFactory = new DatabaseFactory(new MetadataWorkspaceStore());
            
            _unitOfWork = new UnitOfWork(_databaseFactory, _windsorContainer);
            _genericRepository = new GenericRepository<SYSTEM_VALUE_MST, MSDbContextType>(_windsorContainer, _databaseFactory);
            _companiesHouseRepository = new CompaniesHouseRepository(_unitOfWork, _genericRepository);
            _transactionIdManager = new CompaniesHouseTransactionIdManager(_companiesHouseRepository);

            _companiesHouseGatewayService = new CompaniesHouseGatewayService(_mockGatewayConnection.Object, _mockCredentials.Object, 
                _transactionIdManager);
            _companiesHouseGatewayServiceFacade = new CompaniesHouseGatewayServiceFacade(_companiesHouseGatewayService);
        }

        private static GovTalkMessage GetGovTalkMessage()
        {
            var xml = new XmlDocument();
            xml.LoadXml("<NumberSearch><SearchRows>50</SearchRows></NumberSearch>");
            return new GovTalkMessage
            {
                Header = new GovTalkMessageHeader
                {
                    MessageDetails = new GovTalkMessageHeaderMessageDetails
                    {
                        Class = "NumberSearchRequest",
                        Qualifier = GovTalkMessageHeaderMessageDetailsQualifier.request,
                        TransactionID = "123123",
                    },
                    SenderDetails = new GovTalkMessageHeaderSenderDetails
                    {
                        IDAuthentication = new IDAuthentication
                        {
                            SenderID = "test, test, test",
                            Authentication = new List<IDAuthenticationAuthentication>
                            {
                                new IDAuthenticationAuthentication
                                {
                                    Method = IDAuthenticationAuthenticationMethod.CHMD5,
                                    Value = "Test, Test"
                                }
                            }
                        }
                    },
                },
                GovTalkDetails = new GovTalkMessageGovTalkDetails(),
                Body = new GovTalkMessageBody
                {
                    Any = new List<XmlElement>
                    {
                        xml.DocumentElement
                    }
                },
            };
        }
    }
}
