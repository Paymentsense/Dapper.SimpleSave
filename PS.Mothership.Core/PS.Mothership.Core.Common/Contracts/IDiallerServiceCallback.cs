using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "DiallerServiceCallback")]
    public interface IDiallerServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyMissingCallRecordings(List<MissingCallRecordingsDto> missingCallRecordingsList);

        [OperationContract(IsOneWay = true)]
        void NotifyNextCallQueue(GetNextCallDto nextCall);

        [OperationContract(IsOneWay = true)]
        void NotifyInboundQueueDetails(List<InboundQueueDetailsDto> inboundQueueDetailsList);

        [OperationContract(IsOneWay = true)]
        void NotifyUserSalesUser(List<SalesUserDto> userSalesUserList);
    }
}
