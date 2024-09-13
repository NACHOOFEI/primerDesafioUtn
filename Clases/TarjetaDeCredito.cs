using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Clases
{
    public  class TarjetaDeCredito
    {
        public double NumeroDeTarjeta { get; set; }
        public int MesVencimiento { get; set; }
        public int AnioVencimiento { get; set; }
        public int CodigoDeSeguridad { get; set; }
    }
}
