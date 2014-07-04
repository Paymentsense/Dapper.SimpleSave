using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Mothership.Core.Common.Helper
{
    /// <summary>
    ///     Debug stop watch, use full during development
    ///     the symbols (methods) wont be included during release
    ///     mode
    /// </summary>
    public static class DebugStopwatch
    {
        #region Constant Fields

        private const int InvalidTime = -1;

        #endregion          

        [Conditional("DEBUG")]
        public static void Start(ref Stopwatch stopwatch)
        {
            if (stopwatch == null)
                stopwatch = Stopwatch.StartNew();

            if (!stopwatch.IsRunning)
            {
                stopwatch.Restart();
                return;
            }

            // if reached here
            stopwatch.Reset();
            stopwatch.Start();
        }

        [Conditional("DEBUG")]
        public static void Stop(ref Stopwatch stopwatch)
        {
            if (stopwatch.IsRunning)
                stopwatch.Stop();
        }

        /// <value>Time elapsed in milliseconds</value>
        [Conditional("DEBUG")]
        public static void DurationInMilliseconds(string message,ref Stopwatch stopwatch)
        {
            Debug.WriteLine("{0} : time {1} ms", message, !stopwatch.IsRunning ? stopwatch.ElapsedMilliseconds : InvalidTime);
        }

        /// <value>Time elapsed in seconds</value>
        [Conditional("DEBUG")]
        public static void DurationInSeconds(string message, ref Stopwatch stopwatch)
        {
            Debug.WriteLine("{0} : time {1} s", message, !stopwatch.IsRunning ? stopwatch.ElapsedMilliseconds : InvalidTime);
        }
    }
}
