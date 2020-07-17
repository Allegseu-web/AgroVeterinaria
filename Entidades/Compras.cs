using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int SuplidorId { get; set; }
        public double SubTotal { get; set; }
        public int UsuarioId { get; set; }
    }
}
