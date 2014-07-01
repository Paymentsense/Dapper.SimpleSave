using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstData_InfoOutletOutletTradingInfoDto
    {
        public string Methods_Sale_Card_Present { get; set; }
        public string Methods_Sale_Mail_order { get; set; }
        public string Methods_Sale_Internet { get; set; }
        public string Sale_B2B_Payments { get; set; }
        public Application_InfoOutletOutlet_Trading_InfoFull_Payments_Ever_Taken_Before_Delivery Full_Payments_Ever_Taken_Before_Delivery { get; set; }
        public string Percent_Of_Time_Required { get; set; }
        public string Advance_Time_Required { get; set; }
        public Application_InfoOutletOutlet_Trading_InfoPayment_Accepted_Card_Membership_Subscription Payment_Accepted_Card_Membership_Subscription { get; set; }
        public string Percent_Turnover_Payments_Merchant { get; set; }
        public string Average_Length_Membership { get; set; }
        public string Swiped_Information_CNP { get; set; }
        public string Swiped_Information_Card_Present { get; set; }
        public Application_InfoOutletOutlet_Trading_InfoSubmit_To_Refund Submit_To_Refund { get; set; }
        public string Service_Delivered_Zero_Seven_Days { get; set; }
        public string Service_Delivered_Eight_Forteen_Days { get; set; }
        public string Service_Delivered_Fifteen_Thirty_Days { get; set; }
        public string Service_Delivered_Thirty_Days_More { get; set; }
        public Application_InfoOutletOutlet_Trading_InfoDeposits_Required Deposits_Required { get; set; }
        public string Average_Time_Delivery_Goods { get; set; }
        public string Transaction_Deposit_Required { get; set; }
        public string Transaction_Deposit_Time_Required { get; set; }
        public Application_InfoOutletOutlet_Trading_InfoPayments_For_Guarantees_Warranties Payments_For_Guarantees_Warranties { get; set; }
        public string Card_TurnOver_Payments { get; set; }
        public string Average_Length_Guar_Warn { get; set; }
        public string Average_Good_Returned { get; set; }
        public Application_InfoOutletOutlet_Trading_InfoAutomatic_Renewals_Transaction Automatic_Renewals_Transaction { get; set; }

    }
}
