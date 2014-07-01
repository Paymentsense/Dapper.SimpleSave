using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto.FirstData
{
    public class FirstData_ApplicationInfoBankingInformationDto
    {
        public string MSC_Sort_Code { get; set; }
        public string MSC_Account_Number { get; set; }
        public string Deposit_Sort_Code { get; set; }
        public string Deposit_Account_Number { get; set; }
        public string Banking_Account_Holder_Name { get; set; }
        public string Banking_Account_Manager_Name { get; set; }
        public string Overdraft_Limit { get; set; }
        public string Loan_Amount_First { get; set; }
        public string Loan_Amount_Second { get; set; }
        public string Loan_Term_First { get; set; }
        public string Loan_Term_Second { get; set; }
        public Application_InfoBanking_InformationOutlet_Corp Outlet_Corp { get; set; }
        public string Bank_Phone_Number { get; set; }
        public string Bank_Address { get; set; }
    }
}
