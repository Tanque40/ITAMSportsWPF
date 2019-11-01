using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoDAI_1
{
    class Conexion
    {
        private SqlCommand cmd;
        private SqlDataReader rd;

        public static SqlConnection conectar()
        {
            SqlConnection cnn;
            try
            {
                cnn = new SqlConnection("Data Source=DESKTOP-I4BI3PH;Initial Catalog=ITAMSports;Integrated Security=True");
                cnn.Open();
                //MessageBox.Show("Se conectó a la base de datos correctamente");
            }//try
            catch (Exception ex)
            {
                cnn = null;
                MessageBox.Show("No se pudo hacer la conexión a la base de datos: " + ex);
            }//catch


            return cnn;
        }//method

        public static int comprobarPwd(string usuario, string contra)
        {
            SqlConnection con = conectar();
            if (con != null)
            {
                SqlDataReader rd;
                SqlCommand cmd = new SqlCommand(/*Cadena con el comando*/String.Format("select passwd from Administrador where usuario = '{0}'", /*tabla*/usuario),/*conexión a la tabla*/con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {

                    if (rd.GetString(0).Equals(contra))
                        return 1;//usuario y contraseña correctos
                    else
                        return 2;//contraseña incorrecta
                }//if
                else
                    return 0;//usuario incorrecto
                rd.Close();
            }//if
            else
                return -1;//conexion con la base de datos fallida
        }//method

        public static List<Miembro> llenarDgMiembros(char dep)
        {
            List<Miembro> l = new List<Miembro>();
            SqlDataReader rd;
            Miembro m;
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select nombre, rol, jugados, ganados, perdidos, Jugador.claveUnica from Jugador inner join TieneDepJug on Jugador.claveUnica = TieneDepJug.claveUnica inner join Datos on Jugador.claveUnica = Datos.claveUnica where idDep = '{0}'", dep), con);
                rd = cmd.ExecuteReader(); //#de registros afectados
                while (rd.Read())
                {
                    m = new Miembro();                    
                    m.nombre = rd.GetString(0);
                    m.rol = rd.GetString(1);
                    m.jugados = rd.GetInt16(2);
                    m.ganados = rd.GetInt16(3);
                    m.perdidos = rd.GetInt16(4);
                    m.claveU = rd.GetInt16(5);
                    l.Add(m);
                }//while
                con.Close();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al llenar el data grid con los miembros: " + ex.ToString());
            }//catch

            return l;
        }//method

        public static List<Evento> llenarDgEventos(char dep)
        {
            List<Evento> l = new List<Evento>();
            SqlDataReader rd;
            Evento e;
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select idDep, fecha, hora, lugar, descripcion, idEvento from Evento where idDep = '{0}'", dep), con);
                rd = cmd.ExecuteReader(); //#de registros afectados
                while (rd.Read())
                {
                    e = new Evento();
                    e.idDep = rd.GetString(0)[0];
                    e.fecha = rd.GetDateTime(1).ToShortDateString();
                    e.hora = rd.GetTimeSpan(2).ToString();
                    e.lugar = rd.GetString(3);
                    e.descripcion = rd.GetString(4);
                    e.idEv = rd.GetInt16(5);
                    l.Add(e);
                    Console.WriteLine();
                }//while
                con.Close();
            }//try
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el data grid con los eventos: " + ex.ToString());
            }//catch

            return l;
        }//method

        public static List<Equipo> llenarDgEquipos(char dep)
        {
            List<Equipo> l = new List<Equipo>();
            SqlDataReader rd;
            Equipo e;
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select idEquipo, ganados, perdidos, jugados, nombre from Equipo where idDep = '{0}'", dep), con);
                rd = cmd.ExecuteReader(); //#de registros afectados
                while (rd.Read())
                {
                    e = new Equipo();
                    e.idEquipo = rd.GetInt16(0);
                    e.ganados = rd.GetInt16(1);
                    e.perdidos = rd.GetInt16(2);
                    e.jugados = rd.GetInt16(3);
                    e.nombre = rd.GetString(4);
                    l.Add(e);
                }//while
                con.Close();
            }//try
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el data grid con los eventos: " + ex.ToString());
            }//catch

            return l;
        }//method

        public static char encuentraDep(string usuario)
        {
            char res;
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select idDep from Deporte where usuario ='{0}'", usuario),con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                    res = rd.GetString(0)[0];
                else
                    res = '.';
            }//try
            catch(Exception ex)
            {
                res = '.';
                MessageBox.Show("Error el encontrar el deporte del administrador: " + ex.ToString());
            }//catch
            return res;
        }//method

        public static List<string> deps()
        {
            List<string> res = new List<string>();
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand("select nombre from Deporte order by nombre", con);
                SqlDataReader rd = cmd.ExecuteReader();                
                while (rd.Read())
                {
                    res.Add(rd.GetString(0));                    
                }//while
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al buscar los deportes disponibles: \n" + ex.ToString());
            }//catch
            return res;
        }//method

        //Este metodo recibe el string de la tabla en la que tiene que buscar el siguiente id disponible
        public static int topId(string tabla)
        {
            int res;
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select top 1 id{0} from {0} order by id{0} desc ", tabla), con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                res = rd.GetInt16(0) + 1;
            }//try
            catch(Exception ex)
            {
                res = 0;
                MessageBox.Show("Error al buscar el topID en la tabla "+tabla+": " + ex);
            }//catch

            return res;
        }//method

        /*public void llenarComboAlta(ComboBox cb)
        {
            try
            {
                SqlConnection con = conectar();
                cmd = new SqlCommand("select nombre from programa", con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cb.Items.Add(rd["nombre"].ToString());
                }//while
                cb.SelectedIndex = 0;
                rd.Close();
                con.Close();
            }//try
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el combo" + ex);
            }//catch

        }//method
        */

        }//class
    }//namespace
