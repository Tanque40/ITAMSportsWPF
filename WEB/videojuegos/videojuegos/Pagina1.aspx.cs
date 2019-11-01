using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace videojuegos
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        protected OdbcConnection conectarBD()
        {
            String stringConexion = "Driver={SQL Server Native Client 11.0};Data Source=DESKTOP-I4BI3PH;Initial Catalog=GameSpot;Integrated Security=True";
            try
            {
                OdbcConnection conexion = new OdbcConnection(stringConexion);
                conexion.Open();
                lbContador.Text = "conexion exitosa";
                return conexion;
            }
            catch (Exception ex)
            {
                lbContador.Text = ex.StackTrace.ToString();
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btPagina2_Click(object sender, EventArgs e)
        {
            OdbcConnection miConexion = conectarBD();
            if (miConexion != null)
            {
                OdbcCommand cmd = new OdbcCommand(String.Format("select claveU from usuario where email = '{0}' and password = '{1}'", txUsuario.Text, txContraseña.Text), miConexion);
                OdbcDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    Session["claveUnica"] = rd.GetInt32(0).ToString();
                    Response.Redirect("Pagina2.aspx");
                }//if
                else
                    lbContador.Text = "el usuario o contraseña son incorrectos";

            }
        }
    }
}