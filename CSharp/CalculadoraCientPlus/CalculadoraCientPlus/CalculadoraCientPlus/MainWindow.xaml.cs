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
using Microsoft.VisualBasic;

namespace CalculadoraCientPlus
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

        private void BtCierra_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

//==============================Start Button Methods for numbers===========================
        private void Bt1_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "1";
            else
                Txentrada.Text += "1";
        }//buttonMethod

        private void Bt2_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "2";
            else
                Txentrada.Text += "2";
        }//buttonMethod

        private void Bt3_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "3";
            else
                Txentrada.Text += "3";
        }//buttonMethod

        private void Bt4_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "4";
            else
                Txentrada.Text += "4";
        }//buttonMethod

        private void Bt5_Click_1(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "5";
            else
                Txentrada.Text += "5";
        }//buttonMethod

        private void Bt6_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "6";
            else
                Txentrada.Text += "6";
        }//buttonMethod

        private void Bt7_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "7";
            else
                Txentrada.Text += "7";
        }//buttonMethod

        private void Bt8_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "8";
            else
                Txentrada.Text += "8";
        }//buttonMethod

        private void Bt9_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "9";
            else
                Txentrada.Text += "9";
        }//buttonMethod

        private void Bt0_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "0";
            else
                Txentrada.Text += "0";
        }//buttonMethod
//=============================End Button Methods for numbers======================


//=============================Start Button Methods for modes======================

        private void BtCruz_Click(object sender, RoutedEventArgs e)
        {
            Window3 frCruz = new Window3();
            frCruz.Show();
        }//buttonMethod


//=============================Start Button Methods for operations======================
        private void BtSuma_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "+";
            else
                Txentrada.Text += "+";
        }//buttonMethod

        private void BtResta_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "-";
            else
                Txentrada.Text += "-";
        }//buttonMethod

        private void BtMult_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "*";
            else
                Txentrada.Text += "*";
        }//buttonMethod

        private void BtDiv_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "/";
            else
                Txentrada.Text += "/";
        }//buttonMethod

//=============================End Button Methods for operations======================

//=============================Start Button Methods for symbols======================

        private void Btpunto_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = ".";
            else
                Txentrada.Text += ".";
        }//buttonMethod


//=============================End Button Methods for symbols======================

//=============================Start Button Methods for clears======================
        private void BtC_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null || Txentrada.Text == "")
                return;
            else
                Txentrada.Text = Txentrada.Text.Remove(Txentrada.Text.Length - 1);
        }//buttonMethod

        private void BtCE_Click(object sender, RoutedEventArgs e)
        {
            Txentrada.Text = null;
        }//buttonMethod
//=============================End Button Methods for clears======================

//=============================Method for solving argument on screen===================
        private void Btigual_Click(object sender, RoutedEventArgs e)
        {
             Txentrada.Text = ControladorPrincipal.resuelve(Txentrada.Text);                                        
        }//buttonMethod

        private void BtFibo_Click(object sender, RoutedEventArgs e)
        {
            Txentrada.Text = ControladorPrincipal.fibonacci(Txentrada.Text);
        }//buttonMethod

        private void BtSerieG_Click(object sender, RoutedEventArgs e)
        {
            Txentrada.Text = ControladorPrincipal.serieG(Txentrada.Text);
        }//buttonMethod

        private void BtMinCDiv_Click(object sender, RoutedEventArgs e)
        {
            Txentrada.Text = ControladorPrincipal.MCDiv(Txentrada.Text);
        }//buttonMethod

        private void BtMinCMult_Click(object sender, RoutedEventArgs e)
        {
            Txentrada.Text = ControladorPrincipal.MCMult(Txentrada.Text);
        }//buttonMethod

        private void BtAbreP_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = "(";
            else
                Txentrada.Text += "(";
        }//buttonMethod

        private void BtCierraP_Click(object sender, RoutedEventArgs e)
        {
            if (Txentrada.Text == null)
                Txentrada.Text = ")";
            else
                Txentrada.Text += ")";
        }//buttonMethod
    }//class

}//namespace
