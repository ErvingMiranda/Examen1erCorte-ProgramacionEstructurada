/*
2.	Área de un rectángulo con variables locales
    -Crea un método que pida la base y altura de un rectángulo, use variables locales para calcular el área y la imprima en pantalla.
*/
using System;
using System.Globalization;

class Programa
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            CalcularAreaRectangulo();

            Console.Write("\nPresione una tecla para reiniciar o [Esc] para salir... ");
            var tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.Escape)
            {
                continuar = false;
            }
        }
    }

    static void CalcularAreaRectangulo()
    {
        try
        {
            Console.Write("Ingrese la base del rectángulo: ");
            string entradaBase = Console.ReadLine();

            // Permite tanto punto como coma
            entradaBase = entradaBase.Replace(',', '.');
            double baseRectangulo = double.Parse(entradaBase, CultureInfo.InvariantCulture);

            Console.Write("Ingrese la altura del rectángulo: ");
            string entradaAltura = Console.ReadLine();

            entradaAltura = entradaAltura.Replace(',', '.');
            double alturaRectangulo = double.Parse(entradaAltura, CultureInfo.InvariantCulture);

            // Validación: deben ser > 0
            if (baseRectangulo <= 0 || alturaRectangulo <= 0)
            {
                MostrarMensaje("Error: La base y la altura deben ser mayores que cero.", ConsoleColor.Red);
                return;
            }

            // Cálculo local
            double area = baseRectangulo * alturaRectangulo;
            MostrarMensaje($"Éxito: El área del rectángulo es {Math.Round(area, 2)}", ConsoleColor.Green);
        }
        catch (FormatException)
        {
            MostrarMensaje("Error: Debe ingresar un número válido (ejemplo: 10.5 o 10,5).", ConsoleColor.Red);
        }
        catch (OverflowException)
        {
            MostrarMensaje("Error: El número ingresado es demasiado grande o demasiado pequeño.", ConsoleColor.Red);
        }
        catch (Exception ex)
        {
            MostrarMensaje($"Error inesperado: {ex.Message}", ConsoleColor.Red);
        }
    }

    static void MostrarMensaje(string mensaje, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
}
