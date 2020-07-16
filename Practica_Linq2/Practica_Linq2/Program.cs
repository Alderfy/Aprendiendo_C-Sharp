using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace Practica_Linq2
{
    class Program
    {
        public static DataTable getAll()
        {
            string connString = ConfigurationManager.ConnectionStrings["linq"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "GetAll";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                    return dt;
                }
            }

            
        }
        public static void Main(string[] args)
        {
            List<Productos> prodList = new List<Productos>();
            DataTable prod = getAll();
            

            foreach (DataRow pr in prod.Rows)
            {
                prodList.Add(new Productos()
                {
                    nProducto = pr["Producto"].ToString(),
                    Categoria = pr["Categoria"].ToString(),
                    Suplidor = pr["Suplidor"].ToString(),
                    Precio = Convert.ToDouble(pr["Precio"]),
                    Almacen = pr["Almacen"].ToString(),
                });
            }

            Console.WriteLine("1. Mostrar los primeros 5 productos de la lista.");
            var prod1 = prodList.Take(5);
            foreach (Productos item in prod1)
            {
                Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("2. Mostrar los productos desde Magic Keyboard hasta Mouse pad");
            var prod2 = prodList.Skip(1).Take(5);
            foreach (Productos item in prod2)
            {
                Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("3. Mostrar los productos agrupados por categoría");
            var prod3 = prodList.GroupBy(x => x.Categoria);
            foreach (var grupo in prod3)
            {
                Console.WriteLine($"Categoria: {grupo.Key}");
                foreach (var item in grupo)
                {
                    Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                    Console.WriteLine("--------------------------------------------------");
                }
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("4. Mostrar los productos agrupados por almacén");
            var prod4 = prodList.GroupBy(x => x.Almacen);
            foreach (var grupo in prod4)
            {
                Console.WriteLine($"Categoria: {grupo.Key}");
                foreach (var item in grupo)
                {
                    Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}");
                    Console.WriteLine("--------------------------------------------------");
                }
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("5. Mostrar dos grupos según el almacén, los de Santo Domingo en el grupo “Ciudad” y el resto en el grupo “Interior país”");
            var prod5 = prodList.GroupBy(x =>
            { 
                if (x.Almacen == "SANTO DOMINGO")
                {
                    return "Ciudad";
                }
                else
                {
                    return "Interior País";
                }
            });

            foreach (var grupo in prod5)
            {
                Console.WriteLine(grupo.Key);
                foreach (var item in grupo)
                {
                    Console.WriteLine($"" +
                    $"Almacen       : {item.Almacen}\n" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}");
                    Console.WriteLine("--------------------------------------------------");
                }
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("6. Mostrar los productos ordenados de manera ascendente por Suplidor");
            var prod6 = prodList.OrderBy(x=> x.Suplidor);
            foreach (Productos item in prod6)
            {
                Console.WriteLine($"" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("7. Mostrar los productos ordenados de manera descendente por categoría y luego por almacén.");
            var prod7 = prodList.OrderByDescending(x=> x.Categoria).ThenBy(x=> x.Almacen);
            foreach (Productos item in prod7)
            {
                Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("8. Mostrar dos grupos de productos según su precio, los menores o igual a 10,000 “Bajo costo” y los mayores a 10,000 “Alto costo”");
            var prod8 = prodList.GroupBy(x =>
            {
                if (x.Precio <= 10000)
                {
                    return "Bajo Costo";
                }
                else
                {
                    return "Alto Costo";
                }
            });

            foreach (var grupo in prod8)
            {
                Console.WriteLine(grupo.Key);
                foreach (var item in grupo)
                {
                    Console.WriteLine($"" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Almacen       : {item.Almacen}");
                    Console.WriteLine("--------------------------------------------------");
                }
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("9. Mostrar el producto con precio mas alto del suplidor Cecomsa");
            var prod9 = prodList.Where(x=> x.Suplidor == "Cecomsa").Max(x=> x.Precio);
            var max = prodList.Where(x=> x.Precio == prod9 && x.Suplidor == "Cecomsa");

            foreach (Productos item in max)
            {
                Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("10. Mostrar el producto de menor costo");
            var prod10 = prodList.Min(x=> x.Precio);
            var min = prodList.Where(x=> x.Precio == prod10);

            foreach (Productos item in min)
            {
                Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("11. Mostrar los productos con precios entre los 5,000 hasta 15,000 agrupados por suplidor y ordenados de manera descendente por precio.");
            var prod11 = prodList.OrderByDescending(x=> x.Precio).Where(x => x.Precio >= 5000 && x.Precio <= 15000).GroupBy(x => x.Suplidor);
            foreach (var grupo in prod11)
            {
                Console.WriteLine($"Suplidor: {grupo.Key}");
                foreach (var item in grupo)
                {
                    Console.WriteLine($"" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Almacen       : {item.Almacen}");
                    Console.WriteLine("--------------------------------------------------");
                }
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("12. Mostrar el precio promedio del producto Mac Book Pro 13");
            var prod12 = prodList.Where(x=> x.nProducto == "Mac Book Pro 13").Average(x=> x.Precio);
            Console.WriteLine($"El precio promedio del producto Mac Book Pro 13 es {prod12:C2}");
                    
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("13. Mostrar los 5 productos mas costosos ordenados por precio de manera ascendente");
            var prod13 = prodList.OrderByDescending(x=> x.Precio).Take(5).OrderBy(x=> x.Precio);
            foreach (Productos item in prod13)
            {
                Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");

            Console.WriteLine("14. Mostrar los 5 productos mas económicos excluyendo almacenes de Santo Domingoe");
            var prod14 = prodList.OrderBy(x => x.Precio).Where(x=> x.Almacen != "SANTO DOMINGO").Take(5);
            foreach (Productos item in prod14)
            {
                Console.WriteLine($"" +
                    $"Producto      : {item.nProducto}\n" +
                    $"Categoria     : {item.Categoria}\n" +
                    $"Suplidor      : {item.Suplidor}\n" +
                    $"Precio        : {item.Precio:C2}\n" +
                    $"Almacen       : {item.Almacen}");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--------------------------------------------------");
            Console.Read();
        }
    }
}
