using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion.DataModel.Entities
{
    public class Cliente : EntidadBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTimeOffset FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public ICollection<Factura> Facturas { get; set; }
        public Cliente()
        {
            this.Facturas = new HashSet<Factura>();
        }
    }
}
