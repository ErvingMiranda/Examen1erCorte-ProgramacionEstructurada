/*
4.	Suma acumulada con variable global
    -Declara una variable global sumaTotal. Cada vez que el usuario ingrese un número (en un método), se debe sumar al acumulado y mostrar el total actualizado.
*/
using System;
using System.Globalization;

class Programa
{
    // Variable global: acumula la suma de todos los números ingresados
    static double sumaTotal = 0;

    static void Main()
    {
        Console.WriteLine("=== Acumulador Global de Números ===");
        Console.WriteLine("Escriba un número y presione ENTER. Escriba 'salir' para terminar.\n");

        while (true)
        {
            Console.Write("Ingrese un número (o 'salir'): ");
            string entrada = Console.ReadLine();

            // Salir del programa
            if (entrada.ToLower() == "salir") // Sirve para que el programa no dependa de si el usuario escribe mayúsculas o minúsculas. 
            {
                Console.WriteLine("\nPrograma finalizado.");
                Console.WriteLine($"Suma final acumulada: {sumaTotal}");
                break; // hace que el programa salga del bucle y termine.
            }

            try
            {
                // Convertir a número decimal (acepta punto como separador decimal)
                double numero = double.Parse(entrada, CultureInfo.InvariantCulture);

                // Llamada al método que actualiza la suma global
                AgregarNumero(numero);
            }
            catch (FormatException)
            {
                Console.WriteLine(" Error: Ingrese un número válido (ejemplo: 10.5).");
            }
            catch (OverflowException)
            {
                Console.WriteLine(" Error: El número ingresado es demasiado grande o pequeño.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
    }

    // Método que usa la variable global
    static void AgregarNumero(double valor)
    {
        sumaTotal += valor;
        Console.WriteLine($"Se agregó {valor}. Suma total acumulada: {sumaTotal}\n");
    }
}

