using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion.DataModel.Entities
{
    public class Factura : EntidadBase
    {
        public int ClienteID { get; set; }
        public int MetodoPagoID { get; set; }
        public Cliente Cliente { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public ICollection<FacturaDetalle> FacturaDetalles { get; set; }
        public Factura()
        {
            this.FacturaDetalles = new HashSet<FacturaDetalle>();
        }
    }
}
