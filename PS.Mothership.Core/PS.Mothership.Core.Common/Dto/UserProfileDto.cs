using System;
using System.Web.Security;

namespace PS.Mothership.Core.Common.Dto
{
    public class UserProfileDto
    {
        public bool IsLoggedIn { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public bool IsPersistent { get; set; }
        public bool IsValid { get; set; }
        public bool CanImpersonate { get; set; }
        public bool IsImpersonate { get; set; }
        public MembershipCreateStatus Status { get; set; }
        public string Message { get; set; }

        private readonly Guid _sessionId = Guid.NewGuid();
        public Guid SessionId
        {
            get { return _sessionId; }            
        }
    }
}