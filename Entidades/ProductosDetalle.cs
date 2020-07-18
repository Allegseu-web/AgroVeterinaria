using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AgroVeterinaria.Entidades
{
    public class ProductosDetalle
    {
        [Key]
        public int ProductoDetalleId { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Importe { get; set; }

        /*public ProductosDetalle(int compraid, double cantidad, double precio, double importe)
        {
            ProductoDetalleId = 0;
            CompraId = compraid;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }*/
    }
}
