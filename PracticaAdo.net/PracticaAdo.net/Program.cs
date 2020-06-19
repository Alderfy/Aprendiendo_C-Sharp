using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Practica_Ado.net
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

        static iSuplidoresRepositorio suplidoresRepositorio = new SuplidorRepositorio();
        public static void Main(string[] args)
        {

            string opcion = null;
            do
            {
                Console.Clear();
                Printline("—————————————————————————————X Solucciones—————————————————————————————");
                Printline("********************Sistema de Gestión de Suplidores*******************");
                Printline("-----------------------------------------------------------------------");
                Printline($"                                                  {DateTime.Now.ToString()}");

                Printline("");
                Printline("1 - Crear Suplidor" +
                "\n2 - Listar todos los Suplidores" +
                "\n3 - Buscar Suplidor por RNC" +
                "\n4 - Actualizar Suplidor" +
                "\n5 - Borrar Suplidor" +
                "\n6 - Salir\n");
                Print("Opcion: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": //Crear Suplidor
                        {
                            char continuar = 'P';
                            while (continuar != 'M')
                            {
                                Console.Clear();
                                Printline("—————————————————————————————X Solucciones—————————————————————————————");
                                Printline("**********************Registro de Nuevo Suplidor***********************");
                                Printline("");
                                Print("Nombre del Suplidor: ");
                                string nombre = Console.ReadLine();
                                Print("RNC del Suplidor: ");
                                string rnc = Console.ReadLine();
                                Print("Dirección del Suplidor: ");
                                string direccion = Console.ReadLine();
                                Print("Representante del Suplidor: ");
                                string representante = Console.ReadLine();


                                var formulario = suplidoresRepositorio.Create(new Suplidor() { Nombre = nombre, RNC = rnc, Direccion = direccion, Representante = representante, });
                                Printline("");
                                Printline(formulario.Message);

                                Print("Crear otro Suplidor <S> o Volver al Menú <M>: ");
                                continuar = Console.ReadLine().ToUpper()[0];
                            }
                        }
                        break;

                    case "2": //Listar todos los Suplidores
                        {
                            Console.Clear();
                            Printline("—————————————————————————————X Solucciones—————————————————————————————");
                            Printline("********************Lista de Suplidores Registrados********************");
                            Printline("");
                            OperationResult suplidores = suplidoresRepositorio.GetAll();

                            if (!suplidores.Result)
                            {
                                Printline(suplidores.Message);
                            }
                            else
                            {
                                DataTable dataSuplidores = (DataTable)suplidores.Data;

                                foreach (DataRow sup in dataSuplidores.Rows)
                                {
                                    Printline($"" +
                                        $"Nombre Suplidor   : {sup["Nombre"]}\n" +
                                        $"RNC               : {sup["RNC"]}\n" +
                                        $"Representante     : {sup["Representante"]}\n" +
                                        $"Fecha de Registro : {sup["fechaRegistro"]}");
                                    Printline("-----------------------------------------------------------------------\n");
                                }
                            }
                            Print("Presione <ENTER> para volver al Menú...");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        break;

                    case "3": //Buscar Suplidor por RNC
                        {
                            Console.Clear();
                            char continuar = 'P';
                            while (continuar != 'M')
                            {
                                Console.Clear();
                                Printline("—————————————————————————————X Solucciones—————————————————————————————");
                                Printline("*************************Busqueda de Suplidores************************");
                                Printline("");

                                Print("RNC a Buscar: ");
                                string rncSuplidor = Console.ReadLine();

                                OperationResult suplidor = suplidoresRepositorio.FindByRNC(rncSuplidor);

                                if (!suplidor.Result)
                                {
                                    Printline(suplidor.Message);
                                }
                                else
                                {
                                    DataTable dataSuplidor = (DataTable)suplidor.Data;

                                    foreach (DataRow sup in dataSuplidor.Rows)
                                    {
                                        Printline($"" +
                                            $"Nombre Suplidor   : {sup["Nombre"]}\n" +
                                            $"RNC               : {sup["RNC"]}\n" +
                                            $"Representante     : {sup["Representante"]}\n" +
                                            $"Fecha de Registro : {sup["fechaRegistro"]}");
                                        Printline("-----------------------------------------------------------------------\n");
                                    }
                                }
                                Printline("");
                                Print("Buscar otro Suplidor <B> o Volver al Menú <M>: ");
                                continuar = Console.ReadLine().ToUpper()[0];
                            }
                        }
                        break;

                    case "4": //Actualizar Suplidor
                        {
                            Console.Clear();
                            char continuar = 'P';
                            while (continuar != 'M')
                            {
                                Console.Clear();
                                Printline("—————————————————————————————X Solucciones—————————————————————————————");
                                Printline("**************************Actualizar Suplidor**************************");
                                Printline("");

                                Print("RNC a modificar: ");
                                string rncSuplidor = Console.ReadLine();

                                OperationResult suplidor = suplidoresRepositorio.FindByRNC(rncSuplidor);

                                if (!suplidor.Result)
                                {
                                    Printline(suplidor.Message);
                                }
                                else
                                {
                                    DataTable dataSuplidor = (DataTable)suplidor.Data;

                                    foreach (DataRow sup in dataSuplidor.Rows)
                                    {
                                        Printline($"" +
                                            $"Nombre Suplidor   : {sup["Nombre"]}\n" +
                                            $"RNC               : {sup["RNC"]}\n" +
                                            $"Representante     : {sup["Representante"]}\n" +
                                            $"Fecha de Registro : {sup["fechaRegistro"]}");
                                        Printline("-----------------------------------------------------------------------\n");
                                    }

                                    Print("Nueva Direccion: ");
                                    var newDireccion = Console.ReadLine();
                                    Print("Nuevo Representante: ");
                                    var newRepresentante = Console.ReadLine();

                                    var update = suplidoresRepositorio.Update(new Suplidor() { Direccion = newDireccion, Representante = newRepresentante, RNC = rncSuplidor }, rncSuplidor);
                                    Printline(update.Message);
                                }
                                Printline("");
                                Print("Actualizar otro Suplidor <A> o Volver al Menú <M>: ");
                                continuar = Console.ReadLine().ToUpper()[0];
                            }
                        }
                        break;

                    case "5": //Borrar Suplidor
                        {
                            Console.Clear();
                            char continuar = 'P';
                            while (continuar != 'M')
                            {
                                Console.Clear();
                                Printline("—————————————————————————————X Solucciones—————————————————————————————");
                                Printline("***************************Eliminar Suplidor***************************");
                                Printline("");

                                Print("RNC a eliminar: ");
                                string rncSuplidor = Console.ReadLine();

                                OperationResult suplidor = suplidoresRepositorio.FindByRNC(rncSuplidor);

                                if (!suplidor.Result)
                                {
                                    Printline(suplidor.Message);
                                }
                                else
                                {
                                    DataTable dataSuplidor = (DataTable)suplidor.Data;

                                    foreach (DataRow sup in dataSuplidor.Rows)
                                    {
                                        Printline($"" +
                                            $"Nombre Suplidor   : {sup["Nombre"]}\n" +
                                            $"RNC               : {sup["RNC"]}\n" +
                                            $"Representante     : {sup["Representante"]}\n" +
                                            $"Fecha de Registro : {sup["fechaRegistro"]}");
                                        Printline("-----------------------------------------------------------------------\n");
                                    }

                                    Print("Está seguro que desea borra el Suplidor? S/N: ");
                                    var confirmar = Console.ReadLine();

                                    if (confirmar.ToUpper() == "S")
                                    {
                                        var delete = suplidoresRepositorio.SoftDelete(rncSuplidor);
                                        Printline(delete.Message);
                                    }
                                }
                                Printline("");
                                Print("Eliminar otro Suplidor <E> o Volver al Menú <M>: ");
                                continuar = Console.ReadLine().ToUpper()[0];

                            }
                        }
                        break;

                    case "6": //Salir
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
            } while (opcion != "6");

        }
    }
}