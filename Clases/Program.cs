using Libreria.Clases;
using Libreria.enums;
using Libreria.Persona;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
    
{
  static   List<Usuario> usuarios = new List<Usuario>()
      {
      /*nombre,contrasenia,numero de tarjeta,mes/anio vencimiento,codigo seguridad*/
          new Usuario("nacho",11212,1111111,02,2027,1148),
          new Usuario("pocho",1212,2222222,01,2023,1122),

      };
    static List<Libro> LibroFantasia = new List<Libro>()
    {
        new Libro("moby dick",ERubro.FANTASIA,13,15.5),
        new Libro("el hobbit",ERubro.FANTASIA,4,24.9)
    };
    static List<Libro> LibroCienciaFiccion = new List<Libro>()
    {
        new Libro("frankenstein",ERubro.CIENCIA_FICCION,5,9.99),
                new Libro("la bella y la bestia",ERubro.CIENCIA_FICCION,2,4.0)


    };
    static List<Libro> LibrosHistoria = new List<Libro>()
    {
        new Libro("los caballeros de la noche",ERubro.HISTORIA,12,5.0),
                new Libro("Roma",ERubro.HISTORIA,12,8.0)


    };
   static Carrito carrito = new Carrito();
   
    
    static void Main()
    {
        while (!BuscarUsuario(usuarios))
        {
            BuscarUsuario(usuarios);
        }
        Console.WriteLine("ingrese un rubro\n" +
            "1.Fantasia\n" +
            "2.Ciencia Ficcion\n" +
            "3.Historia\n");
        int opcion = int.Parse(Console.ReadLine());
        switch (opcion)
        {
            case 1:
                MostrarTitulos(LibroFantasia);
                AgregarLibroCarro(LibroFantasia);
                
                if (ValidarTarjeta(usuarios))
                {
                    carrito.MostrarCarrito();
                    ActualizarStockGeneral();
                }
                carrito.MostrarCarrito();
                break;
            case 2:
                MostrarTitulos(LibroCienciaFiccion);
                AgregarLibroCarro(LibroCienciaFiccion);

                if (ValidarTarjeta(usuarios))
                {
                    carrito.MostrarCarrito();
                    ActualizarStockGeneral();
                }

                break;
            case 3:
                MostrarTitulos(LibrosHistoria);
                AgregarLibroCarro(LibrosHistoria);

                if (ValidarTarjeta(usuarios))
                {
                    carrito.MostrarCarrito();
                    ActualizarStockGeneral();
                }
                break;
         
        }


    }
    static bool BuscarUsuario(List<Usuario> usuarios)
    {
            Console.WriteLine("ingrese el nombre del usuario:"); string name = Console.ReadLine();
            Console.WriteLine("ingrese la contrasenia del usuario:"); double password = double.Parse(Console.ReadLine());
            name.ToLower();
            foreach (var n in usuarios)
            {
                if (n.Name == name && n.Password == password)
                {
                    Console.WriteLine("bienvenido a la libreria");
                   return true;
                }
                else
                {
                    Console.WriteLine("el usuario o contrasenia no son correctos\n");
                    return false;
                }
            }
        return false;
            
            

        
    }
    static void MostrarTitulos(List<Libro> libros)
    {
        foreach(var titulos in libros)
        {
            Console.WriteLine($"Titulo:{titulos.TituloLibro}");
        }
    }
    static void AgregarLibroCarro(List <Libro> libros)
    {
        do
        {
            int cantidad;
            Console.WriteLine("Ingrese el título del libro que quiere comprar y si no quiere agregar mas libros ingrese 'comprar':");
            string nombre = Console.ReadLine();
            if (nombre.ToLower() == "comprar")
            { break;
           
            }
            Console.WriteLine("Ingrese la cantidad que quiere agregar:");
             cantidad = int.Parse(Console.ReadLine());
            foreach (var libro in libros)
            {
                if (libro.TituloLibro.ToLower() == nombre.ToLower())
                {
                    if (libro.Cantidad >= cantidad)
                    {
                        carrito.Agregar(libro, cantidad);
                        Console.WriteLine($"Libro '{libro.TituloLibro}' agregado al carrito.");
                    }
                    else
                    {
                        Console.WriteLine("Stock insuficiente.");
                    }
                    break;
                }
            }

            Console.WriteLine("El libro no existe en el catálogo.");
        } while (true);


    }
    static bool ValidarTarjeta(List<Usuario> usuarios)
    {
        Console.WriteLine("Ingrese su número de tarjeta:");
        long numeroTarjeta = long.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el mes de vencimiento (MM):");
        int mesVencimiento = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el año de vencimiento (YYYY):");
        int anioVencimiento = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el código de seguridad:");
        int codigoSeguridad = int.Parse(Console.ReadLine());

        foreach (var usuario in usuarios)
        {
            if (usuario.NumeroDeTarjeta == numeroTarjeta &&
                usuario.MesVencimiento == mesVencimiento &&
                usuario.AnioVencimiento== anioVencimiento &&
                usuario.CodigoDeSeguridad == codigoSeguridad)
            {
                Console.WriteLine("Tarjeta válida.");
                return true;
            }
        }

        Console.WriteLine("Datos de tarjeta inválidos. No se puede procesar la compra.");
        return false;
    }

    static void ActualizarStockGeneral()
    {
        foreach (var n in carrito.CarritoDeLibros)
        {
            Libro libroEnCarrito = n.libro;
            int cantidadComprada = n.cantidad;

           
            ActualizarStockEnLista(LibroFantasia, libroEnCarrito, cantidadComprada);
            ActualizarStockEnLista(LibroCienciaFiccion, libroEnCarrito, cantidadComprada);
            ActualizarStockEnLista(LibrosHistoria, libroEnCarrito, cantidadComprada);
        }

        Console.WriteLine("Stock actualizado correctamente.");
    }

    static void ActualizarStockEnLista(List<Libro> listaLibros, Libro libro, int cantidad)
    {
        foreach (var libroLista in listaLibros)
        {
            if (libroLista.TituloLibro == libro.TituloLibro)
            {
                libroLista.Cantidad -= cantidad;
                Console.WriteLine($"El libro '{libroLista.TituloLibro}' ahora tiene {libroLista.Cantidad} en stock.");
                return;
            }
        }
    }



}




