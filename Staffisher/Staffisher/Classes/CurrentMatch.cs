using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    class CurrentMatch : Match
    {
        public List<AnglerWeighIn> WeighIns { get; }

        public CurrentMatch(DateTime dateTime, string venue, string pool) : base(dateTime, venue, pool)
        {
            WeighIns = new List<AnglerWeighIn>();
        }

    }
}
