/*
15.	Calculadora Científica Básica
•	Usa una variable global para guardar el último resultado calculado.
•	Crea métodos con variables locales para realizar:
        i.	Suma, resta, multiplicación y división.
        ii.	Potencias y raíces cuadradas.
•	Cada vez que se realice una operación, el último resultado debe actualizarse en la variable global.
*/
using System;
using System.Collections.Generic;

namespace Ejercicio15
{
    class Program
    {
        // Variables globales
        static string ultimoResultado = "Ninguno";
        static List<string> historialResultados = new List<string>();

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Calculadora Científica Básica ===\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Último resultado: {ultimoResultado}\n");
                Console.ResetColor();

                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicación");
                Console.WriteLine("4. División");
                Console.WriteLine("5. Potencia");
                Console.WriteLine("6. Raíz cuadrada");
                Console.WriteLine("7. Revisar historial de resultados");
                Console.WriteLine("8. Limpiar historial");
                Console.WriteLine("9. Salir\n");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine()?.Trim() ?? "";

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("=== SUMA ===\n");
                        Suma();
                        Pausa();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("=== RESTA ===\n");
                        Resta();
                        Pausa();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("=== MULTIPLICACIÓN ===\n");
                        Multiplicacion();
                        Pausa();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("=== DIVISIÓN ===\n");
                        Division();
                        Pausa();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("=== POTENCIA ===\n");
                        Potencia();
                        Pausa();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("=== RAÍZ CUADRADA ===\n");
                        RaizCuadrada();
                        Pausa();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("=== HISTORIAL DE RESULTADOS ===\n");
                        MostrarHistorial();
                        Pausa();
                        break;
                    case "8":
                        Console.Clear();
                        historialResultados.Clear();
                        ultimoResultado = "Ninguno";
                        MensajeExito("Historial borrado correctamente.");
                        Pausa();
                        break;
                    case "9":
                        Console.Clear();
                        MensajeExito("Gracias por usar la calculadora. ¡Hasta pronto!");
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
        static double LeerNumero(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double n))
                    return n;
                MensajeError("Entrada inválida. Debe ingresar un número.");
            }
        }

        // ===== Operaciones =====
        static void GuardarResultado(string operacion, double resultado, bool usarDosPuntos = false)
        {
            double redondeado = Math.Round(resultado, 2); // redondear a 2 decimales
            string registro = usarDosPuntos ? $"{operacion}: {redondeado}" : $"{operacion} = {redondeado}";
            ultimoResultado = redondeado.ToString(); // solo el valor para el menú
            historialResultados.Add(registro);
            MensajeExito($"\nResultado: {redondeado}");
        }

        static void Suma()
        {
            double a = LeerNumero("Ingrese el primer número: ");
            double b = LeerNumero("Ingrese el segundo número: ");
            GuardarResultado($"{a} + {b}", a + b);
        }

        static void Resta()
        {
            double a = LeerNumero("Ingrese el primer número: ");
            double b = LeerNumero("Ingrese el segundo número: ");
            GuardarResultado($"{a} - {b}", a - b);
        }

        static void Multiplicacion()
        {
            double a = LeerNumero("Ingrese el primer número: ");
            double b = LeerNumero("Ingrese el segundo número: ");
            GuardarResultado($"{a} * {b}", a * b);
        }

        static void Division()
        {
            double a = LeerNumero("Ingrese el dividendo: ");
            double b;
            do
            {
                b = LeerNumero("Ingrese el divisor: ");
                if (b == 0) MensajeError("No se puede dividir entre cero.");
            } while (b == 0);

            GuardarResultado($"{a} / {b}", a / b);
        }

        static void Potencia()
        {
            double baseNum = LeerNumero("Ingrese la base: ");
            double exponente = LeerNumero("Ingrese el exponente: ");
            GuardarResultado($"{baseNum} ^ {exponente}", Math.Pow(baseNum, exponente));
        }

        static void RaizCuadrada()
        {
            double num;
            do
            {
                num = LeerNumero("Ingrese un número: ");
                if (num < 0) MensajeError("No se puede calcular la raíz cuadrada de un número negativo.");
            } while (num < 0);

            GuardarResultado($"Raíz cuadrada de {num}", Math.Sqrt(num), usarDosPuntos: true);
        }

        static void MostrarHistorial()
        {
            if (historialResultados.Count == 0)
            {
                MensajeError("No hay resultados registrados.");
                return;
            }

            for (int i = 0; i < historialResultados.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {historialResultados[i]}");
            }
        }
    }
}
