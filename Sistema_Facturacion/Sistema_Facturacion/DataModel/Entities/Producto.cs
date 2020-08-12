using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion.DataModel.Entities
{
    public class Producto : EntidadBase
    {
        public int SuplidorID { get; set; }
        public int CategoriaItbisID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public Suplidor Suplidor { get; set; }
        public CategoriaItbis CategoriaItbis { get; set; }
    }
}
