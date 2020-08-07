using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int SuplidorId { get; set; }
        public int UnidadId { get; set; }
        public double Cantidad { get; set; }
        public double Minimo { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public double Ganancias { get; set; }
    }
}