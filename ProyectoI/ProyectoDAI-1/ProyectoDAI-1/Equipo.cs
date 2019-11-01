using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDAI_1
{
    class Equipo
    {
        public int idEquipo { get; set; }
        public int ganados { get; set; }
        public int perdidos { get; set; }
        public int jugados { get; set; }
        public string nombre { get; set; }
        
        public Equipo()
        {

        }//builder

        public Equipo(int idEquipo, int ganados, int perdidos, int jugados, string nombre)
        {
            this.idEquipo = idEquipo;
            this.ganados = ganados;
            this.perdidos = perdidos;
            this.jugados = jugados;
            this.nombre = nombre;
        }//builder
    }//class
}//namespace
