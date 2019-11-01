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
    class Curso
    {
        string nombre;
        Int16 estado, idCurso, horas;

        public Curso()
        {

        }//builder

        public Curso(string nombre, short estado, short idCurso, short horas)
        {
            this.nombre = nombre;
            this.estado = estado;
            this.idCurso = idCurso;
            this.horas = horas;
        }//builder

        public void modificaHoras(int idCurso, int cambio)
        {
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("update curso set horas = {0} where idCurso = {1}", cambio, idCurso), con);
                cmd.ExecuteNonQuery();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al modificar las horas en el curso: " + ex);
            }//catch
        }//method

        public List<Persona> consulta(Label lb, int idCurso)
        {
            List<Persona> per = new List<Persona>();
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select distinct persona.idPersona, persona.nombre, persona.correo from curso inner join cursoTomado on curso.idCurso = cursoTomado.idCurso inner join persona on cursoTomado.idPersona = persona.idPersona where curso.idCurso = {0}", idCurso),con);
                SqlDataReader rd = cmd.ExecuteReader();
                Persona p;
                Int32 idP;
                string nom, cor;
                while (rd.Read())
                {
                    idP = rd.GetInt32(0);
                    nom = rd.GetString(1);
                    cor = rd.GetString(2);
                    p = new Persona(nom, cor, Convert.ToInt16(idP));
                    per.Add(p);
                }//while                
                rd.Close();
                SqlCommand cmd2 = new SqlCommand("select horas from curso where idCurso = " + idCurso, con);
                rd = cmd2.ExecuteReader();
                rd.Read();
                lb.Content = rd.GetInt32(0).ToString();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al realizar la consulta: " + ex);
            }//catch
            return per;
        }//method
    }//class
}//namespace
