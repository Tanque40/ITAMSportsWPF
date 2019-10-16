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
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        private Alta ventanaAlta;
        public Modificar(Alta a)
        {
            ventanaAlta = a;
            InitializeComponent();
        }//builder

        private void tbModificar_Click(object sender, RoutedEventArgs e)
        {
            Alumno a = new Alumno(Convert.ToInt16(TxClaveU.Text), TxCorreo.Text);
            int r = a.modificar(a);
        }//buttonMethod

        private void tbRegresar_Click(object sender, RoutedEventArgs e)
        {
            ventanaAlta.Show();
            this.Close();
        }//buttonMethod

    }//class
}//namespace
