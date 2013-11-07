using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PS.Mothership.Core.Common.Template.Usr;
using Action = PS.Mothership.Core.Common.Enums.Action;

namespace PS.Mothership.Core.Common.Dto
{
    
    [DataContract]
    public class UserAccountDto
    {
        [DataMember]
        public long UserId { get; set; }                
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string LoginName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string Initial { get; set; }
        [DataMember]
        public StatusOptionFlagEnum UserOptionsId { get; set; }     
        [DataMember]
        public ICollection<string> AlternateLoginNames { get; set; } 
        [DataMember]
        public string ChosenLoginName { get; set; }

        // set default
        private UserStatusEnum _userStatusId = UserStatusEnum.NewHire;
        [DataMember]
        public UserStatusEnum UserStatusId
        {
            get { return _userStatusId; }
            set { _userStatusId = value; }

        }

        private Action _action = Action.Add;
        [DataMember]
        public Action Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }

        private Guid _sessionId = Guid.NewGuid();
        [JsonIgnore]
        [DataMember]
        public Guid SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }
    }
}