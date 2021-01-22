using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class GatunekComparator : Comparer<OcenaFilm>
    {
        public override int Compare(OcenaFilm x, OcenaFilm y)
        {
            return x.Gatunek.CompareTo(y.Gatunek);
        }
    }
    class OcenaComparator : Comparer<OcenaFilm>
    {
        public override int Compare(OcenaFilm x, OcenaFilm y)
        {
            return x.Tytul.CompareTo(y.Tytul);
        }
    }
    [Serializable]
    public class OcenaFilm : Film, IComparable<OcenaFilm>, ICloneable
    {
        int ocena;
        DateTime dataDodania = DateTime.Now;


        public int Ocena { get => ocena; set => ocena = value; }
        public DateTime DataDodania { get => dataDodania; set => dataDodania = value; }

        public OcenaFilm()
        {

        }
        public OcenaFilm(string Tytul, Gatunki Gatunek, int ocena) : base(Tytul, Gatunek)
        {
            this.ocena = ocena;
        }

        public override string ToString()
        {
            return Tytul + " " + Gatunek + " Ocena: " + ocena;
        }
        public int CompareTo(OcenaFilm other)
        {
            return this.Ocena.CompareTo(other.Ocena);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
