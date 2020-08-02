using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class NotasCreditos
    {
        [Key]
        public int NotasCreditoId { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("NotasCreditoId")]
        public virtual List<NotasCreditoDetalle> NotasCreditoDetalles { get; set; } = new List<NotasCreditoDetalle>();
    }
}