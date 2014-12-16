using System.ServiceModel;

namespace PS.Mothership.Core.Common.Contracts
{
    [ServiceContract]
    public interface IProspectImportService
    {
        /// <summary>
        /// Opens a connection to a remote server and attempts to import
        /// the available prospects to a configured database
        /// </summary>
        [OperationContract]
        void ImportProspects();
    }
}
