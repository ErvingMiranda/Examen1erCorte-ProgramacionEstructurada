using System;
using System.Linq;
/* 18.	Validador de contraseñas seguras
Diseña un programa que valide si una contraseña ingresada cumple los siguientes requisitos:
•	Mínimo 8 caracteres
•	Al menos una mayúscula
•	Al menos una minúscula
•	Al menos un número
•	Al menos un carácter especial (!@#$%^&*) 
Requisitos:
•	Crea una función EsContraseñaValida(string pass) que devuelva true o false.
•	Crea procedimientos adicionales que verifiquen cada criterio individualmente.
•	Usa modularidad adecuada y variables locales/globales donde se justifique.*/
class program
{
    static void Main()
    {
        Console.WriteLine(new string('=', 30));
        Console.WriteLine("Validador de contraseñas");
        Console.WriteLine(new string('=', 30));

        while (true)
        {
            Console.Write("\nIngrese su contraseña, esta debe tener:\nMas de 8 caracteres\nUna miniuscula y Mayúscula.\nUn número.\nUn carácter especial: ");
            string password = Console.ReadLine();

            if (ValidarPassword(password))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✓ Contraseña segura");
                break;
            }
        }
    }

    static bool ValidarPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            MostrarError("La contraseña no puede estar vacía");
            return false;
        }

        string[] errores = //Usamos un array para almacenar los errores
        {    
            password.Length < 8 ? "Mínimo 8 caracteres" : null,
            !password.Any(char.IsUpper) ? "Al menos una mayúscula" : null,
            !password.Any(char.IsLower) ? "Al menos una minúscula" : null,
            !password.Any(char.IsDigit) ? "Al menos un número" : null,
            !password.Any(c => "!@#$%^&*".Contains(c)) ? "Al menos un carácter especial (!@#$%^&*)" : null
        };

        string[] erroresFiltrados = errores.Where(e => e != null).ToArray();

        if (erroresFiltrados.Length > 0)
        {
            MostrarError("Errores: " + string.Join(", ", erroresFiltrados));
            return false;
        }

        return true;
    }

    static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" {mensaje}");
        Console.ResetColor();
    }
}