using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_de_Videojuegos.Enums;

namespace Tienda_de_Videojuegos.Models
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
                $"4. Guardar y Salir.");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Sistema.MostrarJuegos();
                    break;

                case 2:

                    Console.WriteLine($"\n Ingrese el nombre del juego a registrar.");
                    string Nombre = Console.ReadLine();

                    var check = Sistema.CatalogoJuegos.FirstOrDefault(check => Nombre.Equals(check));

                    if (check != null)
                    { throw new Exception("\nEl nombre elegido ya existe, Intente de nuevo."); }

                    Console.WriteLine($"\nElija la plataforma en la que éste juego está permitido:");

                    foreach (var Plataformas in Enum.GetValues(typeof(Plataformas)))
                    {
                        Console.WriteLine($"{(int)Plataformas}. {(string)Plataformas}\n");
                    }
                    int cas = int.Parse(Console.ReadLine());
                    Plataformas plataforma = Plataformas.PC;

                    foreach (var plataformado in Enum.GetValues(typeof(Plataformas)))
                    {
                        if (cas == (int)plataformado)
                        {
                            plataforma = (Plataformas)plataformado;
                            break;
                        }
                    }
                    Console.WriteLine($"\n Ingrese el precio del juego a registrar. (se admiten decimales)");
                    decimal Precio = decimal.Parse(Console.ReadLine());


                    Console.WriteLine($"\n Ingrese la cantidad de stock del juego a registrar.");
                    int CantidadUnidades = int.Parse(Console.ReadLine());

                    Videojuego JuegoNuevo = new(Nombre, plataforma, Precio, CantidadUnidades);

                    Console.WriteLine($"Juego creado con éxito :)");
                    break;

                case 3:
                    Sistema.BorrarJuego();
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
