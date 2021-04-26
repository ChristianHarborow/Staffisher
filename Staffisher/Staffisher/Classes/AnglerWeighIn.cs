using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    class AnglerWeighIn
    {
        public Angler Angler { get; set; }
        public PoundsAndOunces Weight { get; set; }
        public int Position { get; set; }

        public AnglerWeighIn(Angler angler, PoundsAndOunces weight)
        {
            Angler = angler;
            Weight = weight;
        }
    }
}
