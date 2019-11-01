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
    /// Interaction logic for ModificaEvento.xaml
    /// </summary>
    public partial class ModificaEvento : Window
    {
        int idEvento;
        public ModificaEvento(int idEv)
        {
            idEvento = idEv;
            InitializeComponent();
        }//builder

        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

        private void BtModificar_Click(object sender, RoutedEventArgs e)
        {
            string fecha, hora, lugar, descripcion;
            fecha = TxFecha.Text;
            hora = TxHora.Text;
            lugar = TxLugar.Text;
            descripcion = TxDescripcion.Text;
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("update Evento set hora = '{0}', lugar = '{1}', descripcion = '{2}' where idEvento = {3}", hora, lugar, descripcion, idEvento), con);
                cmd.ExecuteNonQuery();
                con.Close();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al modificar el evento: " + ex);
            }//catch
        }//buttonMethod

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select fecha, hora, lugar, descripcion from Evento where idEv = {0}", idEvento), con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                TxFecha.Text = rd.GetDateTime(0).ToShortDateString();
                TxHora.Text = rd.GetTimeSpan(1).ToString();
                TxLugar.Text = rd.GetString(2);
                TxDescripcion.Text = rd.GetString(3);
                rd.Close();
                con.Close();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al buscar la información del evento: " + ex);
            }//catch
        }//load
    }
}
