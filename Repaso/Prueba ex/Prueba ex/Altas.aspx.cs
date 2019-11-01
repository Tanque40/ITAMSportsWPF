using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Prueba_ex
{
    public partial class Altas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DDLCursos.Items.Count == 0)
                Conexion.llenaDDLCursos(DDLCursos);
            LbHoras.Text = Conexion.getHoras(0).ToString();
        }//load

        protected void Button1_Click(object sender, EventArgs e)
        {//alta
            try
            {
                SqlConnection con = Conexion.conecta();
                int idCursoTomado, idPersona, idCurso;
                idCursoTomado = Conexion.topIdCursoTomado();
                SqlCommand cmd = new SqlCommand(String.Format("select idPersona from persona where nombre = '{0}' and correo = '{1}'", Session["Nombre"], Session["Correo"]), con);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                idPersona = rd.GetInt32(0);
                rd.Close();
                idCurso = DDLCursos.SelectedIndex;
                SqlCommand cmd3 = new SqlCommand(String.Format("insert into cursoTomado values({0},{1},{2})",idCursoTomado, idPersona, idCurso ), con);
                cmd3.ExecuteNonQuery();
            }//try
            catch(Exception ex)
            {
                MessageBox.Show("Error al dar de alta el curso: " + ex);
            }//catch
        }//buttonMethod

        protected void DDLCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbHoras.Text = Conexion.getHoras(DDLCursos.SelectedIndex).ToString();
        }//selectedIndex

        protected void Button2_Click(object sender, EventArgs e)
        {//reporte
            Lb.Text = Conexion.reporte(DDLCursos.SelectedIndex);
        }//buttonMethod
    }//class
}//namespace