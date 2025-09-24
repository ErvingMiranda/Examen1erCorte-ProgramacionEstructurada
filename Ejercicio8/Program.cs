/*
8.	Control de sesión con variable global
    Declara una variable global booleana sesionIniciada. 
    Simula un inicio de sesión que la cambie a true cuando 
    el usuario ingrese la contraseña correcta.
*/
using System;

class Program
{
    // Variable global
    static bool sesionIniciada = false;

    static void Main(string[] args)
    {
        string contraseñaCorrecta = "contraseña123";
        int intentos = 0;
        const int maxIntentos = 3;

        while (true)
        {
            Console.Clear();
            Console.Write("Ingrese la contraseña para iniciar sesión: ");
            string entrada = Console.ReadLine();

            bool vacia = string.IsNullOrWhiteSpace(entrada);
            bool correcta = !vacia && entrada == contraseñaCorrecta;

            if (correcta)
            {
                sesionIniciada = true;
                Console.WriteLine("\nSesión iniciada correctamente.");
                break; // no se limpia cuando es correcta
            }

            intentos++;

            if (vacia)
                Console.WriteLine("\nLa contraseña no puede estar vacía. Intente de nuevo.");
            else
                Console.WriteLine("\nContraseña incorrecta. Intente de nuevo.");

            Console.WriteLine($"Intentos usados: {intentos} de {maxIntentos}");
            Pausa();

            if (intentos >= maxIntentos)
                break;
        }

        Console.WriteLine("\n================================");
        if (sesionIniciada)
        {
            Console.WriteLine("Inicio de sesión exitoso.");
        }
        else
        {
            Console.WriteLine("No se pudo iniciar sesión. Has excedido el número máximo de intentos.");
        }
        Console.WriteLine("Estado final de la sesión: " + (sesionIniciada ? "Iniciada" : "No iniciada"));
        Console.WriteLine("================================");

        Pausa();
    }

    static void Pausa()
    {
        Console.Write("\nPresione cualquier tecla para continuar...");
        Console.ReadKey(true);
    }
}
