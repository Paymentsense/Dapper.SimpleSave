using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Template.PsMsContext;

namespace PS.Mothership.Core.Common.Dto
{
    public class UserDto
    {
        [DataMember]
        public LoginUserResultLutEnum Status { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public UserAccountDto UserAccountDto { get; set; }        
    }
}
