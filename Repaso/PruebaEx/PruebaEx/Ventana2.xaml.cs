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

namespace PruebaEx
{
    /// <summary>
    /// Interaction logic for Ventana2.xaml
    /// </summary>
    public partial class Ventana2 : Window
    {
        public Ventana2()
        {
            InitializeComponent();
        }//builder

        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }//buttonMethod

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion.llenaCbCursos(CbCursos);
        }//load

        private void BtCambio_Click(object sender, RoutedEventArgs e)
        {
            Curso c = new Curso();
            c.modificaHoras(Convert.ToInt32(TxHoras.Text), Convert.ToInt32(CbCursos.SelectedItem));
        }//buttonMethod
    }//class
}//namespace
