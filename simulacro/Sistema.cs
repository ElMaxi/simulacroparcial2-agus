using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tienda_de_Videojuegos.Enums;
using Tienda_de_Videojuegos.Models;

namespace Tienda_de_Videojuegos
{
    public static class Sistema
    {
        static List<Videojuego> CatalogoJuegos = new();

        static string ArchivoJuegos = "ArchivoJuegos.txt";
        public static void MostrarJuegos()
        {
            int ContadorCatalogo = 0;
            foreach (var Videojuego in CatalogoJuegos)
            {
                ContadorCatalogo++;
                Console.WriteLine($"{ContadorCatalogo}. '{Videojuego.Nombre}', Precio: {Videojuego.Precio}, {Videojuego.CantidadUnidades} disponibles.  ");
            }
        }

        public static void AgregarJuego()
        {
                Console.WriteLine($"\n Ingrese el nombre del juego a registrar.");
                string Nombre = Console.ReadLine();

                var check = CatalogoJuegos.FirstOrDefault(check => Nombre.Equals(check));

                if (check != null)
                {  throw new Exception("\nEl nombre elegido ya existe, Intente de nuevo.");}

            Console.WriteLine($"\nElija la plataforma en la que éste juego está permitido:");
            
            foreach (var Plataformas in Enum.GetValues( typeof( Plataformas ) ))
            {
                Console.WriteLine($"{(int)Plataformas}. {(string)Plataformas}\n");
            }
            int opcion = int.Parse(Console.ReadLine());
            Plataformas plataforma = Plataformas.PC;

            foreach ( var plataformado in Enum.GetValues ( typeof( Plataformas )))
            {   if (opcion == (int)plataformado)
                {
                    plataforma = (Plataformas)plataformado;
                    break;
                }
            }
            Console.WriteLine($"\n Ingrese el precio del juego a registrar. (se admiten decimales)");
            double Precio = double.Parse(Console.ReadLine());


            Console.WriteLine($"\n Ingrese la cantidad de stock del juego a registrar.");
            int CantidadUnidades = int.Parse(Console.ReadLine());

            Videojuego JuegoNuevo = new(Nombre, plataforma, Precio, CantidadUnidades);

            Console.WriteLine($"Juego creado con éxito :)");
        }

        public static void BorrarJuego()
        {

            Console.WriteLine($"\n Ingrese el nombre del juego a BORRAR.");
            string Nombre = Console.ReadLine();

            var check = CatalogoJuegos.FirstOrDefault(check => Nombre.Equals(check));

            if (check != null)
            { throw new Exception("El nombre de juego elegido NO existe, Intente de nuevo."); }

            CatalogoJuegos.Remove(check);
            Console.WriteLine($"\nJuego removido con éxito.");

        }

        public static void ReducirStockJuego(string Nombre, int Stock)
        {

            var check = CatalogoJuegos.FirstOrDefault(check => Nombre.Equals(check));

            check.CantidadUnidades = check.CantidadUnidades - Stock;
            Console.WriteLine($"\nStock reducido por {Stock}.");
        }
        public static void AumentarStockJuego(string Nombre, int Stock)
        {

            var check = CatalogoJuegos.FirstOrDefault(check => Nombre.Equals(check));

            check.CantidadUnidades = check.CantidadUnidades - Stock;
            Console.WriteLine($"\nStock Aumentado por {Stock}.");
        }

        public static void GuardarDatos()
        {
            var writer = new StreamWriter(ArchivoJuegos);
            string separator = ",";
        foreach (var vj in CatalogoJuegos)
            {
                writer.WriteLine($"{vj.Nombre}{separator}{vj.Plataforma}{separator}{vj.Precio}{separator}{vj.CantidadUnidades}{separator}");
            }
        }

        public static void CargarDatos()
        {
            
            var reader = new StreamReader(ArchivoJuegos);
            if (File.Exists(ArchivoJuegos))
            {

                foreach (var linea in File.ReadAllLines(ArchivoJuegos))
                {
                    var sp = linea.Split(",");
                    var videojuego = new Videojuego(sp[0], sp[1], int.Parse(sp[1]), double.Parse(sp[2]), int.Parse(sp[3]));
                    CatalogoJuegos.Add(videojuego);
                }

            }
            
        }
    }
}
