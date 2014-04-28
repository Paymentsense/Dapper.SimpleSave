using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Enums.EchoSign
{
    [DataContract]
    public enum EventTypeEnum
    {
        [EnumMember]
        SHARED,
        [EnumMember]
        EMAIL_BOUNCED,
        [EnumMember]
        SIGNER_SUGGESTED_CHANGES,
        [EnumMember]
        SIGNED,
        [EnumMember]
        OTHER,
        [EnumMember]
        APPROVED,
        [EnumMember]
        EXPIRED_AUTOMATICALLY,
        [EnumMember]
        APPROVAL_REQUESTED,
        [EnumMember]
        DELEGATED,
        [EnumMember]
        ESIGNED,
        [EnumMember]
        AUTO_CANCELLED_CONVERSION_PROBLEM,
        [EnumMember]
        FAXED_BY_SENDER,
        [EnumMember]
        PASSWORD_AUTHENTICATION_FAILED,
        [EnumMember]
        KBA_AUTHENTICATED,
        [EnumMember]
        EXPIRED,
        [EnumMember]
        REJECTED,
        [EnumMember]
        SIGNATURE_REQUESTED,
        [EnumMember]
        WEB_IDENTITY_AUTHENTICATED,
        [EnumMember]
        UPLOADED_BY_SENDER,
        [EnumMember]
        WEB_IDENTITY_SPECIFIED,
        [EnumMember]
        WIDGET_DISABLED,
        [EnumMember]
        CREATED,
        [EnumMember]
        OFFLINE_SYNC,
        [EnumMember]
        REPLACED_SIGNER,
        [EnumMember]
        WIDGET_ENABLED,
        [EnumMember]
        RECALLED,
        [EnumMember]
        EMAIL_VIEWED,
        [EnumMember]
        FAXIN_RECEIVED,
        [EnumMember]
        SENDER_CREATED_NEW_REVISION,
        [EnumMember]
        KBA_AUTHENTICATION_FAILED
    }
}
