using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda_de_Videojuegos.Enums;

namespace Tienda_de_Videojuegos.Models
{
    public class Videojuego
    {
        public string Nombre { get; set; }
        public Plataformas Plataforma { get; private set; }
        public double Precio { get; set; }
       public int CantidadUnidades { get; set; }

        public Videojuego(string nombre, Plataformas plataforma, double precio, int cantidadUnidades)
        {
            Nombre = nombre;
            Plataforma = plataforma;
            Precio = precio;
            CantidadUnidades = cantidadUnidades;
        }
        public Videojuego(string nombre, string PlataformaNombre, int PlataformaNumero, double precio, int cantidadUnidades)
        {
            Nombre = nombre;
            Plataforma.ToString(PlataformaNombre);
            Plataforma = (Plataformas)PlataformaNumero;
            Precio = precio;
            CantidadUnidades = cantidadUnidades;
        }


    }
}
