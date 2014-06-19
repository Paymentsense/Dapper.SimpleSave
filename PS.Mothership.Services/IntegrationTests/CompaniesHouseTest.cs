﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using Castle.MicroKernel;
using Castle.Windsor;
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
using PS.Mothership.ThirdParty.Config;
using PS.Mothership.ThirdParty.Contracts;
using PS.Mothership.ThirdParty.Implementations;
using PS.Mothership.ThirdParty.Mappings;
using Component = Castle.MicroKernel.Registration.Component;
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
        private ICompaniesHouseUriServiceFacade _companiesHouseUriServiceFacade;
        private ICompaniesHouseConfiguration _companiesHouseConfiguration;
        private ITransactionIdManager _transactionIdManager;
        private ICompaniesHouseRepository _companiesHouseRepository;
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
        _companiesHouseConfiguration = null;
        _transactionIdManager = null;
        _companiesHouseRepository = null;
        _mockIUnitOfWork = null;
        _mockIGenericRepository = null;
        _httpClientFactory = null;
        }

        [Test]
        public void CompaniesHouseJsonCompanyTest()
        {
            //Testing the IoC Configuration for Xml and Json works
            var thirdParty = ThirdPartyIocConfig.New();
            var container = thirdParty.Configure(null, new WindsorContainer());

            SetUriConfig(JsonDataReponse, container);

            container.Register(Component.For<IMSLogger>().Instance(new Mock<IMSLogger>().Object));
            _companiesHouseUriServiceFacade = container.Resolve<ICompaniesHouseUriServiceFacade>();

            var response = _companiesHouseUriServiceFacade.CompanyDetailViaJson("02050399");

            Assert.That(response.primaryTopic.CompanyName, Is.EqualTo("ZENITH PRINT (UK) LIMITED"));
            Assert.That(response.primaryTopic.CompanyNumber, Is.EqualTo("02050399"));
            Assert.That(response.primaryTopic.SICCodes.SicText.Any(x => x.Contains("70100 - Activities of head offices")));
            Assert.That(response.primaryTopic.PreviousNames.Any(x => x.CONDate.Contains("1996-03-22")));
        }

        [Test]
        public void CompaniesHouseXmlCompanyTest()
        {
            //Testing the IoC Configuration for Xml and Json works
            var thirdParty = ThirdPartyIocConfig.New();
            var container = thirdParty.Configure(null, new WindsorContainer());

            SetUriConfig(JsonDataReponse, container);

            container.Register(Component.For<IMSLogger>().Instance(new Mock<IMSLogger>().Object));
            _companiesHouseUriServiceFacade = container.Resolve<ICompaniesHouseUriServiceFacade>();

            var response = _companiesHouseUriServiceFacade.CompanyDetailViaXml("02050399");

            Assert.That(response.primaryTopic.CompanyName, Is.EqualTo("ZENITH PRINT (UK) LIMITED"));
            Assert.That(response.primaryTopic.CompanyNumber, Is.EqualTo("02050399"));
            Assert.That(response.primaryTopic.SICCodes.SicText.Any(x => x.Contains("70100 - Activities of head offices")));
            Assert.That(response.primaryTopic.PreviousNames.Any(x => x.CONDate.Contains("1996-03-22")));
        }

        [Test]
        public void CompaniesHouseXmlService()
        {
            SetGatewayConfig(CompanyDetailsResponseXml);
            var companyDetailsRequestDto = new CompanyDetailsRequestDto
            {
                CompanyNumber = "02050399",
                //CompanyNumber = "02050205",
                GiveMortTotals = false,
            };
            var response = _companiesHouseGatewayServiceFacade.CompanyDetails(companyDetailsRequestDto);
        }

        private static Mock<HttpResponseMessageFacade> CreateMockHttpResonse(HttpContent httpContent = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var result = new Mock<HttpResponseMessageFacade>(null);
            result.Setup(x => x.Content).Returns(httpContent ?? new StringContent(""));
            result.Setup(x => x.StatusCode).Returns(statusCode);
            return result;
        }

        private void SetUriConfig(string dataResponse, IWindsorContainer container)
        {
            var result = CreateMockHttpResonse(new StringContent(dataResponse));
            //_httpClientFactory = new HttpClientFactory();
            _mockHttpClientFacade = new Mock<IHttpClientFacade>();
            _mockHttpClientFacade.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(() => result.Object);

            _mockHttpClientFactory = new Mock<HttpClientFactory>();
            _mockHttpClientFactory.Setup(x => x.Create()).Returns(_mockHttpClientFacade.Object);

            container.Register(Component.For<HttpClientFactory>()
                .Instance(_mockHttpClientFactory.Object)
                .LifeStyle.Singleton);

            container.Register(Component.For<IHttpClientFacade>()
                .Instance(_mockHttpClientFacade.Object)
                .LifeStyle.Transient);

            container.Kernel.AddHandlerSelector(new HttpClientFactoryHandlerSelector());
            container.Kernel.AddHandlerSelector(new HttpClientFacadeHandlerSelector());
        }

        private void SetGatewayConfig(string dataResponse)
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
                        Value = "1050"
                    }
                });
            _companiesHouseRepository = new CompaniesHouseRepository(_mockIUnitOfWork.Object, _mockIGenericRepository.Object, _mockLogger.Object);
            _transactionIdManager = new TransactionIdManager(_companiesHouseRepository);

            //var result = CreateMockHttpResonse(new StringContent(dataResponse));

            //_mockHttpClientFacade = new Mock<IHttpClientFacade>();
            //_mockHttpClientFacade.Setup(x => x.Post(It.IsAny<string>(), It.IsAny<HttpContent>())).Returns(result.Object);

            //_mockHttpClientFactory = new Mock<HttpClientFactory>();
            //_mockHttpClientFactory.Setup(x => x.Create()).Returns(_mockHttpClientFacade.Object);

            _httpClientFactory = new HttpClientFactory();

            _gatewayConnection = new GatewayConnection(_companiesHouseConfiguration, 
            //_mockHttpClientFactory.Object);
            _httpClientFactory);
            _companiesHouseGatewayService = new CompaniesHouseGatewayService(_gatewayConnection, _credentials, _mockLogger.Object, _transactionIdManager);
            _companiesHouseGatewayServiceFacade = new CompaniesHouseGatewayServiceFacade(_companiesHouseGatewayService);
        }

        [Test]
        public void test()
        {
            const string response = "<CompanyDetails xmlns=\"http://xmlgw.companieshouse.gov.uk/v1-0/schema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:schemaLocation=\"http://xmlgw.companieshouse.gov.uk/v1-0/schema http://xmlgw.companieshouse.gov.uk/v1-0/schema/CompanyDetails-v2-1.xsd\">\r\n    <CompanyName>ZENITH PRINT (UK) LIMITED</CompanyName>\r\n    <CompanyNumber>02050399</CompanyNumber>\r\n    <RegAddress>\r\n      <AddressLine>ZENITH HOUSE</AddressLine>\r\n      <AddressLine>MOY ROAD INDUSTRIAL ESTATE</AddressLine>\r\n      <AddressLine>TAFFS WELL</AddressLine>\r\n      <AddressLine>CARDIFF</AddressLine>\r\n      <AddressLine>CF15 7QR</AddressLine>\r\n    </RegAddress>\r\n    <CompanyCategory>Private Limited Company</CompanyCategory>\r\n    <CompanyStatus>Active</CompanyStatus>\r\n    <CountryOfOrigin>United Kingdom</CountryOfOrigin>\r\n    <RegDateType>0</RegDateType>\r\n    <IncorporationDate>1986-08-28</IncorporationDate>\r\n    <PreviousNames>\r\n      <CONDate>1996-03-22</CONDate>\r\n      <CompanyName>ZENITH TREFOREST PRESS LIMITED</CompanyName>\r\n    </PreviousNames>\r\n    <Accounts>\r\n      <AccountRefDate>31-03</AccountRefDate>\r\n      <NextDueDate>2014-12-31</NextDueDate>\r\n      <Overdue>NO</Overdue>\r\n      <LastMadeUpDate>2013-03-31</LastMadeUpDate>\r\n      <AccountCategory>TOTAL EXEMPTION SMALL</AccountCategory>\r\n      <DocumentAvailable>1</DocumentAvailable>\r\n    </Accounts>\r\n    <Returns>\r\n      <NextDueDate>2015-01-28</NextDueDate>\r\n      <Overdue>NO</Overdue>\r\n      <LastMadeUpDate>2013-12-31</LastMadeUpDate>\r\n      <DocumentAvailable>1</DocumentAvailable>\r\n    </Returns>\r\n    <SICCodes>\r\n      <SicText>70100 - Activities of head offices</SicText>\r\n    </SICCodes>\r\n    <LastFullMemDate>2013-12-31</LastFullMemDate>\r\n    <HasUKestablishment>0</HasUKestablishment>\r\n    <HasAppointments>1</HasAppointments>\r\n    <InLiquidation>0</InLiquidation>\r\n  </CompanyDetails>";
            var xelemn = XElement.Parse(response);
            xelemn.RemoveAttributes();
            foreach (var child in xelemn.DescendantsAndSelf().OfType<XElement>())
            {
                child.Name = child.Name.LocalName;
            }
            var t = CompanyDetails.Deserialize(xelemn.ToString());
            var regaddress = t.RegAddress;
            foreach (var r in t.SICCodes.SicText)
            {
                var s = r;
            }
            foreach (var r in regaddress.AddressLine)
            {
                var s = r;
            }
            regaddress.AddressLine = new List<string>();
        }

        #region Json and Xml Response Data
        private const string JsonDataReponse = @"{""primaryTopic"" : { ""CompanyName"" : ""ZENITH PINT (UK) LIMITED"",""CompanyNumber"" : ""02050399"",""RegAddress"" : {   ""AddressLine1"" : ""ZENITH HOUSE"",   ""AddressLine2"" : ""MOY ROAD INDUSTRIAL ESTATE"",   ""PostTown"" : ""TAFFS WELL"",   ""County"" : ""CARDIFF"",   ""Postcode"" : ""CF15 7QR""},""CompanyCategory"" : ""Private Limited Company"",""CompanyStatus"" : ""Active"",""CountryOfOrigin"" : ""United Kingdom"",""IncorporationDate"" : ""28/08/1986"",""PreviousNames"" : [   {      ""CONDate"" : ""22/03/1996"",      ""CompanyName"" : ""ZENITH TREFOREST PRESS LIMITED""   }],""Accounts"" : {   ""AccountRefDay"" : ""31"",   ""AccountRefMonth"" : ""03"",   ""NextDueDate"" : ""31/12/2014"",   ""LastMadeUpDate"" : ""31/03/2013"",   ""AccountCategory"" : ""TOTAL EXEMPTION SMALL""},""Returns"" : {   ""NextDueDate"" : ""28/01/2015"",   ""LastMadeUpDate"" : ""31/12/2013""},""Mortgages"" : {   ""NumMortCharges"" : ""6"",   ""NumMortOutstanding"" : ""2"",   ""NumMortPartSatisfied"" : ""0"",   ""NumMortSatisfied"" : ""4""},""SICCodes"" : {   ""SicText"" : [      ""70100 - Activities of head offices""   ]}   }}";

        private const string XmlDataResponse = @" <Result xmlns=""http://www.companieshouse.gov.uk/terms/xxx"">  <primaryTopic href=""http://business.data.gov.uk/id/company/02050399"">      <CompanyName>ZENITH PRINT (UK) LIMITED</CompanyName>      <CompanyNumber>02050399</CompanyNumber>      <RegAddress href=""http://data.companieshouse.gov.uk/doc/company/02050399#RegAddress"">          <AddressLine1>ZENITH HOUSE</AddressLine1>          <AddressLine2>MOY ROAD INDUSTRIAL ESTATE</AddressLine2>          <PostTown>TAFFS WELL</PostTown>          <County>CARDIFF</County>          <Postcode>CF15 7QR</Postcode>      </RegAddress>      <CompanyCategory>Private Limited Company</CompanyCategory>      <CompanyStatus>Active</CompanyStatus>      <CountryOfOrigin>United Kingdom</CountryOfOrigin>      <IncorporationDate>1986-08-28</IncorporationDate>      <PreviousNames href=""http://data.companieshouse.gov.uk/doc/company/02050399#PreviousNames"">          <CONDate>1996-03-22</CONDate>          <CompanyName>ZENITH TREFOREST PRESS LIMITED</CompanyName>      </PreviousNames>      <Accounts href=""http://data.companieshouse.gov.uk/doc/company/02050399#Accounts"">          <AccountRefDay>31</AccountRefDay>          <AccountRefMonth>03</AccountRefMonth>          <NextDueDate>2014-12-31</NextDueDate>          <LastMadeUpDate>2013-03-31</LastMadeUpDate>          <AccountCategory>TOTAL EXEMPTION SMALL</AccountCategory>      </Accounts>      <Returns href=""http://data.companieshouse.gov.uk/doc/company/02050399#Returns"">          <NextDueDate>2015-01-28</NextDueDate>          <LastMadeUpDate>2013-12-31</LastMadeUpDate>      </Returns>      <Mortgages href=""http://data.companieshouse.gov.uk/doc/company/02050399#Mortgages"">          <NumMortCharges>6</NumMortCharges>          <NumMortOutstanding>2</NumMortOutstanding>          <NumMortPartSatisfied>0</NumMortPartSatisfied>          <NumMortSatisfied>4</NumMortSatisfied>      </Mortgages>      <SICCodes href=""http://data.companieshouse.gov.uk/doc/company/02050399#SICCodes"">          <SicText>70100 - Activities of head offices</SicText>      </SICCodes>  </primaryTopic></Result>";

        private const string CompanyDetailsResponseXml = @"<GovTalkMessage xsi:schemaLocation=""http://www.govtalk.gov.uk/schemas/govtalk/govtalkheader http://xmlgw.companieshouse.gov.uk/v1-0/schema/Egov_ch.xsd"" xmlns=""http://www.govtalk.gov.uk/CM/envelope"" xmlns:dsig=""http://www.w3.org/2000/09/xmldsig#"" xmlns:gt=""http://www.govtalk.gov.uk/schemas/govtalk/core"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">  <EnvelopeVersion>1.0</EnvelopeVersion>  <Header>    <MessageDetails>      <Class>CompanyDetails</Class>      <Qualifier>response</Qualifier>      <TransactionID>1035</TransactionID>      <GatewayTimestamp>2014-06-18T15:06:18-00:00</GatewayTimestamp>    </MessageDetails>    <SenderDetails>      <IDAuthentication>        <SenderID>22075804094818262698720017563970</SenderID>        <Authentication>          <Method>CHMD5</Method>          <Value></Value>        </Authentication>      </IDAuthentication>    </SenderDetails>  </Header>  <GovTalkDetails>    <Keys />  </GovTalkDetails>  <Body>    <CompanyDetails xmlns=""http://xmlgw.companieshouse.gov.uk/v1-0/schema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://xmlgw.companieshouse.gov.uk/v1-0/schema http://xmlgw.companieshouse.gov.uk/v1-0/schema/CompanyDetails-v2-1.xsd"">      <CompanyName>ZENITH PRINT (UK) LIMITED</CompanyName>      <CompanyNumber>02050399</CompanyNumber>      <RegAddress>        <AddressLine>ZENITH HOUSE</AddressLine>        <AddressLine>MOY ROAD INDUSTRIAL ESTATE</AddressLine>        <AddressLine>TAFFS WELL</AddressLine>        <AddressLine>CARDIFF</AddressLine>        <AddressLine>CF15 7QR</AddressLine>      </RegAddress>      <CompanyCategory>Private Limited Company</CompanyCategory>      <CompanyStatus>Active</CompanyStatus>      <CountryOfOrigin>United Kingdom</CountryOfOrigin>      <RegDateType>0</RegDateType>      <IncorporationDate>1986-08-28</IncorporationDate>      <PreviousNames>        <CONDate>1996-03-22</CONDate>        <CompanyName>ZENITH TREFOREST PRESS LIMITED</CompanyName>      </PreviousNames>      <Accounts>        <AccountRefDate>31-03</AccountRefDate>        <NextDueDate>2014-12-31</NextDueDate>        <Overdue>NO</Overdue>        <LastMadeUpDate>2013-03-31</LastMadeUpDate>        <AccountCategory>TOTAL EXEMPTION SMALL</AccountCategory>        <DocumentAvailable>1</DocumentAvailable>      </Accounts>      <Returns>        <NextDueDate>2015-01-28</NextDueDate>        <Overdue>NO</Overdue>        <LastMadeUpDate>2013-12-31</LastMadeUpDate>        <DocumentAvailable>1</DocumentAvailable>      </Returns>      <SICCodes>        <SicText>70100 - Activities of head offices</SicText>      </SICCodes>      <LastFullMemDate>2013-12-31</LastFullMemDate>      <HasUKestablishment>0</HasUKestablishment>      <HasAppointments>1</HasAppointments>      <InLiquidation>0</InLiquidation>    </CompanyDetails>  </Body></GovTalkMessage>";
        
        #endregion
    }

    public class HttpClientFactoryHandlerSelector : IHandlerSelector
    {
        public static bool UseMockRegistrator { private get; set; }
        public bool HasOpinionAbout(string key, Type service)
        {
            return service == typeof(HttpClientFactory);
        }
        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            return handlers.First(x => UseMockRegistrator ? x.ComponentModel.Implementation == typeof(Mock<HttpClientFactory>) :
                                       x.ComponentModel.Implementation == typeof(HttpClientFactory));
        }
    }

    public class HttpClientFacadeHandlerSelector : IHandlerSelector
    {
        public static bool UseMockRegistrator { private get; set; }
        public bool HasOpinionAbout(string key, Type service)
        {
            return service == typeof(HttpClientFactory);
        }
        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            return handlers.First(x => UseMockRegistrator ? x.ComponentModel.Implementation == typeof(Mock<HttpClientFactory>) :
                                       x.ComponentModel.Implementation == typeof(HttpClientFactory));
        }
    }  
}
