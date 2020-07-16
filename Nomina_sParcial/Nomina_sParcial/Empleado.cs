using System;

namespace Nomina_sParcial
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public char Sexo { get; set; }
        public int Edad { get; set; }
        public double sueldoBruto { get; set; }
        public double AFP { get; set; }
        public double ARS { get; set; }
        public double ISR { get; set; }
        public string escalaISR { get; set; }
        public double sueldoImponible { get; set; }
        public double totalRetenciones { get; set; }
        public double sueldoNeto{ get; set; }

    }
}
