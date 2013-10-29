using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "CompanyService")]
    public interface ICompanyService
    {
        [OperationContract] IEnumerable<CompanyDto> GetCasesByName(string companyName);
        [OperationContract] CompanyDto GetCaseByID(int companyID);
        [OperationContract] bool UpdateCompany(CompanyDto caseDto);
        [OperationContract] void AddNewCaseWithAddress(CompanyDto companyDto);
//        void UpdateCaseAndEmployeeJobTitle(int caseID, string newCompanyName, int employeeID, string newJobTitle);
    }
}