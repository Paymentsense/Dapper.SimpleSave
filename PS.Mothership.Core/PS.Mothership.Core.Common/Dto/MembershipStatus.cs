using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Dto
{
    public enum MembershipStatus
    {
        Success,
        InvalidUserName,
        InvalidPassword,
        InvalidQuestion,
        InvalidAnswer,
        InvalidEmail,
        DuplicateUserName,
        DuplicateEmail,
        UserRejected,
        InvalidProviderUserKey,
        DuplicateProviderUserKey,
        ProviderError,
        AccountLockOut
    }
}
