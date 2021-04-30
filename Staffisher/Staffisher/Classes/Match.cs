using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public abstract class Match
    {
        public DateTime DateTime { get; }
        public string Venue { get; }
        public string Pool { get; }

        public Match(DateTime dateTime, string venue, string pool)
        {
            DateTime = dateTime;
            Venue = venue;
            Pool = pool;
        }

        public Match() { }
    }
}
