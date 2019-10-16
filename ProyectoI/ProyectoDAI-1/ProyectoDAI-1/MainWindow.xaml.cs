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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoDAI_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public char adm = '.';
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

        private void BtFb_Click(object sender, RoutedEventArgs e)
        {
            Tablas w = new Tablas('f',adm == 'f',this);
            w.Show();
            this.Hide();
        }//buttonMethod

        private void BtBb_Click(object sender, RoutedEventArgs e)
        {
            Tablas w = new Tablas('b', adm == 'b', this);
            w.Show();
            this.Hide();
        }//buttonMethod

        private void BtTm_Click(object sender, RoutedEventArgs e)
        {
            Tablas w = new Tablas('t', adm == 't', this);
            w.Show();
            this.Hide();
        }//buttonMethod

        private void BtAj_Click(object sender, RoutedEventArgs e)
        {
            Tablas w = new Tablas('a', adm == 'a', this);
            w.Show();
            this.Hide();
        }//buttonMethod

        private void BtFa_Click(object sender, RoutedEventArgs e)
        {
            Tablas w = new Tablas('r', adm == 'r', this);
            w.Show();
            this.Hide();
        }//buttonMethod

        private void BtVb_Click(object sender, RoutedEventArgs e)
        {
            Tablas w = new Tablas('v', adm == 'v', this);
            w.Show();
            this.Hide();
        }//buttonMethod

        private void BtEs_Click(object sender, RoutedEventArgs e)
        {
            Tablas w = new Tablas('e', adm == 'e', this);
            w.Show();
            this.Hide();
        }//buttonMethod

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login w = new Login(this);
            w.Show();            
        }//buttonMethod
    }
}
