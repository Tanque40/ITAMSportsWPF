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
    /// Interaction logic for AltaJugEquipo.xaml
    /// </summary>
    public partial class AltaJugEquipo : Window
    {
        public AltaJugEquipo(char dep)
        {
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
                SqlCommand cmd = new SqlCommand(String.Format("insert into EquipoJugador values ({0}, {1})", TxClaveU.Text, TxIdEquipo.Text), con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Alta exitosa");
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al dar de alta el Miembro/Jugador al equipo: " + ex);
            }//catch
        }//buttonMethod

        private void BtBaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("delete from EquipoJugador where idEquipo = {0} and claveUnica = {1}", TxClaveU.Text, TxIdEquipo.Text), con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Baja exitosa");
            }//try
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja el Miembro/Jugador al equipo: " + ex);
            }//catch
        }
    }//class
}//namespace
