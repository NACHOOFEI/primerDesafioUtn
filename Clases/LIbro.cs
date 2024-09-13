using Libreria.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Clases
{
    public class Libro
    {
        public string TituloLibro { get; set; }
        public ERubro Rubro { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public Libro(string titulo,ERubro rubro,int cantidad,double precio)
        {
            TituloLibro= titulo;
            Rubro= rubro;
            Cantidad = cantidad;
            Precio = precio;
        }
    }
}
