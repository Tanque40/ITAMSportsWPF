using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoDAI_1
{
    class Miembro
    {
        public Int16 claveU { get; set; }
        public string nombre { get; set; }
        public char sexo { get; set; }
        public Miembro()
        {

        }//builder
        public Miembro(Int16 cu, string n, char s)
        {
            claveU = cu;
            nombre = n;
            sexo = s;
        }//builder

        public int agrega(Miembro m, char dep)
        {
            int res;
            try 
            { 
            SqlConnection con = Conexion.conectar();
            SqlCommand cmd = new SqlCommand(String.Format("insert into Jugador (claveUnica, nombre, sexo) values ({0},'{1}','{2}')", m.claveU, m.nombre, m.sexo), con);
            res = cmd.ExecuteNonQuery() + agregaJugDep(m, dep, con); //#de registros afectados
            con.Close();
        }//try
            catch(Exception ex)
            {
                res = -1;
                MessageBox.Show("Error: "+ex);
            }//catch            
            return res;
        }//method

        public int agregaJugDep(Miembro m, char dep, SqlConnection con)
        {
            int res;
            try
            {
                SqlCommand cmd = new SqlCommand(String.Format("insert into TieneDepJug (idDep, ) values ({0},'{1}','{2}')", m.claveU, m.nombre, m.sexo), con);
                res = cmd.ExecuteNonQuery();
            }//try
            catch(Exception ex)
            {
                res = -1;
                MessageBox.Show("Error: " + ex);
            }//catch
            return res;
        }//method

    }//class
}//namespace
