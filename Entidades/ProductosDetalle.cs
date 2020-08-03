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
        public string ProductoDescripcion { get; set; }
        public int CompraId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double ITBIS { get; set; }
        public double Importe { get; set; }

        public ProductosDetalle(int compraid, string nombre, int cantidad, double precio, double importe, double itbis)
        {
            ProductoDetalleId = 0;
            CompraId = compraid;
            ProductoDescripcion = nombre;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            ITBIS = itbis;
        }

        public ProductosDetalle(int cantidad, double precio)
        {
            ProductoDetalleId = 0;
            Cantidad = cantidad;
            Precio = precio;
            Importe = precio * cantidad;
            ITBIS = (precio * cantidad) * 0.18;
        }
    }
}