using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Dto.Merchant
{
     [DataContract]
    public class MerchantAdvancedSearchDto
     {
         [DataMember]
         public Guid MerchantGuid { get; set; }

         [DataMember]
         public long V1MerchantId { get; set; }

         [DataMember] 
         public string BusinessName;

         [DataMember]
         public string FirstName;

         [DataMember]
         public string LastName;

         [DataMember] 
         public string Email;

         [DataMember] 
         public string Street;

         [DataMember]
         public string Town;

         [DataMember]
         public string PostCode;

         [DataMember]
         public string LocatorId { get; set; }

         [DataMember]
         public long ThompsonCodeKey { get; set; }

         [DataMember]
         public GenBusinessLegalTypeEnum BusinessLegalTypeKey { get; set; }

         [DataMember]
         public DateTime? LastUpdated { get; set; }

     }
}
