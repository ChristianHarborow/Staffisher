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

        public static PoundsAndOunces operator +(PoundsAndOunces x, PoundsAndOunces y)
        {
            PoundsAndOunces c = new PoundsAndOunces
            {
                Pounds = x.Pounds + y.Pounds,
                Ounces = x.Ounces + y.Ounces
            };
            return c;
        }

        public static PoundsAndOunces operator /(PoundsAndOunces x, int y)
        {
            double pounds = x.Pounds;
            double ounces = x.Ounces;
            pounds /= y;
            ounces /= y;
            ounces += (pounds % 1) * 16;
            pounds = Math.Floor(pounds);
            ounces = Math.Floor(ounces);
            return new PoundsAndOunces((int)pounds, (int)ounces);
        }

        public override string ToString()
        {
            return $"{Pounds} lb {ounces} oz";
        }

        public int CompareTo(object obj)
        {
            PoundsAndOunces other = (PoundsAndOunces)obj;

            if (Pounds.CompareTo(other.Pounds) < 0)  return -1;
            else if (Pounds.CompareTo(other.Pounds) > 0) return 1;
            else return Ounces.CompareTo(other.Ounces);
        }

        public static bool operator <(PoundsAndOunces x, PoundsAndOunces y)
        {
            return x.CompareTo(y) < 0;
        }

        public static bool operator >(PoundsAndOunces x, PoundsAndOunces y)
        {
            return x.CompareTo(y) > 0;
        }
    }
}