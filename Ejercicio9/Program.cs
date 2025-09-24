/*	
    9.	Perímetro de un círculo con variables locales
    Escribe un método que reciba el radio como parámetro,
    calcule el perímetro y lo retorne usando únicamente variables locales.
*/
using System;

class Program
{
    // Método para calcular el perímetro del círculo
    public static double CalcularPerimetro(double radio)
    {
        double perimetro = 2 * Math.PI * radio;
        return perimetro;
    }
    // Método principal donde se solicita el radio al usuario
    static void Main()
    {
        double radio = 0;
        bool entradaValida = false;
        // Bucle hasta que se ingrese un valor válido
        while (!entradaValida)
        {
            Console.Write("Introduce el radio del círculo (valor positivo): ");
            string entrada = Console.ReadLine();
            // Validar que la entrada sea un número positivo
            if (double.TryParse(entrada, out radio) && radio > 0)
            {
                entradaValida = true;
                double resultado = CalcularPerimetro(radio);
                Console.WriteLine("El perímetro del círculo es: " + resultado);
            }
            else
            {
                Console.WriteLine("Entrada inválida. Debes ingresar un número positivo.");
            }
        }

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
