using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace AgroVeterinaria.Entidades
{
    class Unidades
    {
        public int UnidadId { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
