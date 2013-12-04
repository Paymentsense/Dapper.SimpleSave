using System;
using System.Collections.Generic;
using System.ServiceModel;
using PS.Mothership.Core.Common.Rellaid.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "DiallerService")]
    public interface IDiallerService
    {
        [OperationContract]
        ValidUserInfoDto ValidateUser(Guid mothershipSessionGuid);

        [OperationContract]
        Guid LogDiallerSessionSubscribe(DiallerSessionSubscribeDto diallerSessionSubscribe);

        [OperationContract]
        Guid LogDiallerSessionUnsubscribe(DiallerSessionUnsubscribeDto diallerSessionUnsubscribe);

        [OperationContract]
        SipAccountDetailsDto GetSipAccountDetails(Guid userGuid);

        [OperationContract]
        List<InboundQueueDetailsDto> GetInboundQueueDetails();

        [OperationContract]
        List<MissingCallRecordingsDto> GetMissingCallRecordings(DateTime dateStart, DateTime dateEnd);

        [OperationContract]
        void UpdateRecorderCallIdForCallGuid(Guid callGuid, int recorderCallId, Guid userGuid);

        [OperationContract]
        Dictionary<long, long> TryToFindDiallerDepartmentsByUserGuid(Guid userGuid);

        [OperationContract]
        List<CallStatsDto> GetCallTotalsForToday();

        [OperationContract]
        void InsertCallRecordingEvent(CallRecordingEventDto callRecordingEvent);

        [OperationContract]
        void LogFinalisedCall(DiallerCallDto diallerCall);
    }
}
