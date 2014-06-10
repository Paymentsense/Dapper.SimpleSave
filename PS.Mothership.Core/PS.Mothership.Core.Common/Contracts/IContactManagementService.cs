using PS.Mothership.Core.Common.Dto.Contact;
using PS.Mothership.Core.Common.Dto.Merchant;
using System;
using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract(Name = "ContactManagementService")]
    public interface IContactManagementService
    {
        [OperationContract]
        ContactDto GetContact(Guid contactGuid);

        [OperationContract]
        ContactDto SaveContact(ContactDto contactDto);

        [OperationContract]
        CountryDto CountryCodes();
    }
}
