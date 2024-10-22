using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tienda_de_Videojuegos.Enums;

namespace Tienda_de_Videojuegos.Models
{
    public static class Sistema
    {
        public static List<Videojuego> CatalogoJuegos { get; set; }

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

        public static void AgregarJuego(Videojuego Juego)
        {
            CatalogoJuegos.Add(Juego);
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

        public static void GuardarDatoSolo(Videojuego juego)
        {

            using StreamWriter writer = new StreamWriter(ArchivoJuegos);
            writer.WriteLine(juego);
        }
        
        public static void GuardarDatosTodos()
        {
            //List<string> lineas = CatalogoJuegos.Select(j => j.ToString()).ToList();
            List<string> lineas = new();
            foreach (var juego in CatalogoJuegos)
            {
                lineas.Add(juego.ToString());
            }
            File.WriteAllLines(ArchivoJuegos, lineas);

            using StreamWriter writer = new StreamWriter(ArchivoJuegos);
            string separator = ",";
            foreach (var vj in CatalogoJuegos)
            {
                writer.WriteLine($"{vj.Nombre}{separator}{vj.Plataforma}{separator}{vj.Precio}{separator}{vj.CantidadUnidades}{separator}");
            }
        }

        public static void CargarDatos()
        {
            var lines = File.ReadAllLines(ArchivoJuegos);

            foreach (var line in lines)
            {
                var datos = line.Split(", ");
                string nombre = datos[0];
                Plataformas plataforma = (Plataformas)Enum.Parse(typeof(Plataformas), datos[1]);
                
                decimal precio = decimal.Parse(datos[2]);
                int stock = int.Parse(datos[3]);

                Videojuego juego = new Videojuego(nombre, plataforma, precio, stock);
                AgregarJuego(juego);
            }
        }
    }
}
