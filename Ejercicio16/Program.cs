using System;
using System.Collections.Generic;
using System.Linq;

/* 16.	Sistema de Registro de Usuarios
•	Crea una lista global que almacene nombres de usuarios registrados.
•	Métodos con variables locales deben permitir:
i.	Registrar un nuevo usuario.
ii.	Validar si un usuario ya existe.
iii.	Mostrar todos los usuarios. */
class Program
{
    // Lista global para almacenar nombres de usuarios registrados
    static List<string> usuariosRegistrados = new List<string>();

    static void Main()
    {
        Console.WriteLine(new string('=', 40));
        Console.WriteLine("    Sistema de Registro de Usuarios");
        Console.WriteLine(new string('=', 40));

        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarUsuario();
                    break;
                case "2":
                    ValidarUsuario();
                    break;
                case "3":
                    MostrarUsuarios();
                    break;
                case "4":
                    continuar = false;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nSaliendo...");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\nMenú Principal:");
        Console.WriteLine("1. Registrar nuevo usuario");
        Console.WriteLine("2. Validar si un usuario existe");
        Console.WriteLine("3. Mostrar todos los usuarios");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción (1-4): ");
    }

    // Método para registrar un nuevo usuario con validaciones
    static void RegistrarUsuario()
    {
        Console.WriteLine("\n" + new string('-', 30));
        Console.WriteLine("Registro de nuevo usuario.");
        Console.WriteLine(new string('-', 30));

        string nombreUsuario = ValidarNombreUsuario();

        if (nombreUsuario != null)
        {
            // Variable local para el proceso de registro
            bool usuarioRegistrado = RegistrarUsuarioEnSistema(nombreUsuario);

            if (usuarioRegistrado)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Usuario '{nombreUsuario}' registrado exitosamente.");
                Console.ResetColor();
            }
        }
    }

    // Método con variable local para registrar usuario en el sistema
    static bool RegistrarUsuarioEnSistema(string nombreUsuario)
    {
        // Variable local para verificar duplicados
        bool existeUsuario = usuariosRegistrados.Contains(nombreUsuario);

        if (!existeUsuario)
        {
            usuariosRegistrados.Add(nombreUsuario); //si no existe, lo añade
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"El usuario '{nombreUsuario}' ya existe en el sistema.");
            Console.ResetColor();
            return false;
        }
    }

    // Método para validar si un usuario ya existe
    static void ValidarUsuario()
    {
        Console.WriteLine("\n" + new string('-', 30));
        Console.WriteLine("Validar usuario");
        Console.WriteLine(new string('-', 30));

        string nombreUsuario = ValidarNombreUsuario();

        if (nombreUsuario != null)
        {
            // Variable local para el resultado de la validación
            bool usuarioExiste = ValidarExistenciaUsuario(nombreUsuario);

            if (usuarioExiste)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"El usuario '{nombreUsuario}' si existe en el sistema.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"El usuario '{nombreUsuario}' no existe en el sistema.");
                Console.ResetColor();
            }
        }
    }

    // Método con variable local para validar existencia
    static bool ValidarExistenciaUsuario(string nombreUsuario)
    {
        // Variable local para el resultado
        bool existe = usuariosRegistrados.Any(u => u.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        return existe;
    }

    // Método para mostrar todos los usuarios
    static void MostrarUsuarios()
    {
        Console.WriteLine("\n" + new string('-', 30));
        Console.WriteLine("Lista de usuarios");
        Console.WriteLine(new string('-', 30));

        // Variable local para contar usuarios
        int totalUsuarios = MostrarListaUsuarios();

        if (totalUsuarios == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No hay usuarios registrados en el sistema.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total de usuarios registrados: {totalUsuarios}");
            Console.ResetColor();
        }
    }

    // Método con variable local para mostrar la lista
    static int MostrarListaUsuarios()
    {
        // Variable local para el conteo
        int contador = 0;

        if (usuariosRegistrados.Count == 0)
        {
            return 0;
        }

        // Ordenar la lista alfabéticamente
        var usuariosOrdenados = usuariosRegistrados.OrderBy(u => u).ToList();

        foreach (var usuario in usuariosOrdenados)
        {
            contador++;
            Console.WriteLine($"{contador}. {usuario}");
        }

        return contador;
    }

    // Método para validar el nombre de usuario con todas las reglas
    static string ValidarNombreUsuario()
    {
        while (true)
        {
            Console.Write("Ingrese el nombre de usuario: ");
            string entrada = Console.ReadLine()?.Trim();

            // Validar que no esté vacío
            if (string.IsNullOrWhiteSpace(entrada))
            {
                MostrarError("El nombre de usuario no puede estar vacío.");
                continue;
            }

            // Validar longitud mínima
            if (entrada.Length < 3)
            {
                MostrarError("El nombre de usuario debe tener al menos 3 caracteres.");
                continue;
            }

            // Validar longitud máxima
            if (entrada.Length > 20)
            {
                MostrarError("El nombre de usuario no puede tener más de 20 caracteres.");
                continue;
            }

            // Validar caracteres permitidos (solo letras, números y guiones bajos)
            if (!EsNombreUsuarioValido(entrada))
            {
                MostrarError("Solo se permiten letras, números y guiones bajos (_).");
                continue;
            }

            // Validar que no empiece con número
            if (char.IsDigit(entrada[0]))
            {
                MostrarError("El nombre de usuario no puede empezar con un número.");
                continue;
            }

            // Validar que no tenga espacios
            if (entrada.Contains(" "))
            {
                MostrarError("El nombre de usuario no puede contener espacios.");
                continue;
            }

            return entrada;
        }
    }

    //validar caracteres del nombre de usuario
    static bool EsNombreUsuarioValido(string usuario)
    {
        foreach (char c in usuario)
        {
            if (!char.IsLetterOrDigit(c) && c != '_')
            {
                return false;
            }
        }
        return true;
    }

    //mostrar errores de validación
    static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {mensaje}");
        Console.ResetColor();
    }
}