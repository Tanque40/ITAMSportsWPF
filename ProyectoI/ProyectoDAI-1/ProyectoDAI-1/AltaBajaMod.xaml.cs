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
    /// Interaction logic for AltaBajaMod.xaml
    /// </summary>
    public partial class AltaBajaMod : Window
    {
        char dep, opc;

        private void BtVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }//buttonMethod

        private void BtIr_Click(object sender, RoutedEventArgs e)
        {
            if (RbAlta.IsChecked == true)
            {
                if(opc == 'e')//se quiere realizar un alta de evento
                {
                    AltaEv a = new AltaEv(dep);
                    a.Show();
                    this.Close();
                }//if
                else
                {
                    if (opc == 'm')//se quiere realizar un alta de miembro/jugador
                    {
                        AltaJug a = new AltaJug(dep);
                        a.Show();
                        this.Close();
                    }//if
                    else//se quiere realizar un alta de equipo
                    {
                        AltaEquipo a = new AltaEquipo(dep);
                        a.Show();
                        this.Close();
                    }//else

                }//else
            }//if
            else
            {
                if(RbBaja.IsChecked == true)
                {
                    BajaModif m = new BajaModif(dep, opc, 0);
                    m.Show();
                    this.Close();
                }//if
                else
                {
                    if (RbModifica.IsChecked == true)
                    {

                        if (opc == 'e')
                        {
                            ModificaEvento a = new ModificaEvento(dep);
                            a.Show();
                            this.Close();
                        }//if
                        else
                        {
                            AltaDatos a = new AltaDatos(dep, opc);
                            a.Show();
                            this.Close();
                        }//else
                    }//if
                    else
                        MessageBox.Show("Por favor seleccione una opción");
                }//else
            }//else
        }//buttonMethod

        public AltaBajaMod(char deporte, char opcion)
        {
            dep = deporte;
            opc = opcion;
            InitializeComponent();
        }//builder




    }///class
}//namespace
