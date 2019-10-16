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
    /// Lógica de interacción para Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        public Alta()
        {
            InitializeComponent();
        }//builder

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion con = new Conexion();
            con.llenarComboAlta(cbProgramas);
        }//loadMethod

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Baja w = new Baja(this);
            w.Show();            
        }//buttonMethod

        private void btAgregar_Click(object sender, RoutedEventArgs e)
        {
            int res;

            Alumno a = new Alumno(txNombre.Text, txSexo.Text, txCorreo.Text, Int16.Parse(txClaveUnica.Text), Int16.Parse(txSemestre.Text), cbProgramas.SelectedIndex);
            res = a.agregar(a);
            if (res > 0)
                MessageBox.Show("Alumno registrado correctamente");
            else
                MessageBox.Show("No se pudo dar de alta al alumno");
        }//buttonMethod

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Buscar w = new Buscar(this);
            w.Show();
        }//buttonMethod

        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Modificar w = new Modificar(this);
            w.Show();
        }//method

        private void btSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod
    }//class
}//namespace
