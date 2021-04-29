using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class CurrentMatch : Match
    {
        public List<AnglerWeighIn> WeighIns { get; }

        public CurrentMatch(DateTime dateTime, string venue, string pool) : base(dateTime, venue, pool)
        {
            WeighIns = new List<AnglerWeighIn>();
        }

        public CurrentMatch(DateTime dateTime, string venue, string pool, List<AnglerWeighIn> weighIns) : base(dateTime, venue, pool)
        {
            //TESTING PURPOSES
            WeighIns = weighIns;
        }

        public bool HasWeighedIn()
        {
            Predicate<AnglerWeighIn> predicate = FindAngler;
            return WeighIns.Find(predicate) != null;
        }

        private static bool FindAngler(AnglerWeighIn weighIn)
        {
            return weighIn.Angler == App.User;
        }

    }
}
