using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projekt;

namespace GUI2
{
    /// <summary>
    /// Logika interakcji dla klasy DodawanieFilmu.xaml
    /// </summary>
    public partial class DodawanieFilmu : Window
    {
        public DodawanieFilmu(OcenaFilm nowy)
        {

            InitializeComponent();
            nowy.Tytul = tbTytul.Text;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void btDodaj_Click(object sender, RoutedEventArgs e)
        {
            
        }
         
        private void btAnuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
