 using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    /// <summary>
    /// Abstrakcyjna klasa odpowiadająca filmowi w naszym systemie
    /// </summary>
    public abstract class Film
    {
        /// <summary>
        /// Gatunki filmowe typu enum
        /// </summary>
        public enum Gatunki { akcja, dramat, horror, komedia, thriller, inne };

        string tytul;
        /// <summary>
        /// zmienna gatunek typu Gatunki (które są enumem)
        /// </summary>
        public Gatunki gatunek;
        /// <summary>
        /// Hermetyzacja tytulu filmu
        /// </summary>
        public string Tytul { get => tytul; set => tytul = value; }
        /// <summary>
        /// Hermetyzacja Gatunku
        /// </summary>
        public Gatunki Gatunek { get => gatunek; set => gatunek = value; }
        /// <summary>
        /// Pusty konstruktor
        /// </summary>
        protected Film() { }
        /// <summary>
        /// Konstruktor Filmu
        /// </summary>
        /// <param name="tytul">Tytuł filmu</param>
        /// <param name="gatunek">Gatunek filmu</param>
        protected Film(string tytul, Gatunki gatunek)
        {
            this.tytul = tytul;
            this.gatunek = gatunek;
        }
    }
}
