using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoDAI_1
{
    class Evento
    {
        public int idEv { get; set; }        
        public char idDep { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string lugar { get; set; }
        public string descripcion { get; set; }
        public Evento()
        {
          

        }//builder

        public Evento(char idDep, DateTime fecha, string hora, string lugar, string descripcion)
        {
            this.idDep = idDep;
            this.fecha = fecha.ToString("MM/dd/yyyy");
            this.hora = hora;
            this.lugar = lugar;
            this.descripcion = descripcion;
            idEv = Conexion.topId("Evento");
        }

        public Evento(int idEvento)
        {
            idEv = idEvento;
        }//builder

        public void alta(Evento e)
        {
            
            try
            {
                SqlConnection con = Conexion.conectar();
                MessageBox.Show("fecha: " + e.fecha);
                SqlCommand cmd = new SqlCommand(String.Format("insert into Evento(idEvento, fecha, hora, lugar, descripcion, idDep) values ({0}, '{1}','{2}', '{3}', '{4}', '{5}')", Conexion.topId("Evento"),  e.fecha, e.hora, e.lugar, e.descripcion, e.idDep), con);
                cmd.ExecuteNonQuery();
                con.Close();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al dar de alta el evento: " + ex);
            }//catch


            
        }//method

        public void baja()
        {
            try
            {
                SqlConnection con = Conexion.conectar();
                SqlCommand cmd = new SqlCommand(String.Format("delete from Evento where idEvento = ",idEv), con);
                cmd.ExecuteNonQuery();
                con.Close();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al dar de baja el evento: " + ex);
            }//catch
        }//method
    }//class
}//namespace
