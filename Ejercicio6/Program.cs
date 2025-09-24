using System;
using System.Collections.Generic;

/*  
    6. Juego de intentos con variable global
    Crea un programa que use una variable global para almacenar
    el número de intentos de adivinar un número secreto. 
    Cada intento se registra y se muestra. 
 */

class Program
{
    // Variable global para contar intentos
    public static int intentos = 0;

    // Variable global para historial de intentos
    public static List<string> historial = new List<string>();

    static void Main()
    {
        // Genera número secreto entre 1 y 100
        Random randint = new Random();
        int numeroSecreto = randint.Next(1, 101);
        int numeroadivinado;

        Console.WriteLine("Adivina el número secreto entre 1 y 100.");

        do
        {
            Console.Write("Introduce un número: ");
            string entrada = Console.ReadLine() ?? "";

            intentos++;

            if (!int.TryParse(entrada, out numeroadivinado))
            {
                Console.WriteLine("Por favor, introduce un número válido.");
                historial.Add($"{intentos}. Entrada inválida: \"{entrada}\"");
                continue;
            }

            if (numeroadivinado < 1 || numeroadivinado > 100)
            {
                Console.WriteLine("El número debe estar entre 1 y 100.");
                historial.Add($"{intentos}. {numeroadivinado} (fuera de rango)");
            }
            else if (numeroadivinado < numeroSecreto)
            {
                Console.WriteLine("Muy bajo. Intenta de nuevo.");
                historial.Add($"{intentos}. {numeroadivinado}: Muy bajo");
            }
            else if (numeroadivinado > numeroSecreto)
            {
                Console.WriteLine("Muy alto. Intenta de nuevo.");
                historial.Add($"{intentos}. {numeroadivinado}: Muy alto");
            }
            else
            {
                Console.WriteLine($"\n¡Acertaste! El número secreto era {numeroSecreto}.");
                historial.Add($"{intentos}. {numeroadivinado}: Correcto");
                Console.WriteLine($"Número de intentos: {intentos}");

                Console.WriteLine("\nHistorial de intentos:");
                foreach (string h in historial)
                {
                    Console.WriteLine(h);
                }
            }

        } while (numeroadivinado != numeroSecreto);
    }
}
