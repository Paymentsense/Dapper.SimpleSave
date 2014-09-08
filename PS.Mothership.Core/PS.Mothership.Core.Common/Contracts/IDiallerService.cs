using PS.Mothership.Core.Common.Dto.Dialler;
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
        ValidUserInfoDto ValidateUser();

        [OperationContract]
        Guid LogDiallerSessionSubscribe(Guid userGuid);

        [OperationContract]
        void LogDiallerSessionUnsubscribe(Guid userGuid, Guid diallerSessionGuid,
            bool wasForcedLogout, DialLogoutReasonEnum logoutReason);

        [OperationContract]
        IEnumerable<InboundQueueDetailsDto> GetInboundQueueDetails();

        [OperationContract]
        IEnumerable<MissingCallRecordingDto> GetMissingCallRecordings(DateTime dateStart, DateTime dateEnd);

        [OperationContract]
        void UpdateRecorderCallIdForCallGuid(Guid callGuid, long recorderCallId);

        [OperationContract]
        Dictionary<long, long> TryToFindDiallerDepartmentsByUserGuid(Guid userGuid);

        [OperationContract]
        void InsertCallRecordingEvent(CallRecordingEventDto callRecordingEvent);

        [OperationContract]
        Guid LogDiallerModeChange(Guid userGuid, DialModeEnum diallerMode);

        [OperationContract]
        void LogNewDiallerCall(NewDiallerCallDto diallerCall);

        [OperationContract]
        void LogFinalisedCall(FinalisedDiallerCallDto diallerCall);

        [OperationContract]
        bool IsCallResolved(Guid prospectingCampaignCallGuid);

        [OperationContract]
        Guid AddOrUpdateSpeedDialNumber(Guid userGuid, SpeedDialNumberDto speedDialNumber);

        [OperationContract]
        void DeleteSpeedDialNumber(Guid userGuid, Guid speedDialNumberGuid);

        [OperationContract]
        IEnumerable<SipAccountNumberDto> GetSipAccountList(Guid userSipAccountGuid);

        [OperationContract]
        Guid AddInboundCampaignCallRecord(Guid sipCallGuid, Guid campaignGuid, string keyword, string referrerUrl);

        [OperationContract]
        void SetInboundCampaignCallRecordResolution(Guid inboundCampaignCallRecordGuid,
            DialInboundCampaignCallResolutionEnum resolution);
    }
}
