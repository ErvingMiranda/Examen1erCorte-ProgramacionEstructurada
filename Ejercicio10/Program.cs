/*
    10.	Juego de puntuación con variables globales
    Declara una variable global puntuacion. 
    Cada vez que se llame al método GanarPuntos, 
    la puntuación debe aumentar en 10 y mostrarse en pantalla.
 */

using System;

class Program
{
    // Variable global
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

        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine(" ¡Bienvenido al juego de adivinar el número! ");
        Console.WriteLine("================================\n");
        Console.WriteLine(" Reglas:");
        Console.WriteLine(" Debes adivinar un número entre 1 y 10.");
        Console.WriteLine(" Acertar suma +10 puntos, fallar resta -5 puntos.");
        while (true)
        {
            Console.Write("\nIntroduce tu intento: ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out intento) || intento < 1 || intento > 10)
            {
                Console.WriteLine("\nPor favor, introduce un número válido entre 1 y 10.");
                continue;
            }

            if (intento == numeroSecreto)
            {
                Console.WriteLine($"\n¡Felicidades! Has adivinado el número {numeroSecreto}.");
                GanarPuntos();
                break;
            }
            else if (intento < numeroSecreto)
            {
                Console.WriteLine("\nNo es el número correcto. Tu intento es MUY BAJO.");
                PerderPuntos();
            }
            else
            {
                Console.WriteLine("\nNo es el número correcto. Tu intento es MUY ALTO.");
                PerderPuntos();
            }
        }

        Pausa();
    }

    public static void GanarPuntos()
    {
        puntuacion += 10;
        Console.WriteLine("\n========================");
        Console.WriteLine("Puntuación actual: " + puntuacion);
        Console.WriteLine("========================");
    }

    public static void PerderPuntos()
    {
        puntuacion -= 5;
        Console.WriteLine("\n------------------------");
        Console.WriteLine("Puntuación actual: " + puntuacion);
        Console.WriteLine("------------------------");
    }

    public static void MostrarPuntuacion()
    {
        Console.WriteLine("\n========================");
        Console.WriteLine("Puntuación actual: " + puntuacion);
        Console.WriteLine("========================\n");
        Pausa();
    }

    public static void ReiniciarPuntuacion()
    {
        puntuacion = 0;
        Console.WriteLine("\n========================");
        Console.WriteLine("Puntuación reiniciada a 0.");
        Console.WriteLine("========================\n");
        Pausa();
    }

    public static void Salir()
    {
        Console.WriteLine("\n========================");
        Console.WriteLine("Saliendo del programa...");
        Console.WriteLine("========================");
        Environment.Exit(0);
    }

    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== MENÚ DE OPCIONES ======");
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Mostrar puntuación");
            Console.WriteLine("3. Reiniciar puntuación");
            Console.WriteLine("4. Salir");
            Console.WriteLine("==============================");
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
                    Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                    Pausa();
                    break;
            }
        }
    }

    public static void Pausa()
    {
        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey(true);
    }
}
