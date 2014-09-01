using System.Diagnostics;

namespace PS.Mothership.Core.Common.Helper
{
    /// <summary>
    ///     Timer class to calculate run time
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <changes>
    ///     <reason>
    ///         a. ###
    ///     </reason>
    ///     <date>
    ///         a. ###
    ///     </date>
    /// </changes>    
    public sealed class CTime
    {
        #region Constant Fields

        private const int InvalidTime = -1;

        #endregion

        #region Instance Fields

        private readonly Stopwatch _sw;

        #endregion

        #region Instance Constructor

        public CTime()
        {
            _sw = Stopwatch.StartNew();
        }

        #endregion

        #region Pubilc Methods        

        public long DurationInNanoSeconds
        {
            get { return !_sw.IsRunning ? (1000L*1000L*1000L)/Stopwatch.Frequency : InvalidTime; }
        }

        /// <value>Time elapsed in milliseconds</value>
        public long DurationInMilliseconds
        {            
            get { return !_sw.IsRunning ? _sw.ElapsedMilliseconds : InvalidTime; }
        }

        /// <value>Time elapsed in seconds</value>
        public int DurationInSeconds
        {
            get { return !_sw.IsRunning ? _sw.Elapsed.Seconds : InvalidTime; }
        }

        /// <summary>
        ///     Whether stop watch is running
        /// </summary>
        public bool IsRunning
        {
            get { return _sw.IsRunning; }
        }

        /// <summary>
        ///     Start timer.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Check whether it's running then star the timer,
        ///         if already running, then do a reset and start the
        ///         timer.
        ///     </para>
        /// </remarks>
        public void Start()
        {
            if (_sw == null) return;

            if (!_sw.IsRunning)
                _sw.Restart();
            else
            {
                _sw.Reset();
                _sw.Start();
            }
        }

        /// <summary>
        ///     Stop timer.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Checks whether it's running and stops the timer
        ///     </para>
        /// </remarks>
        public void Stop()
        {
            if (_sw.IsRunning)
                _sw.Stop();
        }

        /// <summary>
        ///     Reset the elapsed time to zero
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Checks whether it's running and stops the timer
        ///     </para>
        /// </remarks>
        public void Reset()
        {
            if (_sw.IsRunning)
                _sw.Reset();
        }

        #endregion
    }
}