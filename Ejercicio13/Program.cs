/*
13.	Juego de Adivinanza Mejorado
•	Usa una variable global para almacenar el número secreto.
•	Un método con variables locales debe pedir al usuario que adivine.
•	Otro método debe aumentar un contador global de intentos y mostrar un mensaje de acierto o error.
*/
using System;

namespace Ejercicio13
{
    class Program
    {
        // Variables globales
        static int numeroSecreto;
        static int intentos = 0;
        static int intentosMaximos = 10;

        static void Main(string[] args)
        {
            Random rnd = new Random();
            numeroSecreto = rnd.Next(1, 101);

            Console.Clear();
            Console.WriteLine("=== Juego de Adivinanza Mejorado ===\n");
            Console.WriteLine("He pensado en un número entre 1 y 100.");
            Console.WriteLine($"Tienes {intentosMaximos} intentos para adivinar.");

            bool adivinado = false;

            while (!adivinado && intentos < intentosMaximos)
            {
                adivinado = PedirAdivinanza();
            }

            if (!adivinado)
            {
                MensajeError($"\nSe acabaron los intentos. El número era {numeroSecreto}.");
            }

            Console.WriteLine("\n¡Juego terminado!");
        }

        // Método para pedir un número
        static bool PedirAdivinanza()
        {
            Console.Write("\nIngrese su número: ");
            if (int.TryParse(Console.ReadLine(), out int intento))
            {
                return VerificarAdivinanza(intento);
            }
            else
            {
                MensajeError("Entrada inválida. Debe ingresar un número entero.");
                return false;
            }
        }

        // Método que incrementa el contador y evalúa el intento
        static bool VerificarAdivinanza(int intento)
        {
            intentos++;

            if (intento == numeroSecreto)
            {
                MensajeExito($"\n¡Correcto! Adivinaste en {intentos} intentos.");
                return true;
            }
            else if (intento < numeroSecreto)
            {
                MensajeError($"\nDemasiado bajo. Te quedan {intentosMaximos - intentos} intentos.");
            }
            else
            {
                MensajeError($"\nDemasiado alto. Te quedan {intentosMaximos - intentos} intentos.");
            }

            return false;
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
    }
}
