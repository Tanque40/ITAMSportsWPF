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

namespace CalculadoraCientPlus
{
    /// <summary>
    /// Lógica de interacción para Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void BtCierra_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

        private void BtIgual_Click(object sender, RoutedEventArgs e)
        {
            string[,] vectores = { {TxV1_1.Text, TxV1_2.Text, TxV1_3.Text},
                                   {TxV2_1.Text, TxV2_2.Text, TxV2_3.Text}};
            TxRes.Text = ControladorPrincipal.prodCruz(vectores);
        }//buttonMethod

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            TxRes.Text = "";
            TxV1_1.Text = ""; TxV1_2.Text = ""; TxV1_3.Text = "";
            TxV2_1.Text = ""; TxV2_2.Text = ""; TxV2_3.Text = "";
        }//buttonMethod
    }
}
