using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PS.Mothership.Core.Common.Constructs;
using PS.Mothership.Core.Common.Dto.User;

namespace PS.Mothership.Core.Common.Contracts
{
    public interface ISearchService
    {
        TOutput QuickSearch<TInput, TOutput>(TInput searchInput);
    }
}
