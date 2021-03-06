using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class WeighIn
    {
        public Angler Angler { get; set; }
        public PoundsAndOunces Weight { get; set; }
        public int Placement { get; set; }

        public WeighIn(Angler angler, PoundsAndOunces weight)
        {
            Angler = angler;
            Weight = weight;
        }

        public override string ToString()
        {
            return Weight.ToString();
        }
    }
}
