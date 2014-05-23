using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto.Iridium;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IIridiumService
    {
        [OperationContract]
        void SubmitToIridium(Guid opportunityGuid);
    }
}
