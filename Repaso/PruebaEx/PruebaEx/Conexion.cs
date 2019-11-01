using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PruebaEx
{
    class Conexion
    {
        public static SqlConnection conectar()
        {
            SqlConnection con;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-I4BI3PH;Initial Catalog=datosCursos;Integrated Security=True");
                MessageBox.Show("Se conectó con la base de datos correctamente");
                con.Open();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex);
                con = null;
            }//catch
            return con;
        }//method

        public static int topCursoTomado()
        {
            int res;
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand("select top 1 idCursoTomado from cursoTomado order by idCursoTomado desc", con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                res = rd.GetInt32(0);
                con.Close();
            }//try
            catch(Exception ex)
            {
                res = -1;
                MessageBox.Show("Error al obtener el topId de CursoTomado: " + ex);
            }//catch
            return res + 1;
        }//method

        public static int topIdPersona()
        {
            int res;
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand("select MAX(idPersona) from persona", con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                res = rd.GetInt32(0);                
            }//try
            catch (Exception ex)
            {
                MessageBox.Show("Error al encontrar el topId de persona: " + ex);
                res = -1;
            }//catch
            return res + 1;
        }//method

        public static void llenaCbEstado(ComboBox cb)
        {
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand("select nombre from estado order by idEdo", con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cb.Items.Add(rd.GetString(0));
                }//while
                con.Close();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al llenar el combo box de estados: " + ex);
            }//catch
        }//method

        public static void llenaCbCursos(ComboBox cb)
        {
            try
            {
                SqlConnection con = conectar();
                SqlCommand cmd = new SqlCommand("select idCurso from curso order by idCurso", con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cb.Items.Add(rd.GetInt32(0));
                }//while
                con.Close();
            }//try
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar el combo box de cursos: " + ex);
            }//catch
        }//method
    }//builder
}//namespace
