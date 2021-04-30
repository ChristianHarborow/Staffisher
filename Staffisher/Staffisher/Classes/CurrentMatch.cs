using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class CurrentMatch : Match
    {
        public List<AnglerWeighIn> WeighIns { get; set; }

        public CurrentMatch(DateTime dateTime, string venue, string pool) : base(dateTime, venue, pool)
        {
            WeighIns = new List<AnglerWeighIn>();
        }

        public bool HasWeighedIn()
        {
            //After deserialization seperate references of the same object are no longer the same so must check email (unique)
            foreach (AnglerWeighIn weighIn in WeighIns)
            {
                if (weighIn.Angler.Email == App.User.Email) return true;
            }

            return false;
        }
    }
}
