using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    class FutureMatchSummary : MatchSummary
    {
        public string Attending { get; set; }
        public string Going { get; set; }
        public string MaybeGoing { get; set; }
        public string NotGoing { get; set; }

        public FutureMatchSummary()
        {

        }
    }
}
