using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    class FutureMatchSummary : MatchSummary
    {
        public string UserAttending { get; set; }
        public int Going { get; set; }
        public int NotGoing { get; set; }

        public FutureMatchSummary()
        {

        }
    }
}
