using System;

namespace Dapper.SimpleSave
{
    public class DifferenceEventArgs : EventArgs
    {
        public DifferenceEventArgs(Difference difference)
        {
            Difference = difference;
        }

        public Difference Difference { get; private set; }

        public void FurtherChangesMade()
        {
            HaveFurtherChangesBeenMade = true;
        }

        public bool HaveFurtherChangesBeenMade
        {
            get; private set;
        }
    }
}
