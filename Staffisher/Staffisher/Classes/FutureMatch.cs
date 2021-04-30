using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class FutureMatch : Match
    {
        public List<Angler> Attending { get; set; }
        public List<Angler> NotAttending { get; set; }

        public FutureMatch(DateTime dateTime, string venue, string pool) : base(dateTime, venue, pool)
        {
            Attending = new List<Angler>();
            NotAttending = new List<Angler>();
        }

        public string IsAnglerAttending()
        {
            if (ContainsUser(Attending)) return "Attending";
            if (ContainsUser(NotAttending)) return "Not Attending";
            return "";
        }

        private bool ContainsUser(List<Angler> list)
        {
            //After deserialization seperate references of the same object are no longer the same so must check email (unique)
            foreach (Angler angler in list)
            {
                if (angler.Email == App.User.Email) return true;
            }

            return false;
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
