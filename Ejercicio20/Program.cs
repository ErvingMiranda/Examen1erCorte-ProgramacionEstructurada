/*20.Número capicúa(palíndromo numérico)

Crea un programa que:
•	Pida al usuario un número entero positivo.
•	Determine si ese número es capicúa (por ejemplo, 121, 1331).
•	Usa una función para invertir el número (no con arreglos).
•	Compara el número original con el invertido.
•	Usa una variable global para el número original y funciones auxiliares para la inversión.
Requisitos técnicos:
•	Función con retorno.
•	Sin arreglos ni manipulación de cadenas (usa operadores matemáticos).
•	Uso de variables globales/locales.*/

using System;

class Program
{
    // Variable global para el número original
    static int numeroOriginal;

    static void Main()
    {
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("      Detector de números capicúas");
        Console.WriteLine(new string('=', 50));

        PedirNumero();
        ProcesarNumero();

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    // Función para pedir el número al usuario
    static void PedirNumero()
    {
        while (true)
        {
            Console.Write("\nIngrese un número entero positivo: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out numeroOriginal) && numeroOriginal >= 0)
            {
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Debe ingresar un número entero positivo.");
            Console.ResetColor();
        }
    }

    // Función principal para procesar el número
    static void ProcesarNumero()
    {
        Console.WriteLine("\n" + new string('-', 40));
        Console.WriteLine("Procesando");
        Console.WriteLine(new string('-', 40));

        Console.WriteLine($"Número original: {numeroOriginal}");

        // Usar función para invertir el número
        int numeroInvertido = InvertirNumero(numeroOriginal);
        Console.WriteLine($"Número invertido: {numeroInvertido}");

        // Determinar si es capicúa
        bool esCapicua = EsCapicua(numeroOriginal, numeroInvertido);

        MostrarResultado(esCapicua, numeroInvertido);

        // Mostrar proceso detallado si el número es pequeño
        if (numeroOriginal < 1000)
        {
            MostrarProcesoDetallado();
        }
    }

    // Función para invertir el número usando operaciones matemáticas
    static int InvertirNumero(int numero)
    {
        // Variables locales para el proceso de inversión
        int numeroInvertido = 0;
        int numeroTemporal = numero;

        while (numeroTemporal > 0)
        {
            int digito = numeroTemporal % 10;  // Obtener último dígito
            numeroInvertido = numeroInvertido * 10 + digito;  // Agregar dígito al número invertido
            numeroTemporal /= 10;  // Eliminar último dígito
        }

        return numeroInvertido;
    }

    // Función para determinar si es capicúa
    static bool EsCapicua(int original, int invertido)
    {
        // Variable local para el resultado
        bool resultado = original == invertido;
        return resultado;
    }

    // Función para mostrar el resultado
    static void MostrarResultado(bool esCapicua, int numeroInvertido)
    {
        Console.WriteLine("\n" + new string('=', 30));

        if (esCapicua)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Es un número capicúa.");
            Console.WriteLine($"{numeroOriginal} se lee igual al derecho y al revés.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No es un número capicúa.");
            Console.WriteLine($"{numeroOriginal} =/ {numeroInvertido}");
        }

        Console.ResetColor();
        Console.WriteLine(new string('=', 30));
    }

    // Función para mostrar el proceso detallado de inversión
    static void MostrarProcesoDetallado()
    {
        Console.WriteLine("\n" + new string('-', 30));
        Console.WriteLine("Proceso detallado.");
        Console.WriteLine(new string('-', 30));

        int numeroTemporal = numeroOriginal;
        int numeroInvertido = 0;
        int paso = 1;

        Console.WriteLine($"Paso 0: Número original = {numeroTemporal}");

        while (numeroTemporal > 0)
        {
            int digito = numeroTemporal % 10;
            int numeroAnterior = numeroInvertido;
            numeroInvertido = numeroInvertido * 10 + digito;
            numeroTemporal /= 10;

            Console.WriteLine($"Paso {paso}: {numeroAnterior} × 10 + {digito} = {numeroInvertido}");
            Console.WriteLine($"        Número restante: {numeroTemporal}");
            paso++;
        }
    }
    
}