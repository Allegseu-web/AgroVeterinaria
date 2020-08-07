using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Markup;

namespace AgroVeterinaria.Entidades
{
    public class Unidades
    {
        [Key]
        public int UnidadId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}