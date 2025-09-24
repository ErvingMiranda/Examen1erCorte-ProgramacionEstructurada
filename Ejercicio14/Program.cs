/*
14.	Gestión de Notas de Estudiantes
•	Declara una lista global que almacene todas las notas.
•	Métodos locales deben:
    -Agregar una nota.
    -Calcular el promedio (solo con variables locales).
    -Mostrar la nota más alta y la más baja.
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio14
{
    class Program
    {
        // Lista global para almacenar notas
        static List<double> notas = new List<double>();

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Notas de Estudiantes ===\n");
                Console.WriteLine("1. Agregar notas");
                Console.WriteLine("2. Calcular promedio");
                Console.WriteLine("3. Mostrar nota más alta y más baja");
                Console.WriteLine("4. Salir\n");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine()?.Trim() ?? "";

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        AgregarNotas();
                        Pausa();
                        break;
                    case "2":
                        Console.Clear();
                        CalcularPromedio();
                        Pausa();
                        break;
                    case "3":
                        Console.Clear();
                        MostrarMaxMin();
                        Pausa();
                        break;
                    case "4":
                        Console.Clear();
                        MensajeExito("Gracias por usar el sistema. ¡Hasta luego!\n");
                        continuar = false;
                        break;
                    default:
                        MensajeError("\nOpción no válida. Intente de nuevo.");
                        Pausa();
                        break;
                }
            }
        }

        // Elementos para mejorar la presentación
        static void MensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
        static void MensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
        static void Pausa()
        {
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // ===== Funcionalidad =====
        static void AgregarNotas()
        {
            Console.WriteLine("=== Agregar Notas ===\n");
            Console.WriteLine("Ingrese tantas notas como desee (0 - 100).");
            Console.WriteLine("Presione [Enter] vacío o escriba 'x' para terminar.");

            while (true)
            {
                Console.Write("\nNota: ");
                string entrada = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(entrada) || entrada.ToLower() == "x")
                {
                    MensajeExito("\nIngreso de notas finalizado.");
                    break;
                }

                if (double.TryParse(entrada, out double nota) && nota >= 0 && nota <= 100)
                {
                    notas.Add(nota);
                    MensajeExito($"Nota {nota} agregada.");
                }
                else
                {
                    MensajeError("Nota inválida. Debe ser un número entre 0 y 100.");
                }
            }
        }

        static void CalcularPromedio()
        {
            Console.WriteLine("=== Calcular Promedio ===\n");
            if (notas.Count == 0)
            {
                MensajeError("No hay notas registradas.");
                return;
            }

            double suma = 0;
            foreach (double n in notas)
            {
                suma += n;
            }
            double promedio = suma / notas.Count;

            MensajeExito($"El promedio de las notas es: {promedio:F2}");
        }

        static void MostrarMaxMin()
        {
            Console.WriteLine("=== Nota Máxima y Mínima ===\n");
            if (notas.Count == 0)
            {
                MensajeError("No hay notas registradas.");
                return;
            }

            double max = notas.Max();
            double min = notas.Min();

            Console.WriteLine($"Nota más alta: {max}");
            Console.WriteLine($"Nota más baja: {min}");
        }
    }
}
