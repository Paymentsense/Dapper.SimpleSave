using System;
using System.Web.Security;
using Newtonsoft.Json;

namespace PS.Mothership.Core.Common.Dto
{
    /// <summary>
    /// User Proile Dto
    /// </summary>
    /// <remarks>
    ///     1. For caching purpose, we use the object as cache key, if the client want
    ///     to ignore certain property which are not any value, decorate those properties
    ///     with JsonIgnore, as the cache server convert the object to json for generating key
    /// </remarks>
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
        public int TotalCount { get; set; } // gives the total count based on selection criteria

        private Guid _sessionId = Guid.NewGuid();
        [JsonIgnore] 
        public Guid SessionId
        {
            get { return _sessionId; }  
            set { _sessionId = value; }
        }
    }
}