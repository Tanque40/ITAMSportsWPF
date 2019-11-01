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

namespace PruebaEx
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {           
            InitializeComponent();
        }//builder

        private void BtRegistro_Click(object sender, RoutedEventArgs e)
        {
            Int16 id = Convert.ToInt16(Conexion.topIdPersona());
            Persona p = new Persona(TxNombre.Text, TxCorreo.Text, id);
            p.alta(p, Convert.ToInt16(TxHoras.Text), CbEstado.SelectedIndex);
        }//methodButton

        private void BtRegistro_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion.llenaCbEstado(CbEstado);
            CbEstado.SelectedIndex = 0;
        }//load

        private void BtModificar_Click(object sender, RoutedEventArgs e)
        {
            Ventana2 v = new Ventana2();
            v.Show();
            this.Close();
        }//buttonMethod

        private void BtReporte_Click(object sender, RoutedEventArgs e)
        {
            Ventana3 w = new Ventana3();
            w.Show();
            this.Close();
        }//buttonMethod
    }//class
}//namespace
