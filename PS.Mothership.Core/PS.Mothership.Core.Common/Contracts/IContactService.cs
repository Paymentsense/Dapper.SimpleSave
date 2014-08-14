using PS.Mothership.Core.Common.Dto.Merchant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface IContactService
    {
        [OperationContract]
        ContactDto GetContact(Guid id);
    }
}
