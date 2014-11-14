using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PS.Mothership.Core.Common.SignalRConnectionHandling
{
    public class SignalRConnectionManager : ISignalRConnectionManager
    {
        #region Constants

        private const int MaxConnections = 5;

        #endregion

        #region Private Variables

        /// <summary>
        /// storage to keep count of the current connections, using a ConcurrentDictionary since there is no ConcurrentSet 
        /// the value field will be used to hold the page visibility status for each connection
        /// </summary>
        public ConcurrentDictionary<Guid, bool> Connections { get; set; }

        private ISignalRUser _signalRUser;

        #endregion

        #region Constructor

        public SignalRConnectionManager(ISignalRUser signalRUser)
        {
            Connections = new ConcurrentDictionary<Guid, bool>();

            _signalRUser = signalRUser;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Since we are limiting the number of simultaneous connections to 5,
        /// the SignalR OnConnected should invoke this method
        /// </summary>
        /// <returns></returns>
        public bool CanAddConnection()
        {

            return Connections.Count < MaxConnections;
        }

        /// <summary>
        /// This method is to be called on the client side on the 'beforeunload' event
        /// to check if this is the last connection in the hub.
        /// The client should invoke an ajax call to http://localhost:8080/islastconnection
        /// which, in turn, will call this method
        /// </summary>
        /// <returns></returns>
        public bool IsLastConnection()
        {

            return Connections.Count == 1;
        }

        /// <summary>
        /// method to remove all existing connections except
        /// the one passed as parameter
        /// </summary>
        /// <param name="connectionGuid"></param>
        public void RemoveAllConnectionsExcept(Guid connectionGuid)
        {

            bool dontCare;
            foreach (Guid g in Connections.Keys.Where(r => r != connectionGuid))
            {
                Connections.TryRemove(g, out dontCare);
            }
        }

        /// <summary>
        /// method to add a SignalR connection (tab)
        /// </summary>
        /// <param name="connectionGuid"></param>
        /// <param name="visible"></param>
        public bool AddConnection(Guid connectionGuid, bool visible = true)
        {
            bool success = false;
            if (CanAddConnection())
            {
                success = Connections.TryAdd(connectionGuid, visible);
            }

            if (success)
            {
                _signalRUser.UpdateCollection();
            }

            return success;
        }

        /// <summary>
        /// method to remove a particular SignalR connection (tab)
        /// </summary>
        /// <param name="connectionGuid"></param>
        /// <returns></returns>
        public bool RemoveConnection(Guid connectionGuid)
        {
            bool valueRemoved;

            var success = Connections.TryRemove(connectionGuid, out valueRemoved);

            if (success)
            {
                _signalRUser.UpdateCollection();
            }

            return success;
        }

        /// <summary>
        /// method to return the number of currently registered SignalR connections (tabs)
        /// </summary>
        /// <returns></returns>
        public int GetConnectionCount()
        {
            return Connections.Count;
        }

        /// <summary>
        /// method to set the visibility state for a particular SignalR connection (tab)
        /// </summary>
        /// <param name="connectionGuid"></param>
        /// <param name="visible"></param>
        public void SetVisibility(Guid connectionGuid, bool visible)
        {
            if (Connections.ContainsKey(connectionGuid))
            {
                Connections[connectionGuid] = visible;
            }
               
            _signalRUser.UpdateCollection();
        }

        /// <summary>
        /// method to return the number of currently visible SignalR connections (tabs)
        /// </summary>
        /// <returns></returns>
        public int GetVisibleCount()
        {
            return Connections.Values.Count(r => r);
        }

        /// <summary>
        /// method to return all the connection GUIDs being watched
        /// </summary>
        /// <returns></returns>
        public ICollection<Guid> GetConnectionGuids()
        {
            return Connections.Keys;
        }

        #endregion
    }
}
