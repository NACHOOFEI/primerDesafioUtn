using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Clases
{
    public class Carrito
    {
       public  List<(Libro libro,int cantidad)> CarritoDeLibros { get; set; } = new List<(Libro, int cantidad)>();
        public List<int> cantidadDeLibros { get; set; } = new List<int>();
        public void Agregar (Libro libro,int cantidad)
        {
            CarritoDeLibros.Add((libro,cantidad));
            
        }
      
        public void MostrarCarrito()
        {
            foreach(var n in CarritoDeLibros)
            {
                Console.WriteLine($"Titulo:{n.libro.TituloLibro}\n" +
                    $"cantidad:{n.cantidad}\n" +
                    $"precio:{n.libro.Precio:C}");
            }
        }
    }
}
