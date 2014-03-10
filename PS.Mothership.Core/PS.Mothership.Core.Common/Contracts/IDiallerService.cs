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
        ValidUserInfoDto ValidateUser(Guid updateSessionGuid);

        [OperationContract]
        Guid LogDiallerSessionSubscribe(Guid userGuid, Guid updateSessionGuid);

        [OperationContract]
        void LogDiallerSessionUnsubscribe(Guid userGuid, Guid updateSessionGuid, Guid diallerSessionGuid,
            bool wasForcedLogout, LogoutReasonEnum logoutReason);

        [OperationContract]
        IEnumerable<InboundQueueDetailsDto> GetInboundQueueDetails();

        [OperationContract]
        IEnumerable<MissingCallRecordingsDto> GetMissingCallRecordings(DateTime dateStart, DateTime dateEnd);

        [OperationContract]
        void UpdateRecorderCallIdForCallGuid(Guid callGuid, long recorderCallId, Guid updateSessionGuid);

        [OperationContract]
        Dictionary<long, long> TryToFindDiallerDepartmentsByUserGuid(Guid userGuid);

        [OperationContract]
        void InsertCallRecordingEvent(CallRecordingEventDto callRecordingEvent);

        [OperationContract]
        Guid LogDiallerModeChange(Guid userGuid, Guid updateSessionGuid, ModeEnum diallerMode);

        [OperationContract]
        void LogNewDiallerCall(NewDiallerCallDto diallerCall);

        [OperationContract]
        void LogFinalisedCall(FinalisedDiallerCallDto diallerCall);

        [OperationContract]
        bool IsCallResolved(Guid prospectingCampaignCallGuid);

        [OperationContract]
        Guid AddOrUpdateSpeedDialNumber(Guid userGuid, Guid updateSessionGuid, SpeedDialNumberDto speedDialNumber);

        [OperationContract]
        void DeleteSpeedDialNumber(Guid userGuid, Guid updateSessionGuid, Guid speedDialNumberGuid);

        [OperationContract]
        IEnumerable<SipAccountDto> GetSipAccountList(Guid userSipAccountGuid);
    }
}
