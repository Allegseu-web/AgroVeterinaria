using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int SuplidorId { get; set; }
        public int MonedaId { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public int UsuarioId { get; set; }
        public double ITBIS_Total { get; set; }

        [ForeignKey("CompraId")]
        public virtual List<ProductosDetalle> ProductosDetalles { get; set; } = new List<ProductosDetalle>();
    }
}