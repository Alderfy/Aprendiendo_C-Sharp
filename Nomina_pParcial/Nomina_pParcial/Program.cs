using System;
using System.Data;
using System.Security.Cryptography;

namespace Nomina_pParcial
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

        static iempleadosRepositorio empleadosRepositorio = new empleadoRepositorio();
        public static void Main(string[] args)
        {
            string opcion = null;
            do
            {
                Console.Clear();
                Printline("————————————————————————————Primer Parcial—————————————————————————————");
                Printline("********************Sistema de Gestión de Nomina***********************");
                Printline("-----------------------------------------------------------------------");
                Printline($"                                                  {DateTime.Now}");

                Printline("");
                Printline("1 - Crear Empleado" +
                "\n2 - Buscar Empleado por Cedula" +
                "\n3 - Actualizar Empleado" +
                "\n4 - Borrar Empleado" +
                "\n5 - Salir\n");
                Print("Opcion: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": //Crear
                        {
                            char continuar = 'P';
                            while (continuar != 'M')
                            {
                                volver: 
                                Console.Clear();
                                Printline("—————————————————————————————Primer Parcial————————————————————————————");
                                Printline("***********************Registro de Nuevo Empleado**********************");
                                Printline("");
                                Print("Nombre: ");
                                string nombre = Console.ReadLine();
                                Print("Apellido: ");
                                string apellido = Console.ReadLine();
                                Print("Cedula: ");
                                string cedula = Console.ReadLine();
                                Print("Sueldo bruto: ");
                                double sueldobruto = double.Parse(Console.ReadLine());
                                Printline("");
                                Printline("-----------------------------------------------------------------------\n");
                                Printline("****************************Confirmar Datos****************************\n");
                                Printline($"" +
                                            $"Nombre Colaborador  : {nombre} {apellido}\n" +
                                            $"Cedula              : {cedula}\n" +
                                            $"Sueldo Bruto        : RD{sueldobruto:C2}\n");

                                Print("Volver al Registro de Empleado <R> o Confirmar datos <C>: ");
                                char confirmar = Console.ReadLine().ToUpper()[0];
                                if (confirmar != 'C')
                                {
                                    goto volver;
                                }

                                var formulario = empleadosRepositorio.createEmpleado(new Empleado() { Nombre = nombre, Apellido = apellido, Cedula = cedula, sueldoBruto = sueldobruto });
                                Printline("");
                                Printline(formulario.Message);

                                Print("Crear otro Empleado <C> o Volver al Menú <M>: ");
                                continuar = Console.ReadLine().ToUpper()[0];
                            }
                        }break;

                    case "2": //Buscar por 
                        {
                            Console.Clear();
                            char continuar = 'P';
                            while (continuar != 'M')
                            {
                                Console.Clear();
                                Printline("—————————————————————————————Primer Parcial————————————————————————————");
                                Printline("*************************Busqueda de Empleados*************************");
                                Printline("");

                                Print("Cedula del empleado a buscar: ");
                                string cedulaEmpleado = Console.ReadLine();

                                OperationResult empleado = empleadosRepositorio.findByCedula(cedulaEmpleado);

                                if (!empleado.Result)
                                {
                                    Printline(empleado.Message);
                                }
                                else
                                {
                                    DataTable dataEmpleado = (DataTable)empleado.Data;

                                    foreach (DataRow emp in dataEmpleado.Rows)
                                    {
                                        Printline($"" +
                                            $"Nombre Colaborador  : {emp["Nombre"]} {emp["Apellido"]}\n" +
                                            $"Sueldo Bruto        : RD{(emp["sueldoBruto"]):C2}\n" +
                                            $"Retencion AFP       : RD{(emp["AFP"]):C2}\n" +
                                            $"Retencion ARS       : RD{(emp["ARS"]):C2}\n" +
                                            $"Total Retenciones   : RD{(emp["totalRetenciones"]):C2}\n" +
                                            $"Sueldo Neto         : RD{(emp["sueldoNeto"]):C2}");

                                        Printline("-----------------------------------------------------------------------\n");
                                    }
                                }
                                Printline("");
                                Print("Buscar otro Empleado <B> o Volver al Menú <M>: ");
                                continuar = Console.ReadLine().ToUpper()[0];
                            }
                        }break;

                    case "3": //Actualizar
                        {
                            Console.Clear();
                            char continuar = 'P';
                            while (continuar != 'M')
                            {
                                Console.Clear();
                                Printline("—————————————————————————————Primer Parcial—————————————————————————————");
                                Printline("**************************Actualizar Empleado**************************");
                                Printline("");

                                Print("Cedula de empleado a modificar: ");
                                string cedulaEmpleado = Console.ReadLine();

                                OperationResult empleado = empleadosRepositorio.findByCedula(cedulaEmpleado);

                                if (!empleado.Result)
                                {
                                    Printline(empleado.Message);
                                }
                                else
                                {
                                    DataTable dataEmpleado = (DataTable)empleado.Data;

                                    foreach (DataRow emp in dataEmpleado.Rows)
                                    {
                                        Printline($"" +
                                            $"Nombre Colaborador  : {emp["Nombre"]} {emp["Apellido"]}\n" +
                                            $"Sueldo Bruto        : RD{(emp["sueldoBruto"]):C2}\n" +
                                            $"Retencion AFP       : RD{(emp["AFP"]):C2}\n" +
                                            $"Retencion ARS       : RD{(emp["ARS"]):C2}\n" +
                                            $"Total Retenciones   : RD{(emp["totalRetenciones"]):C2}\n" +
                                            $"Sueldo Neto         : RD{(emp["sueldoNeto"]):C2}");

                                        Printline("-----------------------------------------------------------------------\n");
                                    }

                                    Print("Nuevo sueldo bruto: ");
                                    double newsueldoBruto = double.Parse(Console.ReadLine());

                                    var update = empleadosRepositorio.updateEmpleado(new Empleado() { sueldoBruto = newsueldoBruto, Cedula = cedulaEmpleado}, cedulaEmpleado);
                                    Printline(update.Message);
                                }
                                Printline("");
                                Print("Actualizar otro Empleado <A> o Volver al Menú <M>: ");
                                continuar = Console.ReadLine().ToUpper()[0];
                            }
                        }break;

                    case "4": //Borrar
                        {
                            Console.Clear();
                            char continuar = 'P';
                            while (continuar != 'M')
                            {
                                Console.Clear();
                                Printline("—————————————————————————————Primer Parcial—————————————————————————————");
                                Printline("****************************Eliminar empleado***************************");
                                Printline("");

                                Print("Cedula del Empelado a eliminar: ");
                                string cedulaEmpleado = Console.ReadLine();

                                OperationResult empleado = empleadosRepositorio.findByCedula(cedulaEmpleado);

                                if (!empleado.Result)
                                {
                                    Printline(empleado.Message);
                                }
                                else
                                {
                                    DataTable dataEmpleado = (DataTable)empleado.Data;

                                    foreach (DataRow emp in dataEmpleado.Rows)
                                    {
                                        Printline($"" +
                                            $"Nombre Colaborador  : {emp["Nombre"]} {emp["Apellido"]}\n" +
                                            $"Sueldo Bruto        : RD{(emp["sueldoBruto"]):C2}\n" +
                                            $"Retencion AFP       : RD{(emp["AFP"]):C2}\n" +
                                            $"Retencion ARS       : RD{(emp["ARS"]):C2}\n" +
                                            $"Total Retenciones   : RD{(emp["totalRetenciones"]):C2}\n" +
                                            $"Sueldo Neto         : RD{(emp["sueldoNeto"]):C2}");

                                        Printline("-----------------------------------------------------------------------\n");
                                    }

                                    Print("Está seguro que desea borra el empleado? S/N: ");
                                    var confirmar = Console.ReadLine();

                                    if (confirmar.ToUpper() == "S")
                                    {
                                        var delete = empleadosRepositorio.softDelete(cedulaEmpleado);
                                        Printline(delete.Message);
                                    }
                                }
                                Printline("");
                                Print("Eliminar otro Empleado <E> o Volver al Menú <M>: ");
                                continuar = Console.ReadLine().ToUpper()[0];

                            }
                        }break;

                    case "5": //Salir
                        {
                            Print("\nPase feliz resto del día!!!.\nPresione <ENTER> para Salir...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }break;

                    default:
                        {
                            Print("\nFavor digitar una de las opciones listadas.\nPresione <ENTER> para volver al Menú...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }break;
                }
            } while (opcion != "5");
        }
    }
}