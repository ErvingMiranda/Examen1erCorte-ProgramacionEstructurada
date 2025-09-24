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
        CalcularAreaRectangulo();
    }

    static void CalcularAreaRectangulo()
    {
        try
        {
            // Variables locales
            Console.Write("Ingrese la base del rectángulo: ");
            string entradaBase = Console.ReadLine();

            // Se intenta convertir con soporte a decimales usando cultura invariante
            double baseRectangulo = double.Parse(entradaBase, CultureInfo.InvariantCulture);

            Console.Write("Ingrese la altura del rectángulo: ");
            string entradaAltura = Console.ReadLine();
            double alturaRectangulo = double.Parse(entradaAltura, CultureInfo.InvariantCulture); // Permite que el separador decimal sea punto (.) en lugar de coma

            // Cálculo local
            double area = baseRectangulo * alturaRectangulo;
            Console.WriteLine($"El área del rectángulo es: {area}");
        }
        catch (FormatException)
        {
            Console.WriteLine(" Error: Debe ingresar un número válido (use punto como separador decimal, ejemplo: 10.5).");
        }
        catch (OverflowException) // por si el numero es demasiado grande o pequeño para el double
        {
            Console.WriteLine(" Error: El número ingresado es demasiado grande o demasiado pequeño.");
        }
        catch (Exception ex) // se usa para tener mas control y muestra mas detalle del error
        {
            Console.WriteLine($" Ocurrió un error inesperado: {ex.Message}");
        }
    }
}






