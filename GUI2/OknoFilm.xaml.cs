using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projekt;

namespace GUI2
{
    /// <summary>
    /// Logika interakcji dla klasy OknoFilm.xaml
    /// </summary>
    public partial class OknoFilm : Window
    {
        public OknoFilm(OcenaFilm film)
        {
            InitializeComponent();
            lbTytul.Content = film.Tytul;
            lbOcena.Content = film.Ocena;
            lbData.Content = film.DataDodania;
            lbGatunek.Content = film.Gatunek;

        }
    }
}
