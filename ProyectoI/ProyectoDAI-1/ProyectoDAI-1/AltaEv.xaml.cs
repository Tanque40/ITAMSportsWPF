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
    /// Lógica de interacción para AltaEv.xaml
    /// </summary>
    public partial class AltaEv : Window
    {
        char dep;
        public AltaEv(char deporte)
        {
            dep = deporte;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtAlta_Click(object sender, RoutedEventArgs e)
        {            
            Evento ev = new Evento(dep, DTFecha.DisplayDate, TxHora.Text, TxLugar.Text, TxDescripcion.Text);
            ev.alta(ev);
        }//buttonMethod
    }
}
