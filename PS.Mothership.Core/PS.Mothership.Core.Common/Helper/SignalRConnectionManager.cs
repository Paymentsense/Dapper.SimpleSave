using PS.Mothership.Core.Common.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PS.Mothership.Core.Common.Helper
{
    public class SignalRConnectionManager : ISignalRConnectionManager
    {

        #region Constants

        private const int MaxConnections = 5;

        #endregion

        #region Private  Variables

        /// <summary>
        /// storage to keep count of the current connections, using a ConcurrentDictionary since there is no ConcurrentSet 
        /// the value field will be used to hold the page visibility status for each connection
        /// </summary>
        private readonly ConcurrentDictionary<Guid, bool> _connections;

        #endregion

        #region Constructor

        public SignalRConnectionManager()
        {
            _connections = new ConcurrentDictionary<Guid, bool>();
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

            return _connections.Count < MaxConnections;
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

            return _connections.Count == 1;
        }

        /// <summary>
        /// method to remove all existing connections except
        /// the one passed as parameter
        /// </summary>
        /// <param name="connectionGuid"></param>
        public void RemoveAllConnectionsExcept(Guid connectionGuid)
        {

            bool dontCare;
            foreach (Guid g in _connections.Keys.Where(r => r != connectionGuid))
            {
                _connections.TryRemove(g, out dontCare);
            }
        }

        /// <summary>
        /// method to add a SignalR connection (tab)
        /// </summary>
        /// <param name="connectionGuid"></param>
        /// <param name="visible"></param>
        public bool AddConnection(Guid connectionGuid, bool visible = true)
        {

            bool ret = false;
            if (CanAddConnection())
            {
                ret = _connections.TryAdd(connectionGuid, visible);
            }
            return ret;
        }

        /// <summary>
        /// method to remove a particular SignalR connection (tab)
        /// </summary>
        /// <param name="connectionGuid"></param>
        /// <returns></returns>
        public bool RemoveConnection(Guid connectionGuid)
        {

            bool dontCare;
            return _connections.TryRemove(connectionGuid, out dontCare);
        }

        /// <summary>
        /// method to return the number of currently registered SignalR connections (tabs)
        /// </summary>
        /// <returns></returns>
        public int GetConnectionCount()
        {

            return _connections.Count;
        }

        /// <summary>
        /// method to set the visibility state for a particular SignalR connection (tab)
        /// </summary>
        /// <param name="connectionGuid"></param>
        /// <param name="visible"></param>
        public void SetVisibility(Guid connectionGuid, bool visible)
        {

            if (_connections.ContainsKey(connectionGuid))
            {
                _connections[connectionGuid] = visible;
            }
        }

        /// <summary>
        /// method to return the number of currently visible SignalR connections (tabs)
        /// </summary>
        /// <returns></returns>
        public int GetVisibleCount()
        {

            return _connections.Values.Count(r => r);
        }

        /// <summary>
        /// method to return all the connection GUIDs being watched
        /// </summary>
        /// <returns></returns>
        public ICollection<Guid> GetConnectionGuids()
        {
            return _connections.Keys;
        }

        #endregion
    }
}
