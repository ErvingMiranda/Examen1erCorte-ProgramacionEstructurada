/*
3.	Conversor de temperatura con variable global
    -Declara una variable global que indique la escala de conversión (ejemplo: Celsius a Fahrenheit). Haz un método que use esa variable para realizar la conversión.
*/
using System;
using System.Globalization;

class Programa
{
    // Variable global: define la escala de conversión
    static string escalaConversion = "CtoF"; // valor por defecto

    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            MostrarMenu();

            Console.Write("\nSeleccione una opción (1-3): ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    escalaConversion = "CtoF";
                    ProcesarConversion();
                    Pausa();
                    break;

                case "2":
                    escalaConversion = "FtoC";
                    ProcesarConversion();
                    Pausa();
                    break;

                case "3":
                    continuar = false;
                    break;

                default:
                    Mensaje("Error: opción inválida. Elija 1, 2 o 3.", ConsoleColor.Red);
                    Pausa();
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("=== Conversor de Temperatura ===");
        Console.WriteLine("1) Celsius a Fahrenheit");
        Console.WriteLine("2) Fahrenheit a Celsius");
        Console.WriteLine("3) Salir");
    }

    static void ProcesarConversion()
    {
        try
        {
            Console.Write("\nIngrese la temperatura: ");
            string entrada = Console.ReadLine();

            // Acepta coma o punto como separador decimal
            entrada = entrada.Replace(',', '.');
            double valor = double.Parse(entrada, CultureInfo.InvariantCulture);

            double resultado = ConvertirTemperatura(valor);

            if (escalaConversion == "CtoF")
            {
                // Ej: "25.00 Celsius son 77.00 Fahrenheit"
                Mensaje($"{valor:F2} Celsius son {resultado:F2} Fahrenheit", ConsoleColor.Green);
            }
            else // FtoC
            {
                Mensaje($"{valor:F2} Fahrenheit son {resultado:F2} Celsius", ConsoleColor.Green);
            }
        }
        catch (FormatException)
        {
            Mensaje("Error: ingrese un número válido (ej.: 36.5 o 36,5).", ConsoleColor.Red);
        }
        catch (OverflowException)
        {
            Mensaje("Error: el número ingresado es demasiado grande o pequeño.", ConsoleColor.Red);
        }
        catch (Exception ex)
        {
            Mensaje($"Error inesperado: {ex.Message}", ConsoleColor.Red);
        }
    }

    static double ConvertirTemperatura(double valor)
    {
        if (escalaConversion == "CtoF")
            return (valor * 9.0 / 5.0) + 32.0;      // Celsius → Fahrenheit
        else if (escalaConversion == "FtoC")
            return (valor - 32.0) * 5.0 / 9.0;      // Fahrenheit → Celsius
        else
            throw new InvalidOperationException("La escala de conversión global no es válida.");
    }

    static void Mensaje(string texto, ConsoleColor color)
    {
        var prev = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(texto);
        Console.ForegroundColor = prev;
    }

    static void Pausa()
    {
        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey(true); // pausa con Write (sin salto) y sin eco
    }
}
