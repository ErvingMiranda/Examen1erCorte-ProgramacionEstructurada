/* 7.	Promedio de notas con variables locales
    Haz un método que calcule el promedio de tres notas 
    introducidas por el usuario usando solo variables locales.
 */
using System;
class Program
{

    static void Main()
    {
        Console.WriteLine("Programa que calcula el promedio de tres notas. ");
        Promedio();
    }
    // Calcula el promedio de tres notas en el metodo promedio.
    static void Promedio()
    {
        double total = suma();
        double promedio = total / 3;
        Console.WriteLine($"El promedio es: {promedio}");
    }
    // Suma las tres notas introducidas por el usuario, para luego calcular el promedio.
    static double suma()
    {
        double suma = 0;
        int i = 1;
        while (i <= 3)
        {
            // Manejo de excepciones para evitar errores de formato.
            try
            {
                Console.Write($"Ingrese la nota {i}: ");
                double nota = Convert.ToDouble(Console.ReadLine());
                if (nota < 0 || nota > 10)
                {
                    Console.WriteLine("Nota invalida, ingrese una nota entre 0 y 10.");
                    continue;
                }
                suma += nota;
                // Incrementa el contador solo si la entrada es valida.
                i++;
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada invalida, por favor ingrese un numero.");
            }
        }
        // Retorna la suma de las tres notas introducidas.  
        return suma;
    }
}
