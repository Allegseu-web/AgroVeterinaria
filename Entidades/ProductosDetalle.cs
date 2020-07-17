using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    class ProductosDetalle
    {
        [Key]
        public int ProductoDetalleId { get; set; }
        public int ProductoId { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }

        public ProductosDetalle(double cantidad, double precio, double importe)
        {
            ProductoDetalleId = 0;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}
