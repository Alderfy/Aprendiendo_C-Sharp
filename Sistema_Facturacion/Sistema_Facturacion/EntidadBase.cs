using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion
{
    public class EntidadBase
    {
        public int ID { get; set; }
        public string Estatus { get; set; } = "A";
        public bool Borrado { get; set; } = false;
        public DateTimeOffset FechaRegistro { get; set; } = DateTime.Now;
        public int CreadoPor { get; set; }
        public DateTimeOffset FechaModificacion { get; set; }
        public int ModificadoPor { get; set; }
    }
}
