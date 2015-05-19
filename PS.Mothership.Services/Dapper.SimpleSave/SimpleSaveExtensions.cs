using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.SimpleSave {
    public static class SimpleSaveExtensions {

        public static void Update<T>(this IDbConnection connection, T obj)
        {
            Update<T>(connection, new [] { obj });
        }

        public static void Update<T>(this IDbConnection connection, IEnumerable<T> collection)
        {
            
        }
    }
}
