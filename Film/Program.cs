using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Program
    {


        static void Main()
        {
            ListaFilmow lf = new ListaFilmow();

            OcenaFilm oc = new OcenaFilm("Siema", Film.Gatunki.komedia, 5);
            OcenaFilm oc2 = new OcenaFilm("Siema2", Film.Gatunki.komedia, 5);
            lf.DodajFilm(oc);
            lf.ZapiszXML("eo.xml");

            ListaFilmow lf2 = ListaFilmow.OdczytajXML("eo.xml");
            Console.WriteLine(lf2.biblioteka[0]);
        }
    }
}
