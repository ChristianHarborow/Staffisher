using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    class PastMatch : Match
    {
        public List<AnglerWeighIn> WeighIns { get; }

        public PastMatch(CurrentMatch currentMatch) : base(currentMatch.DateTime, currentMatch.Venue, currentMatch.Pool)
        {
            WeighIns = new List<AnglerWeighIn>(currentMatch.WeighIns);
        }

        public string GetPlacement()
        {
            Predicate<AnglerWeighIn> predicate = FindAngler;
            int placement = WeighIns.FindIndex(predicate);
            
            if (placement == -1) return "Did Not Weigh In";
            
            placement++;
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
        
        public string GetWeight()
        {
            Predicate<AnglerWeighIn> predicate = FindAngler;
            AnglerWeighIn weighIn = WeighIns.Find(predicate);

            if (weighIn == null) return "Did Not Weigh In";
            return $"You Caught {weighIn.ToString()}";
        }

        private static bool FindAngler(AnglerWeighIn weighIn)
        {
            return weighIn.Angler == App.User;
        }
    }
}
