// Edad de una persona Con varias locales
using System;

class Programa
{
    static void Main()
    {
        CalcularEdad();
    }

    static void CalcularEdad()
    {
        try
        {
            // Variables locales
            Console.Write("Ingrese su año de nacimiento: ");
            string entrada = Console.ReadLine();
            int anioNacimiento = int.Parse(entrada);

            // Obtenemos el año actual desde el sistema
            int anioActual = DateTime.Now.Year;

            // Variable local para la edad
            int edad = anioActual - anioNacimiento;

            if (edad < 0)
            {
                Console.WriteLine(" Error: el año de nacimiento no puede ser mayor que el actual.");
            }
            else
            {
                Console.WriteLine($"Su edad aproximada es: {edad} años.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine(" Error: debe ingresar un número válido (ejemplo: 1990).");
        }
        catch (OverflowException)
        {
            Console.WriteLine(" Error: el año ingresado es demasiado grande o demasiado pequeño.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Ocurrió un error inesperado: {ex.Message}");
        }
    }
}

