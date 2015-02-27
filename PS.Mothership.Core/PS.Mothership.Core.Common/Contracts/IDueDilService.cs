using System;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto.DueDil;
using PS.Mothership.Core.Common.Enums.DueDil;
using PS.Mothership.Core.Common.Enums.EchoSign;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "DueDilService")]
    public interface IDueDilService
    {
        [OperationContract]
        CompanyDetailsDto Get(string companyRegNumber, DueDilLocale locale);

        [OperationContract]
        CompanyListDto Search(DueDilFilterDto dueDilFilterDto);

        [OperationContract]
        LastFetchedDetailsDto GetLastFetchedDetails(Guid applicationGuid, string companyRegNumber);

        [OperationContract]
        void SaveBusinessLegalInfoLnk(Guid applicationGuid, Guid businessDetailGuid);
    }
}
