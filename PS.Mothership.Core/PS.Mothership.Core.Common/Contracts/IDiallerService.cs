using PS.Mothership.Core.Common.Dto.Campaign;
using PS.Mothership.Core.Common.Dto.Dialler;
using PS.Mothership.Core.Common.Dto.Merchant;
using PS.Mothership.Core.Common.Dto.User;
using PS.Mothership.Core.Common.Template.Dial;
using PS.Mothership.Core.Common.Template.Mrkt;
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
        void UpdateRecorderCallIdForCallGuid(Guid callGuid, int recorderCallId);

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
        void AddCampaignCallResolutionBySipCallGuid(Guid sipCallGuid, MrktCampaignCallResolutionEnum resolution);

        [OperationContract]
        void ProcessInboundCall(NewDiallerCallDto diallerCall);

        [OperationContract]
        ProspectMatchDto IsMatchToExistingMerchant(NewDiallerCallDto diallerCall);

        [OperationContract]
        UserProfileDto GetUser(Guid userGuid);

        [OperationContract]
        string GetMerchantBusinessNameByGuid(Guid merchantGuid);

        [OperationContract]
        IEnumerable<DiallerMerchantDto> GetMerchantsByPhoneNumber(string phoneNumber);

        [OperationContract]
        ResponseTapDto GetResponseTapRecordByPhoneNumber(string phoneNumber);

        [OperationContract]
        CampaignDto GetCampaignByPhoneNumber(string phoneNumber);

        [OperationContract]
        string GetTransferNumber(DialTransferNumberEnum transfer);

        [OperationContract]
        IEnumerable<SpeedDialNumberDto> GetAllTransferNumbers();

        [OperationContract]
        IDictionary<string, string> RequestDescriptionForUnknownPhoneNumber(IList<string> unknownPhoneNumbers);
        
        [OperationContract]
        CallResolutionDto GetCallResolution(Guid callGuid);
        
        [OperationContract]
        CallResolutionDto SaveCallResolution(CallResolutionDto callResolutionDto);

        [OperationContract]
        CampaignCallResolutionDto GetCampaignCallResolution(Guid campaignCallTrnGuid);
       
        [OperationContract]
        CampaignCallResolutionDto SaveCampaignCallResolution(CampaignCallResolutionDto campaignCallResolutionDto);

        [OperationContract]
        CallResolutionDto GetPreviousUnresolvedCallDetails(Guid userGuid, Guid sessionGuid);

        [OperationContract]
        void UpdateCallRecordAnswered(Guid sipCallGuid);
    }
}
