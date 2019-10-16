using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SistemaAlumnos
{
    class Alumno
    {
        //======================Atributos==============
        public String nombre { get; set; }
        public String sexo { get; set; }
        public String correo { get; set; }
        public Int16 claveUnica { get; set; }
        public Int16 semestre { get; set; }
        public int programa { get; set; }

        public Alumno(string nombre, string sexo, string correo, short claveUnica, short semestre, int programa)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.correo = correo;
            this.claveUnica = claveUnica;
            this.semestre = semestre;
            this.programa = programa;
        }//builder
        public Alumno(short cu, string correo)
        {
            claveUnica = cu;
            this.correo = correo;
        }//builder

        public Alumno()
        {
        }//builder

        //Metodo para agregar un Alumno a la tabla alumno
        //Regresa un entero positivo si se pudo agregar y uno negativo si no se pudo agregar
        public int agregar(Alumno a)
        {
            int res = 0;
            try
            {
                SqlConnection con = Conexion.conectar();                
                SqlCommand cmd = new SqlCommand(String.Format("insert into alumno (claveUnica, nombre, sexo, correo, semestre, idPrograma) values ({0},'{1}','{2}','{3}',{4},{5})", a.claveUnica, a.nombre, a.sexo, a.correo, a.semestre, a.programa) , con);
                res = cmd.ExecuteNonQuery(); //#de registros afectados
                con.Close();
            }//try
            catch(Exception ex)
            {
                res = -1;
                MessageBox.Show("Error: "+ex);
            }//catch            
            return res;
        }//method

        public int eliminar(int cu)
        {
            int res = 0;
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("delete from alumno where claveUnica={0}", cu), con);
                res = cmd.ExecuteNonQuery(); //#de registros afectados
                con.Close();
            }//try
            catch (Exception ex)
            {
                res = -1;
                MessageBox.Show("Error: " + ex);
            }//catch            
            return res;
        }//method

        public int modificar(Alumno a)
        {
            int res = 0;
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("update alumno set correo ='{0}' where claveUnica = {1}", a.correo, a.claveUnica), con);
                res = cmd.ExecuteNonQuery(); //#de registros afectados
                con.Close();
            }//try
            catch (Exception ex)
            {
                res = -1;
                MessageBox.Show("Error: " + ex);
            }//catch            
            return res;
        }//method

        public List<Alumno> buscar(string nombre)
        {
            List<Alumno> l = new List<Alumno>();
            SqlDataReader rd;
            Alumno a;
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("select * from alumno where nombre like '%{0}%'", nombre), con);
                rd = cmd.ExecuteReader(); //#de registros afectados
                while (rd.Read())
                {
                    a = new Alumno();
                    a.claveUnica = rd.GetInt16(0);
                    a.nombre = rd.GetString(1);
                    a.sexo = rd.GetString(2);
                    a.correo = rd.GetString(3);
                    a.semestre = rd.GetInt16(4);
                    a.programa = rd.GetInt16(5);
                    l.Add(a);
                }//while
                con.Close();
            }//try
            catch (Exception ex)
            {
                rd = null;
                MessageBox.Show("Error: " + ex);
            }//catch
            //if (rd != null)
                

            return l;
        }//method


    }//class
}//namespace
