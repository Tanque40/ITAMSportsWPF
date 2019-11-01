using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Prueba_ex
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }//load

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Conexion.compruebaUsuario(TxNombre.Text, TxCorreo.Text))
            {
                Session["Nombre"] = TxNombre.Text;
                Session["Correo"] = TxCorreo.Text;
                Response.Redirect("Altas.aspx");
            }//if
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }//else
        }//buttonMethod
    }
}