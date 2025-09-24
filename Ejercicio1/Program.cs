/*
1.	Contador de accesos global
    -Declara una variable global que almacene el número de veces que se ha ejecutado un método. Cada vez que se llame al método, debe incrementar el contador y mostrarlo en pantalla.
*/
using System;

class Program
{
    // Variable global privada que cuenta las veces que se ejecuta el método
    private static int Contador = 0;

    static void Main()
    {
        string opcion = "";
        Console.Clear();
        Console.WriteLine("Bienvenido al contador de accesos.");
        Console.WriteLine("Escribí 'ejecutar' para correr el método, o 'salir' para terminar.");

        // Bucle principal
        while (true)
        {
            Console.Write("\nIngresá tu opción: ");
            opcion = Console.ReadLine()?.Trim().ToLower();

            try
            {
                if (opcion == "ejecutar")
                {
                    EjecutarCodigo();
                }
                else if (opcion == "salir")
                {
                    Console.WriteLine("Programa finalizado. ¡Hasta luego!");
                    break;
                }
                else
                {
                    throw new ArgumentException("Opción inválida. Solo se acepta 'ejecutar' o 'salir'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error detectado: {ex.Message}");
                Console.WriteLine(" Intentá de nuevo con una opción válida.");
            }
        }
    }

    // Método que incrementa el contador y muestra el número de ejecuciones
    static void EjecutarCodigo()
    {
        int anterior = Contador; // Guarda el valor antes de incrementar
        Contador++;              // Incrementa el contador
        Console.WriteLine($" El contador cambió de {anterior} a {Contador}.");
    }
}