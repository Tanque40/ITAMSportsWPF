using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PruebaEx
{
    class Persona
    {
        public string nombre, correo;
        public Int16 idPersona;

        public Persona()
        {

        }//builder

        public Persona(string nombre, string correo, Int16 idPersona)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.idPersona = idPersona;
        }//builder

        public void alta(Persona p, int horas, int idEdo)
        {
            MessageBox.Show("Los datos insertados son: horas - " + horas + " idEdo - " + idEdo);
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("insert into persona values({0},'{1}','{2}')", p.idPersona, p.nombre, p.correo), con);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand(String.Format("select idCurso from curso where horas = {0} and idEdo = {1}", horas, idEdo), con);
                SqlDataReader rd = cmd2.ExecuteReader();
                rd.Read();
                int idCurso = rd.GetInt32(0);
                rd.Close();
                int idCursoTomado = Conexion.topCursoTomado();
                SqlCommand cmd3 = new SqlCommand(String.Format("insert into cursoTomado values ({0}, {1}, {2})", idCursoTomado, p.idPersona, idCurso), con);
                cmd3.ExecuteNonQuery();
                con.Close();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al dar de alta: " + ex);
            }//catch
        }//method

        


    }//class
}//namespace
