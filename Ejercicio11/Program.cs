/*
11. Sistema de Inventario simplificado
•	Declara una variable global que almacene el total de productos en inventario.
•	Crea métodos locales para:
        -Agregar productos.
        -Retirar productos.
        -Consultar el inventario actual.
•	Cada acción debe actualizar la variable global y mostrar los resultados.
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Ejercicio11
{
    class Program
    {
        // ----- Modelo -----
        class Producto
        {
            public string NombreMostrar { get; set; } = "";
            public int Cantidad { get; set; }
        }

        // Diccionario: clave base normalizada -> lista de variantes
        // Ej.: "agua mineral" -> [ { "Agua Mineral", 10 }, { "Água Mineral", 2 } ]
        static Dictionary<string, List<Producto>> inventario = new Dictionary<string, List<Producto>>();

        // ----- Main -----
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Inventario con Diccionario ===\n");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Retirar producto");
                Console.WriteLine("3. Consultar inventario");
                Console.WriteLine("4. Salir\n");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine()?.Trim() ?? "";

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        AgregarProducto();
                        Pausa();
                        break;
                    case "2":
                        Console.Clear();
                        RetirarProducto();
                        Pausa();
                        break;
                    case "3":
                        Console.Clear();
                        ConsultarInventario();
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

        // ----- Para mejor presentación -----
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
        static int LeerEnteroPositivo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int n) && n > 0) return n;
                MensajeError("Entrada inválida. Ingrese un entero positivo.\n");
            }
        }

        // ----- Normalización: sin tildes, preservando ñ -----
        static string NormalizarClave(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;

            string t = texto.Trim().ToLowerInvariant();
            string d = t.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(d.Length);

            for (int i = 0; i < d.Length; i++)
            {
                char c = d[i];
                var cat = CharUnicodeInfo.GetUnicodeCategory(c);

                // 'n' + tilde combinante -> 'ñ'
                if ((c == 'n') &&
                    i + 1 < d.Length &&
                    CharUnicodeInfo.GetUnicodeCategory(d[i + 1]) == UnicodeCategory.NonSpacingMark &&
                    d[i + 1] == '\u0303')
                {
                    sb.Append('ñ');
                    i++; // saltar la tilde
                    continue;
                }

                // Omitir diacríticos (tildes, marcas combinantes)
                if (cat == UnicodeCategory.NonSpacingMark ||
                    cat == UnicodeCategory.SpacingCombiningMark ||
                    cat == UnicodeCategory.EnclosingMark)
                    continue;

                sb.Append(c);
            }

            string s = sb.ToString().Normalize(NormalizationForm.FormC);
            return Regex.Replace(s, @"\s+", " ");
        }

        // ----- Formato de nombre para mostrar -----
        static string ATitleCaseEspanol(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";
            var es = new CultureInfo("es-ES");
            string lower = texto.Trim().ToLower(es);
            return es.TextInfo.ToTitleCase(lower);
        }

        // ----- Lógica principal -----
        static void AgregarProducto()
        {
            Console.WriteLine("=== Agregar Producto ===\n");

            Console.Write("Ingrese el nombre del producto: ");
            string nombreEntrada = Console.ReadLine() ?? "";
            string claveBase = NormalizarClave(nombreEntrada);
            if (string.IsNullOrWhiteSpace(claveBase))
            {
                MensajeError("\nEl nombre del producto no puede estar vacío.");
                return;
            }

            int cantidad = LeerEnteroPositivo("Ingrese la cantidad a agregar: ");

            string candidatoFmt = ATitleCaseEspanol(nombreEntrada);

            if (!inventario.ContainsKey(claveBase))
            {
                // No existe la clave base: crear lista y primer producto
                inventario[claveBase] = new List<Producto>
                {
                    new Producto { NombreMostrar = candidatoFmt, Cantidad = cantidad }
                };
                MensajeExito($"\nSe agregaron {cantidad} unidades de '{candidatoFmt}'.");
                return;
            }

            // Ya existe al menos una variante bajo la misma clave base
            var variantes = inventario[claveBase];

            if (variantes.Count == 1)
            {
                var prod = variantes[0];

                // Si el nombre formateado coincide, solo sumar
                if (string.Equals(prod.NombreMostrar, candidatoFmt, StringComparison.CurrentCulture))
                {
                    prod.Cantidad += cantidad;
                    MensajeExito($"\nSe agregaron {cantidad} unidades de '{prod.NombreMostrar}'.");
                    return;
                }

                // Nombres diferentes: preguntar qué hacer
                Console.WriteLine($"\nYa existe el producto: '{prod.NombreMostrar}'.");
                Console.WriteLine($"Ingresaste: '{candidatoFmt}'. ¿Qué desea hacer?");
                Console.WriteLine("  1) Sobrescribir el nombre existente por el nuevo.");
                Console.WriteLine("  2) Guardar como producto aparte (nueva variante).");
                Console.WriteLine("  3) Mantener el nombre original y solo sumar cantidad.\n");

                int eleccion = LeerOpcion(1, 3, "Seleccione 1, 2 o 3: ");

                if (eleccion == 1)
                {
                    prod.NombreMostrar = candidatoFmt;
                    prod.Cantidad += cantidad;
                    MensajeExito($"\nNombre actualizado y cantidad sumada. Ahora '{prod.NombreMostrar}' tiene {prod.Cantidad}.");
                }
                else if (eleccion == 2)
                {
                    variantes.Add(new Producto { NombreMostrar = candidatoFmt, Cantidad = cantidad });
                    MensajeExito($"\nSe creó una variante y se agregaron {cantidad} unidades de '{candidatoFmt}'.");
                }
                else // 3
                {
                    prod.Cantidad += cantidad;
                    MensajeExito($"\nSe agregaron {cantidad} unidades a '{prod.NombreMostrar}'.");
                }

                return;
            }
            else
            {
                // Hay múltiples variantes: permitir elegir una o crear nueva
                Console.WriteLine($"\nSe encontraron {variantes.Count} productos con ese nombre base:\n");
                for (int i = 0; i < variantes.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}) {variantes[i].NombreMostrar} (stock: {variantes[i].Cantidad})");
                }
                Console.WriteLine($"  {variantes.Count + 1}) Crear NUEVA variante con el nombre '{candidatoFmt}'\n");

                int eleccion = LeerOpcion(1, variantes.Count + 1, $"Seleccione 1..{variantes.Count + 1}: ");

                if (eleccion == variantes.Count + 1)
                {
                    variantes.Add(new Producto { NombreMostrar = candidatoFmt, Cantidad = cantidad });
                    MensajeExito($"\nSe creó una variante y se agregaron {cantidad} unidades de '{candidatoFmt}'.");
                }
                else
                {
                    var prodSel = variantes[eleccion - 1];
                    prodSel.Cantidad += cantidad;
                    MensajeExito($"\nSe agregaron {cantidad} unidades a '{prodSel.NombreMostrar}'.");
                }

                return;
            }
        }

        static void RetirarProducto()
        {
            Console.WriteLine("=== Retirar Producto ===\n");

            Console.Write("Ingrese el nombre del producto: ");
            string nombreEntrada = Console.ReadLine() ?? "";
            string claveBase = NormalizarClave(nombreEntrada);

            if (!inventario.TryGetValue(claveBase, out var variantes) || variantes.Count == 0)
            {
                MensajeError("\nEl producto no existe en el inventario.");
                return;
            }

            Producto objetivo;

            if (variantes.Count == 1)
            {
                objetivo = variantes[0];
            }
            else
            {
                Console.WriteLine($"\nHay varias opciones para ese nombre base:\n");
                for (int i = 0; i < variantes.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}) {variantes[i].NombreMostrar} (stock: {variantes[i].Cantidad})");
                }
                Console.WriteLine();
                int idx = LeerOpcion(1, variantes.Count, $"Seleccione 1..{variantes.Count}: ");
                objetivo = variantes[idx - 1];
            }

            int cantidad = LeerEnteroPositivo($"Ingrese la cantidad a retirar de '{objetivo.NombreMostrar}': ");

            if (cantidad > objetivo.Cantidad)
            {
                MensajeError("\nNo hay suficientes unidades para retirar esa cantidad.");
                return;
            }

            objetivo.Cantidad -= cantidad;

            if (objetivo.Cantidad == 0)
            {
                variantes.Remove(objetivo);
                MensajeExito($"\nSe retiraron {cantidad} unidades. '{objetivo.NombreMostrar}' quedó en 0 y se eliminó del inventario.");
                if (variantes.Count == 0) inventario.Remove(claveBase);
            }
            else
            {
                MensajeExito($"\nSe retiraron {cantidad} unidades de '{objetivo.NombreMostrar}'. Restan {objetivo.Cantidad}.");
            }
        }

        static void ConsultarInventario()
        {
            Console.WriteLine("=== Consultar Inventario ===\n");

            if (inventario.Count == 0)
            {
                MensajeError("El inventario está vacío.");
                return;
            }

            foreach (var kvp in inventario)
            {
                var variantes = kvp.Value;
                foreach (var p in variantes)
                {
                    Console.WriteLine($"- {p.NombreMostrar}: {p.Cantidad} unidades");
                }
            }
        }

        // ----- Lectura segura de opciones -----
        static int LeerOpcion(int min, int max, string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int n) && n >= min && n <= max) return n;
                MensajeError("Opción inválida.\n");
            }
        }
    }
}
