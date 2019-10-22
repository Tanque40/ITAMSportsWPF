using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProyectoDAI_1
{
    /// <summary>
    /// Interaction logic for Tablas.xaml
    /// </summary>
    public partial class Tablas : Window
    {
        char deporte;
        bool admin;
        MainWindow inicio;
        public Tablas(char tipo, bool adm, MainWindow m)
        {
            inicio = m;
            
            deporte = tipo;
            admin = adm;
            
            InitializeComponent();
        }//builder

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (deporte)
            {
                case 'v'://volleyball
                    {
                        ImgVolleyball.Visibility = Visibility.Visible;
                        LbVolleyBall.Visibility = Visibility.Visible;
                    }//case
                    break;
                case 'f'://football
                    {
                        ImgFootball.Visibility = Visibility.Visible;
                        LbFootball.Visibility = Visibility.Visible;
                    }//case
                    break;
                case 't'://tenis de mesa
                    {
                        ImgPingPong.Visibility = Visibility.Visible;
                        LbPingPong.Visibility = Visibility.Visible;
                    }//case
                    break;
                case 'e'://esports
                    {
                        ImgEsports.Visibility = Visibility.Visible;
                        LbEsports.Visibility = Visibility.Visible;
                    }//case
                    break;
                case 'a'://ajedrez
                    {
                        ImgAjedrez.Visibility = Visibility.Visible;
                        LbAjedrez.Visibility = Visibility.Visible;
                    }//case
                    break;
                case 'r'://football arena
                    {
                        ImgArena.Visibility = Visibility.Visible;
                        LbArena.Visibility = Visibility.Visible;
                    }//case
                    break;
                case 'b'://basketball
                    {
                        ImgBasket.Visibility = Visibility.Visible;
                        LbBasket.Visibility = Visibility.Visible;
                    }//case
                    break;
                case 'x'://administrador del programa
                    break;
                default:
                    MessageBox.Show("Error al accesar el deporte");
                    break;
            }//switch
            if (admin)
            {
                BtEventos.IsEnabled = true;
                BtMiembros.IsEnabled = true;
                BtEventos.Visibility = Visibility.Visible;
                BtMiembros.Visibility = Visibility.Visible;
            }//if
            DgMiembros.ItemsSource = Conexion.llenarDgMiembros(deporte);
            DgEventos.ItemsSource = Conexion.llenarDgEventos(deporte);
        }//load

        private void BtMiembros_Click(object sender, RoutedEventArgs e)
        {

        }//buttonMethod

        private void BtEventos_Click(object sender, RoutedEventArgs e)
        {

        }//buttonMethod

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inicio.Show();
            this.Close();
        }//buttonMethod
    }//class
}//namespace
