namespace PS.Mothership.Core.Common.Constants
{
    public class ConfigConstants
    {
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
        public const string SendSMSMessageDefault = "SendSMSMessageDefault";
        public const string SendSMSTestNumber = "SendSMSTestNumber";
        public const string SendSmsTestAccountReference = "SendSmsTestAccountReference";
        public const string SendSMSTestNumberGuid = "SendSMSTestNumberGuid";
        public const string SendSMSMessageDefaultNumber = "SendSMSMessageDefaultNumber";

        // Common SMTP Constants
        public const string SMTPServer = "SMTPServer";
        public const string SMTPEnableSsl = "SMTPEnableSsl";
        public const string SMTPPortNumber = "SMTPPortNumber";
        public const string NetworkName = "NetworkName";
        public const string NetworkPassword = "NetworkPassword";

        // Common IMAP Constants
        public const string IMAPServer = "IMAPServer";
        public const string IMAPPortNumber = "IMAPPortNumber";
        public const string IMAPUsername = "IMAPUsername";
        public const string IMAPPassword = "IMAPPassword";
        public const string IDLEConnectionTime = "IDLEConnectionTime";

		// Companies House Constants
		public const string CompaniesHouseGatewayUserId = "CompaniesHouseGatewayUserId";
		public const string CompaniesHouseGatewayPassword = "CompaniesHouseGatewayPassword";
    }
}
