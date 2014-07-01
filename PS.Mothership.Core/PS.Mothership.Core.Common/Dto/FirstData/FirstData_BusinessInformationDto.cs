using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class Business_Information
    {
        public string DBA_Name { get; set; }
        public string Legal_Name { get; set; }

        public string Street_Address_Name_1 { get; set; }
        public string Street_Address_Name_2 { get; set; }
        public string Street_Address_Name_3 { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Postal_Code { get; set; }
        public Application_InfoBusiness_InformationAdvert_Broch_Mail Advert_Broch_Mail { get; set; }
        public Application_InfoBusiness_InformationAdvert_Catalog Advert_Catalog { get; set; }
        public Application_InfoBusiness_InformationAdvert_Internet Advert_Internet { get; set; }
        public Application_InfoBusiness_InformationAdvert_News_Mag Advert_News_Mag { get; set; }
        public Application_InfoBusiness_InformationAdvert_Tv_Radio Advert_Tv_Radio { get; set; }
        public Application_InfoBusiness_InformationAdvert_Phone Advert_Phone { get; set; }
        public string Prev_Processor_Name { get; set; }
        public Application_InfoBusiness_InformationChange_Reason Change_Reason { get; set; }
        public Application_InfoBusiness_InformationName_Certification Name_Certification { get; set; }
        public string Business_Started { get; set; }
        public string Vat_Number { get; set; }
        public string Association_Name { get; set; }
        public string Registered_Charity_Number { get; set; }
        public string Date_Incorporated { get; set; }
        public Application_InfoBusiness_InformationPricing_Strategy Pricing_Strategy { get; set; }
        public string Agent_Bank_Code { get; set; }
        public Application_InfoBusiness_InformationSales_Area Sales_Area { get; set; }
        public Application_InfoBusiness_InformationSales_Channel Sales_Channel { get; set; }
        public Application_InfoBusiness_InformationBank_Relationship Bank_Relationship { get; set; }
        public Application_InfoBusiness_InformationContactless_Payment_Merchant Contactless_Payment_Merchant { get; set; }
        public Application_InfoBusiness_InformationInternational_Tax_Exempt International_Tax_Exempt { get; set; }
        public string International_Tax_Id { get; set; }
        public Application_InfoBusiness_InformationBusiness_Type Business_Type { get; set; }
        public string Company_Registration_Number { get; set; }
        public string Date_Of_Sales_Contract { get; set; }
        public string Date_Site_Visit_UnderTaken { get; set; }
        public string Date_Of_Introduction { get; set; }
        public string Date_Of_Contract { get; set; }
        public string Date_Of_Facility_Required { get; set; }
        public string Date_Of_Application_Received { get; set; }
        public string Comments { get; set; }

    }
}
