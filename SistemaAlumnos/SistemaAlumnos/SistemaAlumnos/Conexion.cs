using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace SistemaAlumnos
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
                cnn = new SqlConnection("Data Source=DESKTOP-I4BI3PH;Initial Catalog=baseSistemaAlumno;Integrated Security=True");
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

        public static String comprobarPwd(string usuario, string contra)
        {
            SqlConnection con = conectar();
            if (con != null)
            {
                SqlDataReader rd;
                SqlCommand cmd = new SqlCommand(/*Cadena con el comando*/String.Format("select contra from usuarios where nombreUsuario = '{0}'", /*tabla*/usuario),/*conexión a la tabla*/con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {

                    if (rd.GetString(0).Equals(contra))
                        return "Contraseña correcta";
                    else
                        return "Contraseña incorrecta";
                }//if
                else
                    return "Usuario incorrecto";
                rd.Close();
            }//if
            else
                return "Error: No se pudo conectar a la base de datos";
            
          
        }//method

        public void llenarComboAlta(ComboBox cb)
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
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo llenar el combo" + ex);
            }//catch
            
        }//method

    }//class
}//namespace
