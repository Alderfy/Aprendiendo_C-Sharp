using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Linq
{
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime fechaNaciemiento { get; set; }
        public char Sexo { get; set; }
        public string lugarNacimiento { get; set; }
        public double Edad
        {
            get
            {
                return Math.Round(DateTime.Today.Subtract(this.fechaNaciemiento).TotalDays / 365.25, 2);         
            }
        }
    }
}
