using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidoresId { get; set; }
        public string Nombre { get; set; }
        public int DireccionId { get; set; }
        public string Telefono { get; set; }
        public string RNC { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
    }
}
