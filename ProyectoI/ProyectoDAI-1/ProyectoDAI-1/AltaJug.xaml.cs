using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para AltaJug.xaml
    /// </summary>
    public partial class AltaJug : Window
    {
        char dep;
        public AltaJug(char deporte)
        {
            dep = deporte;
            InitializeComponent();
        }//builder

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> deps = Conexion.deps();
            for (int i = 0; i < deps.Count; i++)
                CbDeportes.Items.Add(deps[i]);
        }//load

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int temp = CbDeportes.SelectedIndex;
            char dep;
            switch (temp)
            {
                case 0:
                    {
                        dep = 'a';
                    }//case
                    break;
                case 1:
                    {
                        dep = 'b';
                    }//case
                    break;
                case 2:
                    {
                        dep = 'e';
                    }//case
                    break;
                case 3:
                    {
                        dep = 'f';
                    }//case
                    break;
                case 4:
                    {
                        dep = 'r';
                    }//case
                    break;
                case 5:
                    {
                        dep = 't';
                    }//case
                    break;
                case 6:
                    {
                        dep = 'v';
                    }//case
                    break;
                default:
                    MessageBox.Show("Este deporte aun no tiene soporte para dar de alta");
                    dep = '.';
                    break;
            }//switch
            if (dep == '.')
                return;
            Miembro m = new Miembro(Convert.ToInt32(TxCU.Text), TxNombre.Text, TxSexo.Text.ElementAt(0));
            m.agrega(m,dep);
            MessageBox.Show("Alta efectuada");

        }//buttonMethod
    }//class
}//namespace
