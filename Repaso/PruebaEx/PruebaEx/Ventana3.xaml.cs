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

namespace PruebaEx
{
    /// <summary>
    /// Interaction logic for Ventana3.xaml
    /// </summary>
    public partial class Ventana3 : Window
    {
        public Ventana3()
        {
            InitializeComponent();
        }//builder

        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            this.Close();
            w.Show();
        }//buttonMethod

        private void BtConsulta_Click(object sender, RoutedEventArgs e)
        {
            Curso c = new Curso();
            DgAlumnos.ItemsSource = c.consulta(LbHoras, CbCursos.SelectedIndex);
        }//buttonMethod

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion.llenaCbCursos(CbCursos);
        }//load
    }//class
}//namespace
