using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda_de_Videojuegos
{
     class Menu
    {
        static void Main()
        {
            Sistema.CargarDatos();
            Console.WriteLine($" - menu de interacción -\n" +
                $"1. Mostrar Catalogo\n" +
                $"2. Agregar Juegos\n" +
                $"3. Borrar Juegos\n" +
                $"4. Guardar y Salir." );
            int opcion = int.Parse(Console.ReadLine() );

            switch (opcion)
            {
                case 1: Sistema.MostrarJuegos();
                    break;

                case 2: Sistema.AgregarJuego();
                    break;

                case 3: Sistema.BorrarJuego();
                    break;

                case 4:
                    Console.WriteLine($"Cerrando la plataforma👋");
                    Sistema.GuardarDatos();
                    break;
                default:
                    Console.WriteLine($"Cerrando el programa 👋");
                    Sistema.GuardarDatos();
                    break;

            }



        }
    }
}
