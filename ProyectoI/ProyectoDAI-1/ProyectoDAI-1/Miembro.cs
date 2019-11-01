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
        public Int32 claveU { get; set; }
        public string nombre { get; set; }
        public char sexo { get; set; }
        public string rol { get; set; }
        public Int16 jugados { get; set; }
        public Int16 ganados { get; set; }
        public Int16 perdidos { get; set; }

        public Miembro()
        {

        }//builder
        public Miembro(Int32 clave)
        {
            claveU = clave;
        }//builder
        public Miembro(Int32 cu, string n, char s)
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
            res = cmd.ExecuteNonQuery() + agregaJugDep(m, dep, con) + agregaDatosVacio(m, con); //#de registros afectados
            
        }//try
            catch(Exception ex)
            {
                res = -1;
                MessageBox.Show("Error: "+ex);
            }//catch            
            return res;
        }//method


        public int agregaDatosVacio(Miembro m, SqlConnection con)
        {
            int res;
            try
            {                
                SqlCommand cmd = new SqlCommand(String.Format("insert into Datos (claveUnica, rol , jugados, ganados, perdidos) values ({0}, 'por derfinir', 0, 0, 0)", m.claveU), con);
                res = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                res = -1;
                MessageBox.Show("Error: " + ex);
            }//catch
            return res;
        }//method

        public int agregaJugDep(Miembro m, char dep, SqlConnection con)
        {
            int res;
            try
            {
                SqlCommand cmd = new SqlCommand(String.Format("insert into TieneDepJug (idDep, claveUnica) values ('{0}',{1})",dep, m.claveU), con);
                res = cmd.ExecuteNonQuery();
                
            }//try
            catch(Exception ex)
            {
                res = -1;
                MessageBox.Show("Error: " + ex);
            }//catch
            return res;
        }//method

        public void baja(char dep)
        {
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd1 = new SqlCommand(String.Format("delete Datos from Jugador inner join TieneDepJug on Jugador.claveUnica = TieneDepJug.claveUnica inner join Datos on Datos.claveUnica = Jugador.claveUnica inner join EquipoJugador on EquipoJugador.claveUnica = Jugador.claveUnica where Jugador.claveUnica = {0}", claveU), con);
                SqlCommand cmd2 = new SqlCommand(String.Format("delete Datos from Jugador inner join TieneDepJug on Jugador.claveUnica = TieneDepJug.claveUnica inner join Datos on Datos.claveUnica = Jugador.claveUnica where Jugador.claveUnica = {0}", claveU), con);
                SqlCommand cmd3 = new SqlCommand(String.Format("delete TieneDepJug from Jugador inner join TieneDepJug on Jugador.claveUnica = TieneDepJug.claveUnica where Jugador.claveUnica = {0}", claveU), con);
                SqlCommand cmd4 = new SqlCommand(String.Format("delete from Jugador where Jugador.claveUnica = {0}", claveU), con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                con.Close();
            }//try
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja el Jugador/Miembro: " + ex);
            }//catch
        }//method

    }//class
}//namespace
