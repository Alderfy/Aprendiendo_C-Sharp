using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;

namespace Practica_Linq
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Persona> personas = new List<Persona>()
            {
                new Persona(){Nombre = "Andrea", Apellido = "Reyes", fechaNaciemiento = new DateTime (2018,1,9), Sexo = 'F', lugarNacimiento = "SANTO DOMINGO"},
                new Persona(){Nombre = "Andrea", Apellido = "Gonzalez", fechaNaciemiento = new DateTime (1990,3,29), Sexo = 'F', lugarNacimiento = "SANTIAGO"},
                new Persona(){Nombre = "Andrés", Apellido = "Reyes", fechaNaciemiento = new DateTime (2000,4,19), Sexo = 'M', lugarNacimiento = "SAN JUAN"},
                new Persona(){Nombre = "Antonia", Apellido = "Reyes", fechaNaciemiento = new DateTime (1984,6,21), Sexo = 'F', lugarNacimiento = "SAN JUAN"},
                new Persona(){Nombre = "Antonio", Apellido = "Reyes", fechaNaciemiento = new DateTime (1970,3,30), Sexo = 'M', lugarNacimiento = "SAN CRISTOBAL"},
                new Persona(){Nombre = "Antonio", Apellido = "Castro", fechaNaciemiento = new DateTime (1965,5,30), Sexo = 'M', lugarNacimiento = "SAN PEDRO DE MACORIS"},
                new Persona(){Nombre = "Bartolomé", Apellido = "Castro", fechaNaciemiento = new DateTime (1980,4,23), Sexo = 'M', lugarNacimiento = "SAN FRANCISCO DE MACORIS"},
                new Persona(){Nombre = "Belén", Apellido = "Castro", fechaNaciemiento = new DateTime (1980,4,24), Sexo = 'F', lugarNacimiento = "SANTO DOMINGO"},
                new Persona(){Nombre = "Felicia", Apellido = "Gonzalez", fechaNaciemiento = new DateTime (1980,4,25), Sexo = 'F', lugarNacimiento = "SANTO DOMINGO"},
                new Persona(){Nombre = "Gaspar", Apellido = "Baez", fechaNaciemiento = new DateTime (1980,4,26), Sexo = 'M', lugarNacimiento = "SAN JUAN"},
                new Persona(){Nombre = "Rafaela", Apellido = "Baez", fechaNaciemiento = new DateTime (1954,10,30), Sexo = 'F', lugarNacimiento = "BARAHONA"},
                new Persona(){Nombre = "Gimenez", Apellido = "De Jesus", fechaNaciemiento = new DateTime (1960,8,30), Sexo = 'M', lugarNacimiento = "SAMANA"},
                new Persona(){Nombre = "Luis", Apellido = "Gonzalez", fechaNaciemiento = new DateTime (2011,11,10), Sexo = 'M', lugarNacimiento = "BAHORUCO"},
                new Persona(){Nombre = "Luisa", Apellido = "De Jesus", fechaNaciemiento = new DateTime (2008,12,3), Sexo = 'F', lugarNacimiento = "PEDERNALES"},
                new Persona(){Nombre = "Luis", Apellido = "Almonte", fechaNaciemiento = new DateTime (2015,2,5), Sexo = 'M', lugarNacimiento = "PEDERNALES"},
                new Persona(){Nombre = "Gustavo", Apellido = "De Jesus", fechaNaciemiento = new DateTime (2011,11,11), Sexo = 'M', lugarNacimiento = "SANTIAGO"},
                new Persona(){Nombre = "Jacinto", Apellido = "López", fechaNaciemiento = new DateTime (2010,9,30), Sexo = 'M', lugarNacimiento = "PUERTO PLATA"},
                new Persona(){Nombre = "Jesús", Apellido = "López", fechaNaciemiento = new DateTime (1978,9,27), Sexo = 'M', lugarNacimiento = "PUERTO PLATA"},
                new Persona(){Nombre = "Josefina", Apellido = "López", fechaNaciemiento = new DateTime (1955,3,4), Sexo = 'F', lugarNacimiento = "SAN CRISTOBAL"}
            };

            Console.WriteLine("1. Mostrar las personas menores de edad de sexo masculino");
            var persona1 = personas.Where(x => x.Edad < 18 && x.Sexo == 'M');
            foreach (Persona item in persona1)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}\n" +
                    $"Edad                  : {item.Edad}\n" +
                    $"Sexo                  : {item.Sexo}\n" +
                    $"Lugar de Naciemiento  : {item.lugarNacimiento}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("2. Mostrar solo el nombre y apellido de personas de sexo femenino");
            var persona2 = personas.Where(x => x.Sexo == 'F').Select(x => new { x.Nombre, x.Apellido});
            foreach (var item in persona2)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("3. Indicar si existe alguien de mas de 65 años");
            var persona3 = personas.Any(x => x.Edad > 65);
            if (persona3 == false)
            {
                Console.WriteLine("No exiten personas con mas de 65 años");
            }
            else
            {
                Console.WriteLine("Existen personas de mas de 65 años");
            }
            
            Console.WriteLine("");
            Console.WriteLine("4. Indicar si todas las personas son mayores de edad");
            var persona4 = personas.All(x => x.Edad > 18);
            if (persona4 == false)
            {
                Console.WriteLine("No todos son mayores de edad");
            }
            else
            {
                Console.WriteLine("Todos son mayores de edad");
            }

            Console.WriteLine("");
            Console.WriteLine("5. Mostrar la primera persona de la lista");
            var persona5 = personas.Take(1);
            foreach (var item in persona5)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}\n" +
                    $"Edad                  : { item.Edad}\n" +
                    $"Sexo                  : {item.Sexo}\n" +
                    $"Lugar de Naciemiento  : {item.lugarNacimiento}");
            }

            Console.WriteLine("");
            Console.WriteLine("6. Mostrar las personas de la provincia Santo Domingo");
            var persona6 = personas.Where(x => x.lugarNacimiento == "SANTO DOMINGO");
            foreach (var item in persona6)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}\n" +
                    $"Edad                  : { item.Edad}\n" +
                    $"Sexo                  : {item.Sexo}\n" +
                    $"Lugar de Naciemiento  : {item.lugarNacimiento}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("7. Mostrar las personas de la provincia Santiago de sexo femenino y que sean mayores de edad");
            var persona7 = personas.Where(x => x.lugarNacimiento == "SANTIAGO" && x.Sexo == 'F' && x.Edad >= 18);
            foreach (var item in persona7)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}\n" +
                    $"Edad                  : { item.Edad}\n" +
                    $"Sexo                  : {item.Sexo}\n" +
                    $"Lugar de Naciemiento  : {item.lugarNacimiento}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("8. Mostrar las últimos 10 personas");
            var persona8 = personas.Skip(9);
            foreach (var item in persona8)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}\n" +
                    $"Edad                  : { item.Edad}\n" +
                    $"Sexo                  : {item.Sexo}\n" +
                    $"Lugar de Naciemiento  : {item.lugarNacimiento}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("9. Mostrar las personas de sexo masculino que sean de Pedernales y San Juan");
            var persona9 = personas.Where(x => x.Sexo == 'M' && x.lugarNacimiento == "PEDERNALES" || x.lugarNacimiento == "SAN JUAN");
            foreach (var item in persona9)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}\n" +
                    $"Edad                  : { item.Edad}\n" +
                    $"Sexo                  : {item.Sexo}\n" +
                    $"Lugar de Naciemiento  : {item.lugarNacimiento}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("10. Mostrar las personas de apellidos Reyes y López. De esta lista solo seleccionar su nombre y edad");
            var persona10 = personas.Where(x => x.Apellido == "Reyes" || x.Apellido == "Lopez").Select(x => new { x.Nombre, x.Edad });
            foreach (var item in persona10)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Edad                  : {item.Edad}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("11. Mostrar las personas de Felicia en adelante. No usar método Take");
            var persona11 = personas.Skip(8);
            foreach (var item in persona11)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}\n" +
                    $"Edad                  : { item.Edad}\n" +
                    $"Sexo                  : {item.Sexo}\n" +
                    $"Lugar de Naciemiento  : {item.lugarNacimiento}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("12. Mostrar las personas entre 18 y 40 años de edad");
            var persona12 = personas.Where(x => x.Edad >= 18 && x.Edad <= 40);
            foreach (var item in persona12)
            {
                Console.WriteLine($"" +
                    $"Nombre                : {item.Nombre}\n" +
                    $"Apellido              : {item.Apellido}\n" +
                    $"Edad                  : { item.Edad}\n" +
                    $"Sexo                  : {item.Sexo}\n" +
                    $"Lugar de Naciemiento  : {item.lugarNacimiento}");
                Console.WriteLine("--------------------------------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("13. Determinar si todas las personas de Santo Domingo son sexo femenino.");
            var persona13 = personas.All(x => x.Sexo =='F');
            if (persona13 == false)
            {
                Console.WriteLine("No todos son de sexo femenino");
            }
            else
            {
                Console.WriteLine("Todos son de sexo femenino");
            }

            Console.ReadLine();
        }
    }
}
