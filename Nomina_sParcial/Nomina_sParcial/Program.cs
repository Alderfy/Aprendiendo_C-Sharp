using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nomina_sParcial
{
    class Program
    {
        public static void Printline(string text)
        {
            Console.WriteLine(text);
        }
        public static void Print(string text)
        {
            Console.Write(text);
        }

        static iEmpleadoRepositorio EmpleadoRepositorio = new EmpleadoRepositorio();
        static void Main(string[] args)
        {
            string opcion;
            do
            {
                Console.Clear();
                Printline("———————————————————————————Segundo Parcial—————————————————————————————");
                Printline("********************Sistema de Gestión de Nomina***********************");
                Printline("-----------------------------------------------------------------------");
                Printline($"                                                  {DateTime.Now}");

                Printline("");
                Printline("1- Nomina General" +
                "\n2- Nomina por Departamento" +
                "\n3- Nomina por Sexo" +
                "\n4- Nomina por Escala ISR" +
                "\n5- TOP 5 Sueldos Brutos" +
                "\n6- Sueldo Promedio" +
                "\n7- Salir\n");
                Print("Opcion: ");
                opcion = Console.ReadLine();

                OperationResult Empleados = EmpleadoRepositorio.Nomina();

                List<Empleado> empleado = new List<Empleado>();
                DataTable dataEmpleados = (DataTable)Empleados.Data;

                if (!Empleados.Result)
                {
                    Printline(Empleados.Message);
                }
                else
                {
                    foreach (DataRow emp in dataEmpleados.Rows)
                    {
                        empleado.Add(new Empleado()
                        {
                            Nombre = emp["Nombre"].ToString(),
                            Departamento = emp["Departamento"].ToString(),
                            Sexo = Convert.ToChar(emp["Sexo"]),
                            Edad = Convert.ToInt32(emp["Edad"]),
                            sueldoBruto = Convert.ToDouble(emp["sueldoBruto"]),
                            AFP = Convert.ToDouble(emp["AFP"]),
                            ARS = Convert.ToDouble(emp["ARS"]),
                            ISR = Convert.ToDouble(emp["ISR"]),
                            escalaISR = emp["escalaISR"].ToString(),
                            sueldoImponible = Convert.ToDouble(emp["sueldoImponible"]),
                            totalRetenciones = Convert.ToDouble(emp["totalRetenciones"]),
                            sueldoNeto = Convert.ToDouble(emp["sueldoNeto"]),
                        });
                    }
                }
                    switch (opcion)
                {
                    case "1": //Nomina General
                        {
                            Console.Clear();
                            Printline("————————————————————————————Segundo Parcial————————————————————————————");
                            Printline("*****************************Nomina General****************************");
                            Printline("");
                            foreach (Empleado emp in empleado)
                            {
                                Printline($"" +
                                    $"Nombre Colaborador  : {emp.Nombre}\n" +
                                    $"Departamento        : {emp.Departamento}\n" +
                                    $"Sexo                : {emp.Sexo}\n" +
                                    $"Edad                : {emp.Edad}\n" +
                                    $"Sueldo Bruto        : RD{emp.sueldoBruto:C2}\n" +
                                    $"Retencion AFP       : RD{emp.AFP:C2}\n" +
                                    $"Retencion ARS       : RD{emp.ARS:C2}\n" +
                                    $"Retencion ISR       : RD{emp.ISR:C2}\n" +
                                    $"Escala ISR          : {emp.escalaISR}\n" +
                                    $"Sueldo Imponible    : RD{emp.sueldoImponible:C2}\n" +
                                    $"Total Retenciones   : RD{emp.totalRetenciones:C2}\n" +
                                    $"Sueldo Neto         : RD{emp.sueldoNeto:C2}");

                                Printline("-----------------------------------------------------------------------\n");
                            }
                            Printline("TOTALES");
                            var sumSB = empleado.Sum(x => x.sueldoBruto);
                            Printline($"Total Sueldos Brutos: {sumSB:C2}");
                            var sumAFP = empleado.Sum(x => x.AFP);
                            Printline($"Total Retenciones AFP: {sumAFP:C2}");
                            var sumARS = empleado.Sum(x => x.ARS);
                            Printline($"Total Retenciones ARS: {sumARS:C2}");

                            Printline("");
                            Print("Presione <ENTER> para volver al Menú...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                            
                        }break;

                    case "2": //Nomina por Departamento
                        {
                             Console.Clear();
                             Printline("————————————————————————————Segundo Parcial————————————————————————————");
                             Printline("************************Nomina Por Departamento************************");
                             Printline("");
                             
                             var opcion2 = empleado.OrderBy(x => x.Nombre).GroupBy(x => x.Departamento);
                             foreach (var grupo in opcion2)
                             {
                                 Printline("");
                                 Printline("***********************************************************************");
                                 Printline($"Departamento: {grupo.Key}");
                                 Printline("-----------------------------------------------------------------------");
                                 foreach (var emp in grupo)
                                 {
                                     Printline($"" +
                                     $"Nombre Colaborador  : {emp.Nombre}\n" +
                                     $"Sexo                : {emp.Sexo}\n" +
                                     $"Edad                : {emp.Edad}\n" +
                                     $"Sueldo Bruto        : RD{emp.sueldoBruto:C2}\n" +
                                     $"Retencion AFP       : RD{emp.AFP:C2}\n" +
                                     $"Retencion ARS       : RD{emp.ARS:C2}\n" +
                                     $"Retencion ISR       : RD{emp.ISR:C2}\n" +
                                     $"Escala ISR          : {emp.escalaISR}\n" +
                                     $"Sueldo Imponible    : RD{emp.sueldoImponible:C2}\n" +
                                     $"Total Retenciones   : RD{emp.totalRetenciones:C2}\n" +
                                     $"Sueldo Neto         : RD{emp.sueldoNeto:C2}");

                                     Printline("-----------------------------------------------------------------------\n");
                                 }
                             }
                             Print("Presione <ENTER> para volver al Menú...");
                             while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                          
                        }break;

                    case "3": //Nomina por Sexo
                        {
                             Console.Clear();
                             Printline("————————————————————————————Segundo Parcial————————————————————————————");
                             Printline("****************************Nomina Por Sexo****************************");
                             Printline("");
                             
                             var opcion3 = empleado.OrderByDescending(x => x.sueldoBruto).GroupBy(x => x.Sexo);
                             foreach (var grupo in opcion3)
                             {
                                Printline("");
                                Printline("***********************************************************************");
                                Printline($"Sexo: {grupo.Key}");
                                Printline("-----------------------------------------------------------------------");
                                foreach (var emp in grupo)
                                 {
                                     Printline($"" +
                                     $"Nombre Colaborador  : {emp.Nombre}\n" +
                                     $"Departamento        : {emp.Departamento}\n" +
                                     $"Edad                : {emp.Edad}\n" +
                                     $"Sueldo Bruto        : RD{emp.sueldoBruto:C2}\n" +
                                     $"Retencion AFP       : RD{emp.AFP:C2}\n" +
                                     $"Retencion ARS       : RD{emp.ARS:C2}\n" +
                                     $"Retencion ISR       : RD{emp.ISR:C2}\n" +
                                     $"Escala ISR          : {emp.escalaISR}\n" +
                                     $"Sueldo Imponible    : RD{emp.sueldoImponible:C2}\n" +
                                     $"Total Retenciones   : RD{emp.totalRetenciones:C2}\n" +
                                     $"Sueldo Neto         : RD{emp.sueldoNeto:C2}");

                                     Printline("-----------------------------------------------------------------------");
                                 }
                             }
                             Printline("");
                             Print("Presione <ENTER> para volver al Menú...");
                             while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                           
                        }
                        break;

                    case "4": //Nomina por Escala ISR
                        {
                            Console.Clear();
                            Printline("————————————————————————————Segundo Parcial————————————————————————————");
                            Printline("*************************Nomina por Escala ISR*************************");
                            Printline("");

                            var opcion4 = empleado.OrderBy(x => x.Nombre).ThenByDescending(x => x.ISR).GroupBy(x =>
                            {
                                if (x.escalaISR == "Exento")
                                {
                                    return "Exento";
                                }
                                else if (x.escalaISR == "Escala 1")
                                {
                                    return "Escala 1";
                                }
                                else if (x.escalaISR == "Escala 2")
                                {
                                    return "Escala 2";
                                }
                                else
                                {
                                    return "Escala 3";
                                }
                            }).OrderBy(x => x.Key);

                            foreach (var grupo in opcion4)
                            {
                               Printline("");
                               Printline("***********************************************************************");
                               Printline($"Escala ISR: {grupo.Key}");
                               Printline("-----------------------------------------------------------------------");
                               foreach (var emp in grupo)
                                {
                                    Printline($"" +
                                    $"Nombre Colaborador  : {emp.Nombre}\n" +
                                    $"Departamento        : {emp.Departamento}\n" +
                                    $"Sexo                : {emp.Sexo}\n" +
                                    $"Edad                : {emp.Edad}\n" +
                                    $"Sueldo Bruto        : RD{emp.sueldoBruto:C2}\n" +
                                    $"Retencion AFP       : RD{emp.AFP:C2}\n" +
                                    $"Retencion ARS       : RD{emp.ARS:C2}\n" +
                                    $"Retencion ISR       : RD{emp.ISR:C2}\n" +
                                    $"Sueldo Imponible    : RD{emp.sueldoImponible:C2}\n" +
                                    $"Total Retenciones   : RD{emp.totalRetenciones:C2}\n" +
                                    $"Sueldo Neto         : RD{emp.sueldoNeto:C2}");

                                    Printline("-----------------------------------------------------------------------");
                                }
                            }
                            Printline("");
                            Print("Presione <ENTER> para volver al Menú...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { };
                        }
                        break;

                    case "5": //TOP 5 Sueldos Brutos
                        {
                            Console.Clear();
                            Printline("————————————————————————————Segundo Parcial————————————————————————————");
                            Printline("*************************TOP 5 Sueldos Brutos**************************");
                            Printline("");
                            
                            var opcion5 = empleado.OrderByDescending(x=> x.sueldoBruto).Take(5).Select(x=> new { x.Nombre, x.Departamento, x.sueldoBruto}).OrderBy(x=> x.Nombre);
                            
                            foreach (var emp in opcion5)
                            {
                                Printline($"" +
                                $"Nombre Colaborador  : {emp.Nombre}\n" +
                                $"Departamento        : {emp.Departamento}\n" +
                                $"Sueldo Bruto        : RD{emp.sueldoBruto:C2}");
                             
                                Printline("-----------------------------------------------------------------------\n");
                            }
                            
                            Print("Presione <ENTER> para volver al Menú...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        break;

                    case "6": //Sueldo Promedio
                        {
                            Console.Clear();
                            Printline("————————————————————————————Segundo Parcial————————————————————————————");
                            Printline("****************************Sueldo Promedio****************************");
                            Printline("");

                            var opcion6 = empleado.Where(x => x.Departamento == "Desarrollo Software").Average(x=> x.sueldoBruto);
                                
                            Printline($"Sueldo Bruto promedio Departamento Desarrollo de Software: {opcion6:C2}");

                            Printline("");
                            Print("Presione <ENTER> para volver al Menú...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        break;

                    case "7": //Salir
                        {
                            Print("\nPase feliz resto del día!!!.\nPresione <ENTER> para Salir...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        break;

                    default:
                        {
                            Print("\nFavor digitar una de las opciones listadas.\nPresione <ENTER> para volver al Menú...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        break;
                }
            } while (opcion != "7");
        }
    }
}
