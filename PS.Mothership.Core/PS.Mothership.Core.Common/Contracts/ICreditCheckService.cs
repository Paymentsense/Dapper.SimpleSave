using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Dto;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface ICreditCheckService
    {
        [OperationContract]
        CreditCheckResponseDto GetCreditScore(CreditCheckRequestDto creditCheckRequest);

    }
}
