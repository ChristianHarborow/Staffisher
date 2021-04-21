using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class PoundsAndOunces : IComparable
    {
        private int ounces;

        public int Pounds { get; set; }
        public int Ounces
        {
            get { return ounces; }
            set
            {
                ounces = value;
                Pounds += ounces / 16;
                ounces %= 16;
            }
        }

        public PoundsAndOunces()
        {
            Pounds = 0;
            Ounces = 0;
        }

        public PoundsAndOunces(int pounds, int ounces)
        {
            Pounds = pounds;
            Ounces = ounces;
        }

        public static PoundsAndOunces operator +(PoundsAndOunces a, PoundsAndOunces b)
        {
            PoundsAndOunces c = new PoundsAndOunces
            {
                Pounds = a.Pounds + b.Pounds,
                Ounces = a.Ounces + b.Ounces
            };
            return c;
        }

        public override string ToString()
        {
            return $"{Pounds} lb {ounces} oz";
        }

        public int CompareTo(object obj)
        {
            PoundsAndOunces other = (PoundsAndOunces)obj;

            if (Pounds.CompareTo(other.Pounds) < 0)
            {
                return -1;
            }
            else if (Pounds.CompareTo(other.Pounds) > 0)
            {
                return 1;
            }
            else
            {
                return Ounces.CompareTo(other.Ounces);
            }
        }
    }
}
