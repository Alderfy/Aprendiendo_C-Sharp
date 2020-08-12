using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Facturacion.DataModel.Entities
{
    public class CategoriaItbis : EntidadBase
    {
        public string Nombre { get; set; }
        public double Porcentaje { get; set; }
    }
}
