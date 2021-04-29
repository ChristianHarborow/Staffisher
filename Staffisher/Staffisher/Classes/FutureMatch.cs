using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class FutureMatch : Match
    {
        public List<Angler> Attending { get; }
        public List<Angler> NotAttending { get; }
        
        public FutureMatch(DateTime dateTime, string venue, string pool) : base(dateTime, venue, pool)
        {
            Attending = new List<Angler>();
            NotAttending = new List<Angler>();
        }

        public string IsAnglerAttending()
        {
            if (Attending.Contains(App.User)) return "Attending";
            if (NotAttending.Contains(App.User)) return "Not Attending";
            return "";
        }

        public void SetAnglerAttendance(bool isAttending)
        {
            if (isAttending)
            {
                NotAttending.Remove(App.User);
                Attending.Add(App.User);
            }
            else
            {
                Attending.Remove(App.User);
                NotAttending.Add(App.User);
            }
        }
    }
}
