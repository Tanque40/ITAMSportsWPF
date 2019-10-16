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
                MessageBox.Show("Se conectó a la base de datos correctamente");
            }//try
            catch (Exception ex)
            {
                cnn = null;
                MessageBox.Show("No se pudo hacer la conexión: " + ex);
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
                SqlCommand cmd = new SqlCommand(String.Format("select nombre, rol, jugados, ganados, perdidos from Jugador inner join TieneDepJug on Jugador.claveUnica = TieneDepJug.claveUnica inner join Datos on Jugador.claveUnica = Datos.claveUnica where idDep = '{0}'", dep), con);
                rd = cmd.ExecuteReader(); //#de registros afectados
                while (rd.Read())
                {
                    m = new Miembro();
                    m.claveU = Convert.ToInt16(rd.GetString(0));
                    m.nombre = rd.GetString(1);
                    //m.sexo = rd.GetString(2)[0];
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
                SqlCommand cmd = new SqlCommand(String.Format("select fecha, hora, lugar, descripcion from Evento where idDep = '%{0}%'", dep), con);
                rd = cmd.ExecuteReader(); //#de registros afectados
                while (rd.Read())
                {
                    e = new Evento();
                    e.hora = rd.GetString(0);
                    e.hora = rd.GetString(1);
                    e.lugar = rd.GetString(2);
                    e.descripcion = rd.GetString(3);
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
                int i = 0;
                while (rd.Read())
                {
                    res.Add(rd.GetString(i));
                    i++;
                }//while
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al buscar los deportes disponibles: \n" + ex.ToString());
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
