using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    class FutureMatch : Match
    {
        List<Angler> Attending { get; }
        List<Angler> NotAttending { get; }
        
        public FutureMatch(string venue, string pool, DateTime dateTime) : base(venue, pool, dateTime)
        {
            Attending = new List<Angler>();
            NotAttending = new List<Angler>();
        }

        public string IsAnglerAttending(Angler angler)
        {
            if (Attending.Contains(angler)) return "Attending";
            if (NotAttending.Contains(angler)) return "Not Attending";
            return "";
        }

        public void SetAnglerAttendance(Angler angler, bool isAttending)
        {
            if (isAttending)
            {
                NotAttending.Remove(angler);
                Attending.Add(angler);
            }
            else
            {
                Attending.Remove(angler);
                NotAttending.Add(angler);
            }
        }
    }
}
