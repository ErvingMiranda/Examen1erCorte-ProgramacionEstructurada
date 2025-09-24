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
        // Contraseña correcta predefinida
        string contraseñaCorrecta = "contraseña123"; // Contraseña correcta
        //contador de intentos e intentos maximos permitidos.
        int intentos = 0;
        int maxIntentos = 3;

        // Ciclo hasta que la contraseña sea correcta o se excedan los intentos
        while (!sesionIniciada && intentos < maxIntentos)
        {
            Console.WriteLine("Ingrese la contraseña para iniciar sesión:");
            string contraseñaIngresada = Console.ReadLine();
            // Validar entrada vacía, nula o espacios y cuenta como intento fallido
            if (string.IsNullOrWhiteSpace(contraseñaIngresada))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                intentos++;
                continue;
            }
            if (contraseñaIngresada == contraseñaCorrecta)
            {
                sesionIniciada = true;
                Console.WriteLine("Sesión iniciada correctamente.");
                break;
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta. Intente de nuevo.");
                intentos++;
            }
        }

        // Si se excedieron los intentos, mostrar mensaje y cerrar el programa
        if (!sesionIniciada && intentos >= maxIntentos)
        {
            Console.WriteLine("Has excedido el número máximo de intentos. El programa se cerrará.");
            Environment.Exit(0);
        }

        //Mensajes de salida dependiendo del estado de la variable sesionIniciada
        if (sesionIniciada)
        {
            Console.WriteLine("¡La variable 'sesionIniciada' está en True!");
        }
        else
        {
            Console.WriteLine("No se pudo iniciar sesión. La variable 'sesionIniciada' está en False.");
        }

        // Mostrar el estado de la sesión
        Console.WriteLine("Estado de la sesión: " + (sesionIniciada ? "Iniciada" : "No iniciada"));
        
    }
}
