using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion.DataModel.Entities
{
    public class FacturaDetalle : EntidadBase
    {
        public int FacturaID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}
