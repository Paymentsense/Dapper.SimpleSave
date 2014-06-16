using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PS.Mothership.Core.Common.Config;
using PS.Mothership.Core.Common.Contracts;
using PS.Mothership.Core.Common.Dto.CompaniesHouse;
using PS.Mothership.DAL.Common.Contracts;
using PS.Mothership.DAL.Contracts;
using PS.Mothership.DAL.Data.Comm;
using PS.Mothership.DAL.Implementations;
using PS.Mothership.Service.Config;
using PS.Mothership.ThirdParty.CompaniesHouse.Config;
using PS.Mothership.ThirdParty.CompaniesHouse.Contracts;
using PS.Mothership.ThirdParty.CompaniesHouse.Data;
using PS.Mothership.ThirdParty.CompaniesHouse.Facades;
using PS.Mothership.ThirdParty.CompaniesHouse.Factories;
using PS.Mothership.ThirdParty.CompaniesHouse.Implementations;
using PS.Mothership.ThirdParty.CompaniesHouse.Models;
using PS.Mothership.ThirdParty.Contracts;
using PS.Mothership.ThirdParty.Implementations;
using PS.Mothership.ThirdParty.Mappings;
using ICredentials = PS.Mothership.ThirdParty.CompaniesHouse.Contracts.ICredentials;

namespace IntegrationTests
{
    //TODO when integration tests fixed... move to integration tests and delete project
    [TestFixture]
    public class CompaniesHouseServiceTests
    {
        private ICredentials _credentials;
        private IGatewayConnection _gatewayConnection;
        private ICompaniesHouseGatewayServiceFacade _companiesHouseGatewayServiceFacade;
        private ICompaniesHouseGatewayService _companiesHouseGatewayService;
        private ICompaniesHouseUriService _companiesHouseUriService;
        private ICompaniesHouseUriServiceFacade _companiesHouseUriServiceFacade;
        private ICompaniesHouseConfiguration _companiesHouseConfiguration;
        private ICompaniesHouseQueue _companiesHouseQueue;
        private ITransactionIdManager _transactionIdManager;
        private ICompaniesHouseRepository _companiesHouseRepository;
        private IUriConnection _uriConnection;
        private ICompaniesHouseSerializer _companiesHouseSerializer;
        private HttpClientFactory _httpClientFactory;
        private Mock<IMSLogger> _mockLogger;
        private Mock<IUnitOfWork> _mockIUnitOfWork;
        private Mock<IGenericRepository<SYSTEM_VALUE_MST, MSDbContextType>> _mockIGenericRepository;
        private Mock<IHttpClientFacade> _mockHttpClientFacade;
        private Mock<HttpClientFactory> _mockHttpClientFactory;
        
        [SetUp]
        public void Initialize()
        {
            _mockLogger = new Mock<IMSLogger>();
            _companiesHouseConfiguration = new CompaniesHouseConfiguration(_mockLogger.Object);
        }

        [TearDown]
        public void TearDown()
        {
        _credentials = null;
        _gatewayConnection = null;
        _mockLogger = null;
        _companiesHouseGatewayServiceFacade = null;
        _companiesHouseGatewayService = null;
        _companiesHouseUriService = null;
        _companiesHouseConfiguration = null;
        _companiesHouseQueue = null;
        _transactionIdManager = null;
        _companiesHouseRepository = null;
        _mockIUnitOfWork = null;
        _mockIGenericRepository = null;
        _uriConnection = null;
        _companiesHouseSerializer = null;
        _mockHttpClientFactory = null;
        _httpClientFactory = null;
        _mockHttpClientFacade = null;
        }

        [Test]
        public void CompaniesHouseJsonCompanyTest()
        {
            SetUriConfig(JsonDataReponse);

            var response = _companiesHouseUriServiceFacade.CompanyDetailViaJson("02050399");

            Assert.That(response.primaryTopic.CompanyName, Is.EqualTo("ZENITH PRINT (UK) LIMITED"));
            Assert.That(response.primaryTopic.CompanyNumber, Is.EqualTo("02050399"));
            Assert.That(response.primaryTopic.SICCodes.SicText.Any(x => x.Contains("70100 - Activities of head offices")));
            Assert.That(response.primaryTopic.PreviousNames.Any(x => x.CONDate.Contains("1996-03-22")));
        }

        [Test]
        public void CompaniesHouseXmlCompanyTest()
        {
            SetUriConfig(XmlDataResponse);

            var response = _companiesHouseUriServiceFacade.CompanyDetailViaXml("02050399");

            Assert.That(response.primaryTopic.CompanyName, Is.EqualTo("ZENITH PRINT (UK) LIMITED"));
            Assert.That(response.primaryTopic.CompanyNumber, Is.EqualTo("02050399"));
            Assert.That(response.primaryTopic.SICCodes.SicText.Any(x => x.Contains("70100 - Activities of head offices")));
            Assert.That(response.primaryTopic.PreviousNames.Any(x => x.CONDate.Contains("1996-03-22")));
        }

