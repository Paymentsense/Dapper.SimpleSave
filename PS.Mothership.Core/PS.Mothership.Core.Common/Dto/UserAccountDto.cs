using System.Collections.Generic;
using System.Runtime.Serialization;
using Castle.Components.DictionaryAdapter;
using PS.Mothership.Core.Common.Enums;
using PS.Mothership.Core.Common.Template.PsMsContext;

namespace PS.Mothership.Core.Common.Dto
{
    
    [DataContract]
    public class UserAccountDto
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public UserStatusLutEnum UserStatusId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string Inital { get; set; }
        [DataMember]
        public UserOptionsFlagLutEnum UserOptionsId { get; set; }     
        [DataMember]
        public ICollection<string> AlternateLoginNames { get; set; } 
        [DataMember]
        public string ChosenLoginName { get; set; }

        // set default
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
    }
}