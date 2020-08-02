using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class NotasCreditoDetalle
    {
        [Key]
        public int ID { get; set; }
        public int NotasCreditoId { get; set; }
        public int CompraId { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public double ValorPago { get; set; }

        public NotasCreditoDetalle(int compraid, DateTime fechapago, double valorpago)
        {
            ID = 0;
            CompraId = compraid;
            FechaPago = fechapago;
            ValorPago = valorpago;
        }
    }
}