using System;
/*  Crea un programa que use una variable global para almacenar
 *  el número de intentos de adivinar un número secreto. 
 *  Cada intento se registra y se muestra. 
 */

class Program
{
    //Creamos la variable global
    public static int intentos = 0;

    static void Main()
    {
        //La variable numeroSecreto se genera aleatoriamente entre 1 y 10
        Random randint = new Random();
        int numeroSecreto = randint.Next(1, 11);
        int numeroadivinado;

        Console.WriteLine("Adivina el número secreto entre 1 y 10.");
        //Creamos un bucle para validaciones de entrada y para repetir el juego hasta que se acierte
        do
        {
            Console.Write("Introduce un nunmero: ");
            string entrada = Console.ReadLine() ?? "";

            //validacion basica
            if (!int.TryParse(entrada, out numeroadivinado))
            {
                //Incrementamos el contador de intentos cuando la entrada no es valida
                intentos++;

                Console.WriteLine("Por favor, introduce un número válido.");

                continue;
            }
            //Incrementamos el contador de intentos cuando se acierta o se falla
            intentos++; 

            if (numeroadivinado != numeroSecreto)
            {
                Console.WriteLine("Numero incorrecto. Intenta de nuevo.");
            }
            else
            {
                Console.WriteLine($"Acertaste! Numero de intentos: {intentos}");

            }
        }
        //El bucle se repite hasta que se acierte el numero
        while (numeroadivinado != numeroSecreto);


    }
}
