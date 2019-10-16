using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Lógica de interacción para Baja.xaml
    /// </summary>
    public partial class Baja : Window
    {
        Alta ventanaAlta;
        public Baja(Alta a)
        {
            ventanaAlta = a;
            InitializeComponent();
        }

        private void btBaja_Click(object sender, RoutedEventArgs e)
        {
            Alumno a = new Alumno();
            int r = a.eliminar(int.Parse(TxBaja.Text));
        }//buttonMethod

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            ventanaAlta.Show();
            this.Close();
        }//buttonMethod
    }//class
}//namespace
