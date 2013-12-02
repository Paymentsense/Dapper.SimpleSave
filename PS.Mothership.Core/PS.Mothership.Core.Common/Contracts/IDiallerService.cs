using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "DiallerService")]
    public interface IDiallerService
    {
        [OperationContract]
        ValidUserInfoDto ValidateUser(Guid userGuid, Guid mothershipSessionGuid);

        [OperationContract]
        Guid LogDiallerSessionSubscribe(DiallerSessionSubscribeDto diallerSessionSubscribe);

        [OperationContract]
        Guid LogDiallerSessionUnsubscribe(DiallerSessionUnsubscribeDto diallerSessionUnsubscribe);

        [OperationContract]
        SipAccountDetailsDto GetSipAccountDetails(Guid userGuid);

        [OperationContract(IsOneWay = true)]
        List<InboundQueueDetailsDto> GetInboundQueueDetails();

        [OperationContract(IsOneWay = true)]
        List<MissingCallRecordingsDto> GetMissingCallRecordings(DateTime dateStart, DateTime dateEnd);

        [OperationContract]
        void UpdateRecorderCallIdForCallGuid(Guid callGuid, int recorderCallId, Guid userGuid);
    }
}
