using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class NotasCreditoDetalle
    {
        [Key]
        public int NotasCreditoDetalleId { get; set; }
        public int NotasCreditoId { get; set; }
        public int CompraId { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public double ValorPago { get; set; }
    }
}
