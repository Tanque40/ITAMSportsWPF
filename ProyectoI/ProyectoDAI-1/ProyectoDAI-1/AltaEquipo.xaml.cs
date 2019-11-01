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

namespace ProyectoDAI_1
{
    /// <summary>
    /// Interaction logic for AltaEquipo.xaml
    /// </summary>
    public partial class AltaEquipo : Window
    {
        char dep;
        public AltaEquipo(char deporte)
        {
            dep = deporte;
            InitializeComponent();
        }//builder

        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

        private void BtAlta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("insert into Equipo values({0}, '{1}', {2}, {3}, {4}, '{5}')", Conexion.topId("Evento"), TxNombre.Text, 0, 0, 0, dep), con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Alta exitosa");
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al dar de alta el Equipo: " + ex);
            }//catch
        }//buttonMethod
    }//class
}//namespace
