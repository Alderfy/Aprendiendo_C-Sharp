using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion.DataModel.Entities
{
    public class Suplidor : EntidadBase
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string RNC { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public Suplidor()
        {
            this.Productos = new HashSet<Producto>();
        }
    }
}
