using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows;

namespace Prueba_ex
{
    public class Conexion
    {
        public static SqlConnection conecta()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-I4BI3PH;Initial Catalog=datosCursos;Integrated Security=True");
                con.Open();
                MessageBox.Show("Conexion con la base de datos exitosa");
                return con;
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex);
                return null;
            }//catch            
        }//method

        public static bool compruebaUsuario(string usuario, string correo)
        {
            bool res = false;
            try
            {
                SqlConnection con = conecta();
                SqlCommand cmd = new SqlCommand(String.Format("select count(*) from persona where nombre = '{0}' and correo = '{1}'", usuario, correo), con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                Int32 i = rd.GetInt32(0);
                MessageBox.Show("i " + i);
                res = i > 0;
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al buscar el usuario: " + ex);
            }//catch
            return res;
        }//method

        public static int topIdCursoTomado()
        {
            int res = -1;
            try
            {
                SqlConnection con = conecta();
                SqlCommand cmd = new SqlCommand("select MAX(idCursoTomado) from cursoTomado" , con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                res = rd.GetInt32(0) + 1;
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al encontrar el topId de cursos tomados: " + ex);
            }//catch
            return res;
        }//method

        public static void llenaDDLCursos(DropDownList ddl)
        {
            try
            {
                SqlConnection con = conecta();
                SqlCommand cmd = new SqlCommand("select nombre from curso", con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ddl.Items.Add(rd.GetString(0));
                }//while
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al llenar el ddl: " + ex);
            }//catch
        }//method

        public static int getHoras(int curso)
        {
            int res = -1;
            try
            {
                SqlConnection con = conecta();
                SqlCommand cmd = new SqlCommand(String.Format("select horas from curso where idCurso = {0}", curso), con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                res = rd.GetInt32(0);
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener las horas del curso: " + ex);
            }//catch
            return res;
        }//method

        public static string reporte(int idCurso)
        {
            string res = "";
            try
            {
                SqlConnection con = conecta();
                SqlCommand cmd = new SqlCommand(String.Format("select curso.nombre, curso.horas, estado.nombre from curso inner join estado on curso.idEdo = estado.idEdo where idCurso = {0}", idCurso), con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                string curso, estado;
                int horas;
                curso = rd.GetString(0);
                horas = rd.GetInt32(1);
                estado = rd.GetString(2);
                res = String.Format("Nombre del curso: {0}; Horas de curso: {1}; Estado en el que se dará el curso: {2}", curso, horas, estado);
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al generar el reporte del curso: " + ex);
            }//catch
            return res;
        }//method

    }//class
}//namespace