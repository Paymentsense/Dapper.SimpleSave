namespace PS.Mothership.Core.Common.Constants
{
    public class ConfigurationConstants
    {
        public const string IsInProduction = "IsInProduction";

        //common postcodeanywhere constants
        public const string PostCodeAnywhereAccountCode = "PostCodeAnywhereAccountCode";
        public const string PostCodeAnywhereLicenseKey = "PostCodeAnywhereLicenseKey";
        public const string PostCodeAnywhereFindUrl = "PostCodeAnywhereFindUrl";
        public const string PostCodeAnywhereRetrieveUrl = "PostCodeAnywhereRetrieveUrl";
        public const string PostCodeAnywhereDataType = "PostCodeAnywhereDataType";
        public const string ForceDisplayExceptionDetailsKey = "ForceDisplayExceptionDetails";

        // Standard Password 
        public const string StandardPassword = "Payment1";
        public const string PostCodeAnywhereBindingName = "PostcodeAnywhere_Soap";

        //Common Experian Constants
        public const string ExperianRequestCertFileName = "ExperianRequestCertFileName";
        public const string ExperianRequestCertPassWord = "ExperianRequestCertPassWord";
        public const string ExperianRequestWaspTokenUrl = "ExperianRequestWaspTokenUrl";
        public const string ExperianEIHEndpointRequestUrl = "ExperianEIHEndpointRequestUrl";
        public const string ExperianRequestOutPutTemplate = "ExperianRequestOutPutTemplate";
        public const string ExperianInputTemplate = "ExperianInputTemplate";

        //Send Message Constants
        public const string SendMessageMaxErrorDelay = "SendMessageMaxErrorDelay";
        public const string SendMessageMaxAttempts = "SendMessageMaxAttempts";
        
        
        //Common Sms Constants 
        public const string SendSmsUserName = "SendSmsUserName";
        public const string SendSmsPassword = "SendSmsPassword";
        public const string SendSmsAccountReference = "SendSmsAccountReference";
        public const string SendSmsMaxMessageLength = "SendSmsMaxMessageLength";
        public const string SendSMSType = "SendSMSType";
        public const string SendSMSMessageSent = "SendSMSMessageSent";
        public const string SendSMSMessageDelivered = "SendSMSMessageDelivered";
        public const string SendSMSMessageBounced = "SendSMSMessageBounced";
        public const string SendSmsMessageDefault = "SendSMSMessageDefault";
        public const string SendSmsTestNumber = "SendSMSTestNumber";
        public const string SendSmsTestAccountReference = "SendSmsTestAccountReference";
        public const string SendSMSTestNumberGuid = "SendSMSTestNumberGuid";
        public const string SendSmsMessageDefaultNumber = "SendSMSMessageDefaultNumber";
        public const string SendSmsIsInProduction = "SendSmsIsInProduction";

        // Common SMTP Constants
        public const string SmtpServer = "SMTPServer";
        public const string SmtpEnableSsl = "SMTPEnableSsl";
        public const string SmtpPortNumber = "SMTPPortNumber";
        public const string SmtpNetworkName = "NetworkName";
        public const string SmtpNetworkPassword = "NetworkPassword";

        // Common IMAP Constants
        public const string ImapServer = "IMAPServer";
        public const string ImapPortNumber = "IMAPPortNumber";
        public const string ImapUsername = "IMAPUsername";
        public const string ImapPassword = "IMAPPassword";
        public const string ImapIdleConnectionTime = "IDLEConnectionTime";
        public const string PollingTime = "PollingTime";
        public const string ImapListenerEnabled = "ImapListenerEnabled";

        //Onboarding Constants
        public const string OnboardingUserName = "OnboardingUserName";
        public const string OnboardingPassword = "OnboardingPassword";
        public const string OnBoardingUrl = "OnBoardingUrl";
        public const string CreditCheckUrl = "CreditCheckUrl";

        // Common EchoSign Constants
        public const string EchoSignUserEmail = "EchoSignUserEmail";
        public const string EchoSignUserPassword = "EchoSignUserPassword";
        public const string EchoSignUserApiKey = "EchoSignUserApiKey";
        public const string EchoSignApplicationId = "EchoSignApplicationId";
        public const string EchoSignApplicationSecret = "EchoSignApplicationSecret";
        public const string EchoSignAuthTokenUrl = "EchoSignAuthTokenUrl";
        public const string EchoSignAgreementsUrl = "EchoSignAgreementsUrl";
        public const string EchoSignRemindersUrl = "EchoSignRemindersUrl";
        public const string EchoSignLibraryDocumentsUrl = "EchoSignLibraryDocumentsUrl";
        public const string EchoSignTransientDocumentsUrl = "EchoSignTransientDocumentsUrl";
        public const string EchoSignUploadTransientDocumentBoundry = "EchoSignUploadTransientDocumentBoundry";
        public const string EchoSignCallbackUri = "EchoSignCallbackUri";
        public const string EchoSignDocumentSavePath = "EchoSignDocumentSavePath";
        public const string EchoSignSignatureType = "EchoSignSignatureType";
        public const string EchoSignSignatureFlow = "EchoSignSignatureFlow";
        public const string EchoSignDaysUntilSigningDeadline = "EchoSignDaysUntilSigningDeadline";
        
        //SessionPrincipal Constants
        public const string SessionHeaderName = "session-header";
        public const string SessionHeaderNamespace = "s";

        //Root Folder Constant
        public const string RootFolderKey = "RootFolder";

        //Common PdfEngine Constants
        public const string PdfEngineLicense = "PdfEngineLicense";
        public const string PdfEngineTemplatePdfs = "PdfEngineTemplatePdfs";
        public const string PdfEngineTemplateHtml = "PdfEngineTemplateHtml";
        public const string PdfEngineMerchantPdfs = "PdfEngineMerchantPdfs";

        //Documents Settings
        public const string DocumentRootFolder = "DocumentRootFolder";
        public const string MerchantDocumentFolder = "MerchantDocumentFolder";

		// Companies House Constants
        public const string CompaniesHouseGatewayUserId = "CompaniesHouseGatewayUserId";
        public const string CompaniesHouseGatewayPassword = "CompaniesHouseGatewayPassword";
        public const string CompaniesHouseXmlWebUrl = "CompaniesHouseXmlWebUrl";
        public const string CompaniesHouseJsonWebUrl = "CompaniesHouseJsonWebUrl";
        public const string ComapniesHouseGatewayEndpoint = "CompaniesHouseGatewayEndpoint";
        public const string CompaniesHouseWebRequestTimeoutMilliseconds = "CompaniesHouseWebRequestTimeoutMilliseconds";
        public const string CompaniesHouseMaxRetryCount = "CompaniesHouseMaxRetryCount";

        //Iridium Constants
        public const string IridiumDomain = "IridiumDomain";
        public const string IridiumUserName = "IridiumUserName";
        public const string IridiumPassword = "IridiumPassword";
        public const string IridiumEmailSendFrom = "IridiumEmailSendFrom";
        public const string IridiumTestSendEmail = "IridiumTestSendEmail";
        public const string IridiumConfirmMaxMinutesToCheck = "IridiumConfirmMaxMinutesToCheck";

        //CacheConfig Constants
        public const string CacheName = "CacheName";

        //Opportunity
        public const int EquipmentMaxCount = 5;

    }
}
