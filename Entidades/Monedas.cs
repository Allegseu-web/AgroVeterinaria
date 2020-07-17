using System;
using System.Collections.Generic;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class Monedas
    {
        public int MonedaId { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
