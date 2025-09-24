// 3.	Conversor de temperatura con variable global
using System;
using System.Globalization;

class Programa
{
    // Variable global: define la escala de conversión
    static string escalaConversion;

    static void Main()
    {
        try
        {
            // Preguntar al usuario qué conversión desea
            Console.WriteLine("Seleccione la escala de conversión:");
            Console.WriteLine("1. Celsius → Fahrenheit");
            Console.WriteLine("2. Fahrenheit → Celsius");
            Console.Write("Opción (1/2): ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
                escalaConversion = "CtoF";
            else if (opcion == "2")
                escalaConversion = "FtoC";
            else
                throw new ArgumentException("Opción inválida. Debe ser 1 o 2."); //Esto es útil para validar entradas y evitar que el programa siga corriendo con datos incorrectos.

            // Pedir la temperatura
            Console.Write("Ingrese la temperatura: ");
            string entrada = Console.ReadLine();

            // Intentar convertir a número decimal (punto como separador decimal)
            double temperatura = double.Parse(entrada, CultureInfo.InvariantCulture);

            // Hacer la conversión usando la variable global
            double resultado = ConvertirTemperatura(temperatura);
            Console.WriteLine($"Resultado de la conversión ({escalaConversion}): {resultado:F2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: debe ingresar un número válido (ejemplo: 36.5 con punto decimal).");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: el número ingresado es demasiado grande o pequeño.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(" Error " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Ocurrió un error inesperado: {ex.Message}");
        }
    }

    static double ConvertirTemperatura(double valor)
    {
        // Usa la variable global escalaConversion
        if (escalaConversion == "CtoF")
        {
            return (valor * 9 / 5) + 32; // Celsius → Fahrenheit
        }
        else if (escalaConversion == "FtoC")
        {
            return (valor - 32) * 5 / 9; // Fahrenheit → Celsius
        }
        else
        {
            throw new InvalidOperationException("La escala de conversión global no es válida.");
        }
    }
}
