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
    /// Lógica de interacción para AltaDatos.xaml
    /// </summary>
    public partial class AltaDatos : Window
    {
        char opc, dep;
        public AltaDatos(char deporte, char opcion)
        {
            dep = deporte;
            opc = opcion;
            InitializeComponent();
        }

        private void BtActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (opc == 'q')//si se estan modificando los datos de un equipo
            {
                try
                {
                    int cu = Convert.ToInt32(TxClaveU.Text),
                        gan = Convert.ToInt32(TxGan.Text),
                        perd = Convert.ToInt32(TxPerd.Text),
                        emp = Convert.ToInt32(TxEmp.Text),
                        jug = gan + perd + emp;
                    SqlConnection con = Conexion.conectar();
                    SqlCommand cmd = new SqlCommand(String.Format("update Equipo set nombre = '{0}', jugados = {1}, ganados = {2}, perdidos = {3} where idEquipo = {4}", TxNombre.Text, jug, gan, perd, Convert.ToInt32(TxClaveU.Text)), con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Información actualizada");

                }//try
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la informacion del Jugador/Miembro: " + ex);
                }//catch
            }//if
            else//si se estan modificando los datos de un Miembro/Jugador
            {
                try
                {
                    int cu = Convert.ToInt32(TxClaveU.Text),
                        gan = Convert.ToInt32(TxGan.Text),
                        perd = Convert.ToInt32(TxPerd.Text),
                        emp = Convert.ToInt32(TxEmp.Text),
                        jug = gan + perd + emp;
                    SqlConnection con = Conexion.conectar();
                    SqlCommand cmd = new SqlCommand(String.Format("update Datos set rol = '{0}', jugados = {1}, ganados = {2}, perdidos = {3} where claveUnica = {4}", TxRol.Text, jug, gan, perd, Convert.ToInt32(TxClaveU.Text)), con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Información actualizada");

                }//try
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la informacion del Jugador/Miembro: " + ex);
                }//catch
            }
        }//buttonMethod

        private void BtBusca_Click(object sender, RoutedEventArgs e)
        {
            if (opc == 'q')
            {
                try
                {
                    SqlConnection con = Conexion.conectar();
                    SqlCommand cmd = new SqlCommand(String.Format("select nombre, ganados, perdidos, jugados from Equipo where idEquipo = {0}", Convert.ToInt32(TxClaveU.Text)), con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    TxNombre.Text = rd.GetString(0);
                    int gan, perd, jug, empatados;
                    gan = rd.GetInt16(1);
                    perd = rd.GetInt16(2);
                    jug = rd.GetInt16(3);                    
                    rd.Close();
                    empatados = jug - (gan + perd);
                    TxGan.Text = gan.ToString();
                    TxPerd.Text = perd.ToString();
                    TxEmp.Text = empatados.ToString();
                    con.Close();
                    BtActualizar.Visibility = Visibility.Visible;
                }//try
                catch(Exception ex)
                {
                    MessageBox.Show("Error al buscar el equipo: " + ex);
                }//catch
            }//if
            else {
                try
                {
                    SqlConnection con = Conexion.conectar();
                    SqlCommand cmd = new SqlCommand(String.Format("select nombre, ganados, perdidos, jugados, rol from Jugador inner join Datos on Jugador.claveUnica = Datos.claveUnica where Jugador.claveUnica = {0}", Convert.ToInt32(TxClaveU.Text)), con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    TxNombre.Text = rd.GetString(0);
                    int gan, perd, jug, empatados;
                    gan = rd.GetInt16(1);
                    perd = rd.GetInt16(2);
                    jug = rd.GetInt16(3);
                    TxRol.Text = rd.GetString(4);
                    rd.Close();
                    empatados = jug - (gan + perd);
                    TxGan.Text = gan.ToString();
                    TxPerd.Text = perd.ToString();
                    TxEmp.Text = empatados.ToString();
                    con.Close();
                    BtActualizar.Visibility = Visibility.Visible;
                }//try
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el Miembro/Jugador: " + ex);
                    BtActualizar.Visibility = Visibility.Hidden;
                }//catch
            }//else
        }//method

        private void BtGanMas_Click(object sender, RoutedEventArgs e)
        {
            TxGan.Text = (Convert.ToInt32(TxGan.Text) + 1).ToString();

        }//buttonMethod

        private void BtGanMenos_Click(object sender, RoutedEventArgs e)
        {
            TxGan.Text = (Convert.ToInt32(TxGan.Text) - 1).ToString();
        }//buttonMethod

        private void BtPerdMas_Click(object sender, RoutedEventArgs e)
        {
            TxPerd.Text = (Convert.ToInt32(TxPerd.Text) + 1).ToString();
        }//buttonMethod

        private void BtPerdMenos1_Click(object sender, RoutedEventArgs e)
        {
            TxPerd.Text = (Convert.ToInt32(TxPerd.Text) - 1).ToString();
        }//buttonMethod

        private void BtEmpMas_Click(object sender, RoutedEventArgs e)
        {
            TxEmp.Text = (Convert.ToInt32(TxEmp.Text) + 1).ToString();
        }//buttonMethod

        private void BtEmMenos_Click(object sender, RoutedEventArgs e)
        {
            TxEmp.Text = (Convert.ToInt32(TxEmp.Text) - 1).ToString();
        }//ButtonMethod

        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (opc == 'q')
            {
                lbCU.Content = "IdEquipo";
                lbRol.Visibility = Visibility.Hidden;
                TxRol.Visibility = Visibility.Hidden;
                BtAltaJug.IsEnabled = true;
                BtAltaJug.Visibility = Visibility.Visible;
            }//if
            else
            {
                BtActualizar.IsEnabled = true;
                BtActualizar.Visibility = Visibility.Visible;
            }//else
        }//load

        private void BtAltaJug_Click(object sender, RoutedEventArgs e)
        {
            AltaJugEquipo a = new AltaJugEquipo(dep);
            a.Show();
            this.Close();
        }//buttonMethod
    }//class
}//namespace