        [Test]
        public void CompaniesHouseXmlService()
        {
            SetGatewayConfig();
            var companyDetailsRequestDto = new CompanyDetailsRequestDto
            {
                CompanyNumber = "02050399",
                GiveMortTotals = false,
            };
            var response = _companiesHouseGatewayServiceFacade.CompanyDetails(companyDetailsRequestDto);
        }

        private void SetUriConfig(string dataResponse)
        {
            var result = CreateMockHttpResonse(new StringContent(dataResponse));
            //_httpClientFactory = new HttpClientFactory();
            _mockHttpClientFacade = new Mock<IHttpClientFacade>();
            _mockHttpClientFacade.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.Run(() => result.Object));

            _mockHttpClientFactory = new Mock<HttpClientFactory>();
            _mockHttpClientFactory.Setup(x => x.Create()).Returns(_mockHttpClientFacade.Object);

            _companiesHouseSerializer = new CompaniesHouseSerializer(_mockLogger.Object);
            _uriConnection = new UriConnection(_companiesHouseConfiguration, _mockHttpClientFactory.Object
                /*_httpClientFactory*/);
            _companiesHouseUriService = new CompaniesHouseUriService(_uriConnection, _companiesHouseSerializer, _mockLogger.Object);
            _companiesHouseUriServiceFacade = new CompaniesHouseUriServiceFacade(_companiesHouseUriService);
        }

        private static Mock<HttpResponseMessageFacade> CreateMockHttpResonse(HttpContent httpContent = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var result = new Mock<HttpResponseMessageFacade>(null);
            result.Setup(x => x.Content).Returns(httpContent ?? new StringContent(""));
            result.Setup(x => x.StatusCode).Returns(statusCode);
            return result;
        }

        private void SetGatewayConfig()
        {
            AutoMapping.Configure(new IocBuildSettings()
                .WithAutoMapperProfile(new CompaniesHouseDtoMappingProfile()));
            _credentials = new Credentials("22075804094818262698720017563970", "6znnj4vnziaqcrgjg9ufbo0cqs0hl0b9");
            _mockIUnitOfWork = new Mock<IUnitOfWork>();
            _mockIGenericRepository = new Mock<IGenericRepository<SYSTEM_VALUE_MST, MSDbContextType>>();
            _mockIGenericRepository.Setup(x => x.Get(
                It.IsAny<Expression<Func<SYSTEM_VALUE_MST, bool>>>(),
                It.IsAny<Func<IQueryable<SYSTEM_VALUE_MST>, IOrderedEnumerable<SYSTEM_VALUE_MST>>>(),
                It.IsAny<IEnumerable<Expression<Func<SYSTEM_VALUE_MST, object>>>>())).Returns(new List<SYSTEM_VALUE_MST>
                {
                    new SYSTEM_VALUE_MST
                    {
                        SystemValueKey = "CompaniesHouseTransactionId",
                        Value = "1"
                    }
                });
            _companiesHouseQueue = new CompaniesHouseQueue();
            _companiesHouseRepository = new CompaniesHouseRepository(_mockIUnitOfWork.Object, _mockIGenericRepository.Object, _mockLogger.Object);
            _transactionIdManager = new TransactionIdManager(_companiesHouseRepository);

            //var result = CreateMockHttpResonse(new StringContent(dataResponse));
            _httpClientFactory = new HttpClientFactory();
            //_mockHttpClientFacade = new Mock<IHttpClientFacade>();
            //_mockHttpClientFacade.Setup(x => x.GetAsync(It.IsAny<string>()))
            //    .Returns(Task.Run(() => result.Object));

            _gatewayConnection = new GatewayConnection(_companiesHouseConfiguration, _companiesHouseQueue, _httpClientFactory);
            _companiesHouseGatewayService = new CompaniesHouseGatewayService(_gatewayConnection, _credentials, _mockLogger.Object, _transactionIdManager);
            _companiesHouseGatewayServiceFacade = new CompaniesHouseGatewayServiceFacade(_companiesHouseGatewayService);
        }

