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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaAlumnos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string res = Conexion.comprobarPwd(txUsuario.Text, txPassword.Text);
            if (res.Equals("Contraseña correcta"))
            {
                MessageBox.Show("Lo lograste");
                Alta wAlta = new Alta();
                wAlta.Show();
                this.Close();                
            }//if
            else
                MessageBox.Show(res);

        }//buttonMethod

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txUsuario.Text = "Ana";
            txPassword.Text = "Ana";
        }//WindowLoaded
    }
}
