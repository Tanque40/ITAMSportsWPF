using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoDAI_1
{
    /// <summary>
    /// Interaction logic for BajaModif.xaml
    /// </summary>
    public partial class BajaModif : Window
    {
        char dep, opc;
        int bM;
        public BajaModif(char deporte, char opcion, int bajaModif)
        {
            dep = deporte;
            opc = opcion;
            bM = bajaModif;
            InitializeComponent();
        }//builder

        private void TxVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

        private void TxAccion_Click(object sender, RoutedEventArgs e)
        {
            
            Miembro m = new Miembro(Convert.ToInt16(TxCU.Text));
            m.baja(dep);
            MessageBox.Show("Baja exitosa");
        }// buttonMethod
    }//class
}//namespace