        #region Json and Xml Response Data
        private const string JsonDataReponse = @"{""primaryTopic"" : {
                                                  ""CompanyName"" : ""ZENITH PRINT (UK) LIMITED"",
                                                  ""CompanyNumber"" : ""02050399"",
                                                  ""RegAddress"" : {
                                                     ""AddressLine1"" : ""ZENITH HOUSE"",
                                                     ""AddressLine2"" : ""MOY ROAD INDUSTRIAL ESTATE"",
                                                     ""PostTown"" : ""TAFFS WELL"",
                                                     ""County"" : ""CARDIFF"",
                                                     ""Postcode"" : ""CF15 7QR""
                                                  },
                                                  ""CompanyCategory"" : ""Private Limited Company"",
                                                  ""CompanyStatus"" : ""Active"",
                                                  ""CountryOfOrigin"" : ""United Kingdom"",
                                                  ""IncorporationDate"" : ""28/08/1986"",
                                                  ""PreviousNames"" : [
                                                     {
                                                        ""CONDate"" : ""22/03/1996"",
                                                        ""CompanyName"" : ""ZENITH TREFOREST PRESS LIMITED""
                                                     }
                                                  ],
                                                  ""Accounts"" : {
                                                     ""AccountRefDay"" : ""31"",
                                                     ""AccountRefMonth"" : ""03"",
                                                     ""NextDueDate"" : ""31/12/2014"",
                                                     ""LastMadeUpDate"" : ""31/03/2013"",
                                                     ""AccountCategory"" : ""TOTAL EXEMPTION SMALL""
                                                  },
                                                  ""Returns"" : {
                                                     ""NextDueDate"" : ""28/01/2015"",
                                                     ""LastMadeUpDate"" : ""31/12/2013""
                                                  },
                                                  ""Mortgages"" : {
                                                     ""NumMortCharges"" : ""6"",
                                                     ""NumMortOutstanding"" : ""2"",
                                                     ""NumMortPartSatisfied"" : ""0"",
                                                     ""NumMortSatisfied"" : ""4""
                                                  },
                                                  ""SICCodes"" : {
                                                     ""SicText"" : [
                                                        ""70100 - Activities of head offices""
                                                     ]
                                                  }
                                               }
                                            }";

        private const string XmlDataResponse = @" <Result xmlns=""http://www.companieshouse.gov.uk/terms/xxx"">
                                                    <primaryTopic href=""http://business.data.gov.uk/id/company/02050399"">
                                                        <CompanyName>ZENITH PRINT (UK) LIMITED</CompanyName>
                                                        <CompanyNumber>02050399</CompanyNumber>
                                                        <RegAddress href=""http://data.companieshouse.gov.uk/doc/company/02050399#RegAddress"">
                                                            <AddressLine1>ZENITH HOUSE</AddressLine1>
                                                            <AddressLine2>MOY ROAD INDUSTRIAL ESTATE</AddressLine2>
                                                            <PostTown>TAFFS WELL</PostTown>
                                                            <County>CARDIFF</County>
                                                            <Postcode>CF15 7QR</Postcode>
                                                        </RegAddress>
                                                        <CompanyCategory>Private Limited Company</CompanyCategory>
                                                        <CompanyStatus>Active</CompanyStatus>
                                                        <CountryOfOrigin>United Kingdom</CountryOfOrigin>
                                                        <IncorporationDate>1986-08-28</IncorporationDate>
                                                        <PreviousNames href=""http://data.companieshouse.gov.uk/doc/company/02050399#PreviousNames"">
                                                            <CONDate>1996-03-22</CONDate>
                                                            <CompanyName>ZENITH TREFOREST PRESS LIMITED</CompanyName>
                                                        </PreviousNames>
                                                        <Accounts href=""http://data.companieshouse.gov.uk/doc/company/02050399#Accounts"">
                                                            <AccountRefDay>31</AccountRefDay>
                                                            <AccountRefMonth>03</AccountRefMonth>
                                                            <NextDueDate>2014-12-31</NextDueDate>
                                                            <LastMadeUpDate>2013-03-31</LastMadeUpDate>
                                                            <AccountCategory>TOTAL EXEMPTION SMALL</AccountCategory>
                                                        </Accounts>
                                                        <Returns href=""http://data.companieshouse.gov.uk/doc/company/02050399#Returns"">
                                                            <NextDueDate>2015-01-28</NextDueDate>
                                                            <LastMadeUpDate>2013-12-31</LastMadeUpDate>
                                                        </Returns>
                                                        <Mortgages href=""http://data.companieshouse.gov.uk/doc/company/02050399#Mortgages"">
                                                            <NumMortCharges>6</NumMortCharges>
                                                            <NumMortOutstanding>2</NumMortOutstanding>
                                                            <NumMortPartSatisfied>0</NumMortPartSatisfied>
                                                            <NumMortSatisfied>4</NumMortSatisfied>
                                                        </Mortgages>
                                                        <SICCodes href=""http://data.companieshouse.gov.uk/doc/company/02050399#SICCodes"">
                                                            <SicText>70100 - Activities of head offices</SicText>
                                                        </SICCodes>
                                                    </primaryTopic>
                                                  </Result>";
        #endregion
    }
}
