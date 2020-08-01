using System;
using System.Collections.Generic;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class Direcciones
    {
        public int DireccionesId { get; set; }
        public string Calle { get; set; }
        public string Edificio_Piso_Apartamento { get; set; }
        public int NumLocalidad { get; set; }
        public string Provicia { get; set; }
        public string Municipio { get; set; }
        public string Sector { get; set; }
        public string Pais { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
    }
}
