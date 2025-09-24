/*
12. Simulación de Cajero Automático
	Usa una variable global que represente el saldo de una cuenta bancaria.
	Implementa métodos con variables locales para:
1.	Depositar dinero.
2.	Retirar dinero (validando que no exceda el saldo).
3.	Consultar saldo.
*/
using System;

namespace Ejercicio12
{
    class Program
    {
        // Variable global: saldo de la cuenta
        static decimal saldo = 0;

        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Simulación de Cajero Automático ===\n");
                Console.WriteLine("1. Depositar dinero");
                Console.WriteLine("2. Retirar dinero");
                Console.WriteLine("3. Consultar saldo");
                Console.WriteLine("4. Salir\n");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine()?.Trim() ?? "";

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Depositar();
                        Pausa();
                        break;
                    case "2":
                        Console.Clear();
                        Retirar();
                        Pausa();
                        break;
                    case "3":
                        Console.Clear();
                        ConsultarSaldo();
                        Pausa();
                        break;
                    case "4":
                        continuar = false;
                        break;
                    default:
                        MensajeError("\nOpción no válida. Intente de nuevo.");
                        Pausa();
                        break;
                }
            }
        }

        // ===== Helpers de UI =====
        static void MensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
        static void MensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
        static void Pausa()
        {
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        // ===== Funcionalidad =====
        static void Depositar()
        {
            Console.WriteLine("=== Depositar Dinero ===\n");
            Console.Write("Ingrese la cantidad a depositar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal monto) && monto > 0)
            {
                saldo += monto;
                MensajeExito($"\nDepósito exitoso. Nuevo saldo: {saldo:C2}");
            }
            else
            {
                MensajeError("\nMonto inválido. Debe ser un número positivo.");
            }
        }

        static void Retirar()
        {
            Console.WriteLine("=== Retirar Dinero ===\n");
            Console.Write("Ingrese la cantidad a retirar: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal monto) && monto > 0)
            {
                if (monto <= saldo)
                {
                    saldo -= monto;
                    MensajeExito($"\nRetiro exitoso. Nuevo saldo: {saldo:C2}");
                }
                else
                {
                    MensajeError("\nFondos insuficientes.");
                }
            }
            else
            {
                MensajeError("\nMonto inválido. Debe ser un número positivo.");
            }
        }

        static void ConsultarSaldo()
        {
            Console.WriteLine("=== Consultar Saldo ===\n");
            Console.WriteLine($"Saldo actual: {saldo:C2}");
        }
    }
}
