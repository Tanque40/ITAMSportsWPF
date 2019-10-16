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

namespace SistemaAlumnos
{
    /// <summary>
    /// Lógica de interacción para Buscar.xaml
    /// </summary>
    public partial class Buscar : Window
    {
        Alta ventanaAlta;
        public Buscar(Alta a)
        {
            ventanaAlta = a;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Alumno a = new Alumno();            
            dgDatos.ItemsSource = a.buscar(TxNombre.Text);
        }//buttonMethod

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ventanaAlta.Show();
            this.Close();            
        }//buttonMethod
    }//class
}//namespace
