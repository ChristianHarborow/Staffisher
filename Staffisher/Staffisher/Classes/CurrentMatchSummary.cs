using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    class CurrentMatchSummary : MatchSummary
    {
        public List<AnglerWeighIn> AnglersWeighedIn { get; set; }
        public bool HasWeighedIn { get; set; }

        public CurrentMatchSummary()
        {

        }
    }
}
