using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstData_InfoOutletBusinessInfoBusinessDto
    {
        public string Est_Average_Transaction { get; set; }
        public Application_InfoOutletOutlet_Business_InfoBusiness_Type Business_Type { get; set; }
        public string MCC_Code { get; set; }
        public string Products_Services_Sold { get; set; }
        public Application_InfoOutletOutlet_Business_InfoMail_Statement_To Mail_Statement_To { get; set; }
        public Application_InfoOutletOutlet_Business_InfoBusiness_Email1_Type_One Business_Email1_Type_One { get; set; }
        public Application_InfoOutletOutlet_Business_InfoBusiness_Email1_Type_Two Business_Email1_Type_Two { get; set; }
        public string Business_Email_One { get; set; }
        public string Business_Email_Two { get; set; }
        public Application_InfoOutletOutlet_Business_InfoStatement_Delivery_Method Statement_Delivery_Method { get; set; }
        public Application_InfoOutletOutlet_Business_InfoStatement_Type Statement_Type { get; set; }
        public Application_InfoOutletOutlet_Business_InfoCurrency_Code Currency_Code { get; set; }
        public Application_InfoOutletOutlet_Business_InfoNon_Qualifying_Transaction Non_Qualifying_Transaction { get; set; }
        public string Split_Funding_Percent { get; set; }
        public string Split_Advance_Amount { get; set; }
        public string Split_Pay_To_Merchant { get; set; }
        public Application_InfoOutletOutlet_Business_InfoEnable_Split_Funding Enable_Split_Funding { get; set; }
        public string Combined_Annual_Credit_Card_Sales { get; set; }
        public string Total_Annual_Sales { get; set; }
        public string DDA_One { get; set; }
        public string ABA_One { get; set; }
        public string DDA_Two { get; set; }
        public string ABA_Two { get; set; }
        public string Business_BACS_Name { get; set; }
        public string Business_Account_Manager_Name { get; set; }
        public string Business_Overdraft_Limit { get; set; }
        public string Business_Loan_Amount { get; set; }
        public string Business_Loan_Term { get; set; }
        public string Business_Loan_Amount_Two { get; set; }
        public string Business_Loan_Term_Two { get; set; }
        public string Business_Bank_Phone_Number { get; set; }
        public string Business_Bank_Address { get; set; }
        public string INTES { get; set; }
        public Application_InfoOutletOutlet_Business_InfoSettlement_Timeframe_Indicator Settlement_Timeframe_Indicator { get; set; }
        public Application_InfoOutletOutlet_Business_InfoBacs Bacs { get; set; }
    }
}
