using System;
using System.ServiceModel;
using PS.Mothership.Core.Common.Dto;
using PS.Mothership.Core.Common.Enums;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(CallbackContract = typeof (IDiallerServiceCallback), Name = "DiallerService")]
    public interface IDiallerService
    {
        [OperationContract]
        ValidUserInfoDto ValidateUser(Guid userGuid, Guid mothershipSessionGuid);

        [OperationContract]
        Guid LogDiallerSessionSubscribe(DiallerSessionSubscribeDto diallerSessionSubscribe);

        [OperationContract]
        Guid LogDiallerSessionUnsubscribe(DiallerSessionUnsubscribeDto diallerSessionUnsubscribe);

        [OperationContract]
        bool UpdateSelectedSalesUserAndCampaign(SelectedSalesUserAndCampaignDto selectedSalesUserAndCampaign);

        [OperationContract]
        SipAccountDetailsDto GetSipAccountDetails(Guid userGuid);

        [OperationContract]
        long LogClientModeChange(ClientModeChangeDto clientModeChange);

        [OperationContract]
        GetMerchantByPhoneDto GetMerchantByPhone(string phoneNumber);

        [OperationContract]
        CampaignDetailsDto GetCampaignDetailsByCalledNumber(string calledNumber);

        [OperationContract]
        long? AddInboundQueueCallRecord(InboundQueueCallRecordDto inboundQueueCallRecord);

        [OperationContract]
        string TryToFindMerchantByGuid(Guid merchantGuid);

        [OperationContract]
        void LogFinalisedCall(DiallerCallDto diallerCall);

        [OperationContract(IsOneWay = true)]
        void GetNextCallQueue(Guid agentUserGuid);

        [OperationContract]
        // TODO: replace CallRecordResolution for templated enum! -> DialInboundQueueCallResolutionEnum
        void SetInboundQueueCallRecordResolution(long inboundQueueCallTrnId, CallRecordResolution resolution);

        [OperationContract(IsOneWay = true)]
        void GetInboundQueueDetails();

        [OperationContract(IsOneWay = true)]
        void GetUserSalesUsers(Guid userGuid);

        [OperationContract]
        bool IsCallResolved(long pcMerchantTranId);

        [OperationContract(IsOneWay = true)]
        void GetMissingCallRecordings(DateTime dateStart, DateTime dateEnd);

        [OperationContract]
        void UpdateRecorderCallIdForCallGuid(Guid callGuid, int recorderCallId, Guid userGuid);
    }
}
