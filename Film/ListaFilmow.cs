using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    [Serializable]
    public class ListaFilmow : IZapisywalna, ICloneable
    {

   
        int liczbaFilmow;

        public int LiczbaFilmow { get => liczbaFilmow; set => liczbaFilmow = value; }

        public DateTime dataDodania { get; set; }
        public List<OcenaFilm> biblioteka { get; set; }



        public ListaFilmow()
        {
            liczbaFilmow = 0;
            biblioteka = new List<OcenaFilm>();
        }

        public void DodajFilm(OcenaFilm f)
        {
            this.biblioteka.Add(f);
            liczbaFilmow++;
        }

        public OcenaFilm ZnajdzFilm(string nazwa)
        {
            return biblioteka.Find(c => c.Tytul.ToUpper() == nazwa.ToUpper());
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (OcenaFilm f in biblioteka)
                stringBuilder.AppendLine(f.ToString());
            return stringBuilder.ToString();
        }

        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ListaFilmow));
                serializer.Serialize(writer, this);
            }
        }

        public static ListaFilmow OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ListaFilmow));
                return serializer.Deserialize(reader) as ListaFilmow;
            }
        }

        public void SortujPoOcena()
        {
            biblioteka.Sort();
        }

        public void SortujPoNazwie()
        {
            biblioteka.Sort(new OcenaComparator());
        }
        public void SortujPoGatunku()
        {
            biblioteka.Sort(new GatunekComparator());
        }
        public object Clone()
        {
            ListaFilmow klon = this.MemberwiseClone() as ListaFilmow;
            klon.biblioteka = new List<OcenaFilm>();
            foreach (OcenaFilm film_oceniony in biblioteka)
                klon.biblioteka.Add(film_oceniony.Clone() as OcenaFilm);
            return klon;
        }
    }
}
