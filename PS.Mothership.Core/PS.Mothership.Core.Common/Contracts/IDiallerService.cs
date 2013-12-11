using PS.Mothership.Core.Common.Rellaid.Dto;
using PS.Mothership.Core.Common.Template.Dial;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "DiallerService")]
    public interface IDiallerService
    {
        [OperationContract]
        ValidUserInfoDto ValidateUser(Guid mothershipSessionGuid);

        [OperationContract]
        void LogDiallerSessionSubscribe(Guid loginResultGuid, DateTime startDateTime, string clientIp);

        [OperationContract]
        void LogDiallerSessionUnsubscribe(Guid loginResultGuid, DateTime endDateTime, bool wasForcedLogout, LogoutReasonEnum logoutReason);

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
        void InsertCallRecordingEvent(DateTime? createdDate, Guid? prospectionCallGuid, string fileName, Guid? merchantGuid, Guid userGuid);

        [OperationContract]
        void LogFinalisedCall(DiallerCallDto diallerCall);
    }
}
