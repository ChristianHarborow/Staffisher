using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class PastMatch : Match
    {
        public List<WeighIn> WeighIns { get; set; }

        public PastMatch(DateTime dateTime, string venue, string pool) : base(dateTime, venue, pool)
        {
            WeighIns = new List<WeighIn>();
        }

        public string GetPlacement(WeighIn weighIn)
        {
            if (weighIn == null) return "Did Not Weigh In";

            int placement = weighIn.Placement;
            string ordinal = "th";
            
            if ((placement % 100) / 10 != 1)
            {
                switch (placement % 10)
                {
                    case 1:
                        ordinal = "st";
                        break;
                    case 2:
                        ordinal = "nd";
                        break;
                    case 3:
                        ordinal = "rd";
                        break;
                }
            }

            return $"You Placed {placement}{ordinal} Out Of {WeighIns.Count}";
        }
        
        public string GetWeight(WeighIn weighIn)
        {
            if (weighIn == null) return "Did Not Weigh In";
            return $"You Caught {weighIn.ToString()}";
        }

        public WeighIn FindWeighIn()
        {
            //After deserialization seperate references of the same object are no longer the same so must check email (unique)
            foreach (WeighIn weighIn in WeighIns)
            {
                if (weighIn.Angler.Email == App.User.Email) return weighIn;
            }
            
            return null;
        }
    }
}
