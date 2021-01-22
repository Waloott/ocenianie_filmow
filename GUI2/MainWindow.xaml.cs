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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListaFilmow lista = new ListaFilmow();
        

        public MainWindow()
        {
            InitializeComponent();
            lista = ListaFilmow.OdczytajXML("Lista.xml");
            lbFilmy.ItemsSource = new ObservableCollection<OcenaFilm>(lista.biblioteka);
            cbGatunek.ItemsSource = Film.Gatunki.GetValues(typeof(Film.Gatunki));
            cbOcena.ItemsSource = Enumerable.Range(1, 10);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OcenaFilm nowy = new OcenaFilm();
            nowy.Tytul = tbTytul.Text;
            nowy.Ocena = Int32.Parse(cbOcena.Text);
            nowy.DataDodania = DateTime.Now;
            switch (cbGatunek.Text)
            {
                case "horror":
                    nowy.Gatunek = Film.Gatunki.horror;
                    break;
                case "komedia":
                    nowy.Gatunek = Film.Gatunki.komedia;
                    break;
                case "inne":
                    nowy.Gatunek = Film.Gatunki.inne;
                    break;
                case "akcja":
                    nowy.Gatunek = Film.Gatunki.akcja;
                    break;
                case "thriller":
                    nowy.Gatunek = Film.Gatunki.thriller;
                    break;
                case "dramat":
                    nowy.Gatunek = Film.Gatunki.dramat;
                    break;
            }


            lista.DodajFilm(nowy);
            lbFilmy.ItemsSource = new ObservableCollection<OcenaFilm>(lista.biblioteka);
            lbZapisano.Content = "";
        }

        private void cbGatunek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btZapisz_Click(object sender, RoutedEventArgs e)
        {
            lista.ZapiszXML("Lista.xml");
            lbZapisano.Content = "Zapisano!";
        }

        private void btUsun_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = lbFilmy.SelectedIndex;
            if (zaznaczony >= 0)
            {
                lista.biblioteka.RemoveAt(zaznaczony);
                lbFilmy.ItemsSource = new ObservableCollection<OcenaFilm>(lista.biblioteka);
            }
            lbZapisano.Content = "";
        }

        private void cbSortuj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btSortuj_Click(object sender, RoutedEventArgs e)
        {
            switch(cbSortuj.Text)
            {
                case "Nazwa":
                    lista.SortujPoNazwie();
                    lbFilmy.ItemsSource = new ObservableCollection<OcenaFilm>(lista.biblioteka);
                    break;
                case "Najgorsze":
                    lista.SortujPoOcena();
                    lbFilmy.ItemsSource = new ObservableCollection<OcenaFilm>(lista.biblioteka);
                    break;
                case "Najlepsze":
                    lista.SortujPoOcena();
                    lista.biblioteka.Reverse();
                    lbFilmy.ItemsSource = new ObservableCollection<OcenaFilm>(lista.biblioteka);
                    break;
                case "Gatunek":
                    lista.SortujPoGatunku();
                    lbFilmy.ItemsSource = new ObservableCollection<OcenaFilm>(lista.biblioteka);
                    break;

            }
        }

        private void lbFilmy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int zaznaczony = lbFilmy.SelectedIndex;
            OknoFilm of = new OknoFilm(lista.biblioteka[zaznaczony]);
            of.Show();

        }
    }
}
