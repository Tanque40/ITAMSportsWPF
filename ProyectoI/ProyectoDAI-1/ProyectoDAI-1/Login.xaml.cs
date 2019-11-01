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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MainWindow inicio;
        public Login(MainWindow m)
        {
            inicio = m;
            InitializeComponent();
        }//builder

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            this.Close();
        }//buttonMethod

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int temp = Conexion.comprobarPwd(TxUsuario.Text, TxPasswd.Text);
            switch (temp)
            {
                case 0://Usuario incorrecto
                    {
                        MessageBox.Show("El usuario ingresado no existe");
                    }//case
                    break;
                case 1://Usuario y contraseña correctos
                    {
                        MessageBox.Show("Bienvenido " + TxUsuario.Text);

                        inicio.adm = Conexion.encuentraDep(TxUsuario.Text);
                        this.Close();
                    }//case
                    break;
                case 2://Contraseña incorrecta
                    {
                        MessageBox.Show("La contraseña ingresada no es correcta");
                    }//case
                    break;
                case -1://Conexion con la base de datos fallida
                    {
                        MessageBox.Show("Error al intentar conectar con la base de datos");
                    }//case
                    break;
                default:
                    MessageBox.Show("Esto no debería pasar");
                    break;
            }//switch
        }//buttonMethod

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Puedes contactar a los desarrolladores al correo jguti109@itam.mx para cualquier problema técnico");
        }//buttonMethod
    }
}
