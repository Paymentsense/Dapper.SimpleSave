using System;
using System.Runtime.Serialization;
using System.Web.Security;
using Newtonsoft.Json;
using PS.Mothership.Core.Common.Template.PsMsContext;

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
    [DataContract]
    public class UserProfileDto
    {
        [DataMember]
        public bool IsLoggedIn { get; set; }
        [DataMember]
        public long UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public bool IsPersistent { get; set; }
        [DataMember]
        public bool IsValid { get; set; }
        [DataMember]
        public bool CanImpersonate { get; set; }
        [DataMember]
        public bool IsImpersonate { get; set; }
        [DataMember]
        public MembershipCreateStatus Status { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int TotalCount { get; set; } // gives the total count based on selection criteria
        
        private Guid _sessionId = Guid.NewGuid();        
        [JsonIgnore]     
        [DataMember]
        public Guid SessionId
        {
            get { return _sessionId; }  
            set { _sessionId = value; }
        }

        /// <summary>
        ///     This is just to manage the internal status
        ///     of the user state and not to be transfered
        ///     or serilized for transport
        /// </summary>
        [JsonIgnore]
        public LoginUserResultStatusLutEnum StatusInternal { get; set; }
    }
}