using System;
using System.Collections.Generic;
using static System.Console;
using static System.Convert;

namespace ControlLibrosLeídos
{
    class Program
    {
        static List<Libro> listaLibros = new List<Libro>();
        static void Main()
        {
            int opcion;
            do
            {
                ResetColor();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("\n---------- Control de Libros Leídos ----------");
                ResetColor();
                WriteLine("\n1. Agregar libro.");
                WriteLine("2. Ver lista de libros.");
                WriteLine("3. Marcar libro favorito.");
                WriteLine("4. Salir");
                Write("\nElige una opción: ");
                opcion = ToInt32(ReadLine());

                switch (opcion)
                {
                    case 1: AgregarLibro(); break;
                    case 2: VerListaLibros(); break;
                    case 3: LibroFav(); break;
                    case 4: ForegroundColor = ConsoleColor.Green; Write("\nSalida exitosa!\n"); ResetColor(); break;
                    default: ForegroundColor = ConsoleColor.Red; Write("\nOpción no encontrada.\n"); break;
                }
            } while (opcion != 4);
        }

        private static void AgregarLibro()
        {
            Write("\nIngresa el TITULO del libro: ");
            string RespTitulo = ReadLine().ToUpper();
            Write("Ingresa el AUTOR del libro: ");
            string RespAutor = ReadLine().ToUpper();
            listaLibros.Add(new Libro(RespTitulo, RespAutor));
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\nLibro registrado correctamente!!!");
        }

        private static void VerListaLibros()
        {
            if (listaLibros.Count == 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nNO hay libros registrados aún.");
            }
            else
            {
                WriteLine($"\n LIBROS REGISTRADOS: ");
                foreach (Libro libros in listaLibros)
                {
                    WriteLine($"\n- Título: {libros.Titulo}, Autor: {libros.Autor}.");
                }
            }
        }

        private static void LibroFav()
        {
            if (listaLibros.Count == 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nNO hay libros registrados aún.");
                return;
            }
            VerListaLibros();

            Write("\nIngresa el TITULO de tu libro favorito: ");
            string tituloFav = ReadLine().ToUpper();
            foreach (var libro in listaLibros)
            {
                if (libro.Titulo == tituloFav)
                {
                    foreach (var libro1 in listaLibros)
                    {
                        libro1.Fav = false;
                    }
                    libro.Fav = true;
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"\n{libro.Titulo} de {libro.Autor} fue marcado como favorito.");
                    return;
                }
            }
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nLibro no registrado.");
        }
    }
}


/* 
1.  Aplico el Principio de Responsabilidad Única en mi solución, ya que la clase Libro se encarga únicamente de representar los datos de un libro (título, autor y si es favorito),
    mientras que la clase Program se encarga de la gestión de los libros por medio de los metodos agregar, mostrar y marcar favorito.

2.  Aplico el Principio Abierto/Cerrado ya que en el sistema se podría extender la funcionalidad agregando nuevos métodos como buscar libros por autor o permitir editarlos. 
    Así, sin modificar la estructura de la clase Libro. Además, se podría agregar nuevas funcionalidades en otra clase gestora sin alterar la definición básica del libro.

3.  Actualmente no aplico de forma completa el Principio de Inversión de Dependencias, ya que la clase Program depende directamente de la clase Libro, pero podria
    aplicar mejor este principio, creando una interfaz y hacer que Program trabaje con esa abstracción en lugar de depender directamente de la clase, logrando así un sistema más flexible. */