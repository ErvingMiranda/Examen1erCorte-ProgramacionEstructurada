/*
    10.	Juego de puntuación con variables globales
    Declara una variable global puntuacion. 
    Cada vez que se llame al método GanarPuntos, 
    la puntuación debe aumentar en 10 y mostrarse en pantalla.
 */

using System;
class Program
{
    //Hacemos la variable global
    static int puntuacion = 0;
    static void Main()
    {
        Menu();
    }

    public static void Juego()
    {
        Random rnd = new Random();
        int numeroSecreto = rnd.Next(1, 11); // Número entre 1 y 10
        int intento = 0;

        Console.WriteLine("¡Bienvenido al juego de adivinar el número!");
        Console.WriteLine("Debes adivinar un número entre 1 y 10.");

        while (true)
        {
            Console.Write("Introduce tu intento: ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out intento) || intento < 1 || intento > 10)
            {
                Console.WriteLine("Por favor, introduce un número válido entre 1 y 10.");
                continue;
            }

            if (intento == numeroSecreto)
            {
                Console.WriteLine("¡Felicidades! Has adivinado el número.");
                GanarPuntos();
                break;
            }
            else
            {
                Console.WriteLine("No es el número correcto. Intenta de nuevo.");
                PerderPuntos();
            }
        }
    }

    public static void GanarPuntos()
    {
        puntuacion += 10;
        {
            Console.WriteLine("Puntuación actual: " + puntuacion);
        }
    }
    public static void PerderPuntos()
    {
        puntuacion -= 5;
        // Ahora permitimos puntuaciones negativas, así que eliminamos la restricción
        Console.WriteLine("========================");
        Console.WriteLine("Puntuación actual: " + puntuacion);
        Console.WriteLine("========================");
    }

    public static void MostrarPuntuacion()
    {
        Console.WriteLine("========================");
        Console.WriteLine("Puntuación actual: " + puntuacion);
        Console.WriteLine("========================");
    }

    public static void ReiniciarPuntuacion()
    {
        puntuacion = 0;
        Console.WriteLine("========================");
        Console.WriteLine("Puntuación reiniciada a 0.");
        Console.WriteLine("========================");
    }

    public static void Salir()
    {
        Console.WriteLine("========================");
        Console.WriteLine("Saliendo del programa...");
        Console.WriteLine("========================");
        Environment.Exit(0);
    }

    public static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\nMenú de opciones:");
            Console.WriteLine("1. jugar");
            Console.WriteLine("2. Mostrar puntuación");
            Console.WriteLine("3. Reiniciar puntuación");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opción (1-4): ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Juego();
                    break;

                case "2":
                    MostrarPuntuacion();
                    break;
                case "3":
                    ReiniciarPuntuacion();
                    break;
                case "4":
                    Salir();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }


}
