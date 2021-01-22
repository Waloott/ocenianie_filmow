using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class Program
    {
        static int Menu(string nick)
        {
            string wybor;
            ListaFilmow lfilm = null;
            try
            {
                lfilm = ListaFilmow.OdczytajXML("listafilmow_" + nick + ".xml");
            }
            catch (System.IO.FileNotFoundException)
            {
                lfilm = new ListaFilmow();
            }
            Console.WriteLine("1. Dodaj Film\n" +
                "2. Wyswietl liste Filmow\n" +
                "3. Zmodyfikuj ocene\n" +
                "4. Skopiuj liste filmow od innego uzytkownika\n" +
                "0. Zakoncz");
            wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1":
                    string nazwa, gatunek;
                    int ocena;
                    OcenaFilm.Gatunki gatEnum;
                    Console.WriteLine("Podaj tytul filmu: ");
                    nazwa = Console.ReadLine().ToUpper();
                    Console.WriteLine("Podaj gatunek filmu: ");
                    gatunek = Console.ReadLine().ToLower();
                    switch (gatunek)
                    {
                        case "thriller":
                            gatEnum = OcenaFilm.Gatunki.thriller;
                            break;
                        case "komedia":
                            gatEnum = OcenaFilm.Gatunki.komedia;
                            break;
                        case "dramat":
                            gatEnum = OcenaFilm.Gatunki.dramat;
                            break;
                        case "horror":
                            gatEnum = OcenaFilm.Gatunki.horror;
                            break;
                        case "akcja":
                            gatEnum = OcenaFilm.Gatunki.akcja;
                            break;
                        default:
                            gatEnum = OcenaFilm.Gatunki.inne;
                            break;
                    }
                    Console.WriteLine("Podaj ocene: ");
                    ocena = Convert.ToInt32(Console.ReadLine());
                    OcenaFilm o1 = new OcenaFilm(nazwa, gatEnum, ocena);
                    lfilm.DodajFilm(o1);
                    break;
                case "2":
                    Console.WriteLine(lfilm);
                    break;
                case "3":
                    Console.WriteLine("Twoja lista filmów\n" + lfilm);
                    string nazwa_szukana;
                    int ocena_nowa;
                    Console.WriteLine("Podaj tytul filmu ktorego ocene chcesz zmienic: ");
                    nazwa_szukana = Console.ReadLine().ToUpper();
                    Console.WriteLine("Podaj ocene na jaka chcesz zmienic: ");
                    ocena_nowa = Convert.ToInt32(Console.ReadLine());
                    lfilm.ZnajdzFilm(nazwa_szukana).Ocena = ocena_nowa;
                    break;
                case "4":
                    string user;
                    ListaFilmow lfilm_copy = null;
                    while (true)
                    {
                        Console.WriteLine("Podaj nick uzytkownika od ktorego chcesz skopiowac liste: (zeby wyjsc, podaj 0)");
                        user = Console.ReadLine().ToLower();
                        if (user == "0")
                        {
                            break;
                        }
                        try
                        {
                            lfilm_copy = ListaFilmow.OdczytajXML("listafilmow_" + user + ".xml");
                            lfilm = lfilm_copy.Clone() as ListaFilmow;
                            break;
                        }
                        catch (System.IO.FileNotFoundException)
                        {
                            Console.WriteLine("Nie ma takiego uzytkownika");
                            continue;
                        }
                    }
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Nie ma takiej opcji");
                    break;
            }
            lfilm.SortujPoNazwie();
            lfilm.ZapiszXML("listafilmow_" + nick + ".xml");
            return (Convert.ToInt32(wybor));
        }
        static void Main()
        {
            string nick;
            Console.WriteLine("Podaj nick: ");
            nick = Console.ReadLine().ToLower();
            while (Menu(nick) != 0) ;

        }
    }
}
