using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Variable global para el total del carrito
    static double carritoTotal = 0;
    static List<Producto> carrito = new List<Producto>();

    class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Id { get; set; }
    }

    static void AgregarProducto(string nombre, double precio)
    {
        // Variable local para el nuevo producto
        var nuevoProducto = new Producto
        {
            Nombre = nombre,
            Precio = precio,
            Id = carrito.Count + 1
        };

        carrito.Add(nuevoProducto);
        carritoTotal += precio;
        Console.WriteLine($"Producto '{nombre}' agregado. Precio: ${precio}");
    }

    static void EliminarProducto(int id)
    {
        // Variable local para buscar el producto
        var producto = carrito.FirstOrDefault(p => p.Id == id);

        if (producto != null)
        {
            carritoTotal -= producto.Precio;
            carrito.Remove(producto);
            Console.WriteLine($"Producto '{producto.Nombre}' eliminado del carrito");
        }
        else
        {
            Console.WriteLine("Producto no encontrado en el carrito");
        }
    }

    static void ConsultarTotal()
    {
        // Variable local para formatear el total
        string totalFormateado = carritoTotal.ToString("F2");
        Console.WriteLine($"Total actual del carrito: ${totalFormateado}");
    }

    static void MostrarCarrito()
    {
        // Variable local para contar productos
        int cantidadProductos = carrito.Count;

        if (cantidadProductos == 0)
        {
            Console.WriteLine("El carrito esta vacio");
            return;
        }

        Console.WriteLine("Productos en el carrito:");
        foreach (var producto in carrito)
        {
            Console.WriteLine($"- {producto.Nombre}: ${producto.Precio:F2} (ID: {producto.Id})");
        }
    }

    static void Main()
    {
        Console.WriteLine(new string('=', 40));
        Console.WriteLine("      Simulador de tienda en linea");
        Console.WriteLine(new string('=', 40));

        bool ejecutando = true;

        while (ejecutando)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Consultar total");
            Console.WriteLine("4. Ver carrito");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opcion: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Precio del producto: ");
                    if (double.TryParse(Console.ReadLine(), out double precio) && precio > 0)
                    {
                        AgregarProducto(nombre, precio);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Precio invalido");
                        Console.ResetColor();
                    }
                    break;

                case "2":
                    if (carrito.Count == 0)
                    {
                        Console.WriteLine("El carrito esta vacio");
                        break;
                    }
                    MostrarCarrito();
                    Console.Write("ID del producto a eliminar: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        EliminarProducto(id);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ID invalido");
                        Console.ResetColor();
                    }
                    break;

                case "3":
                    ConsultarTotal();
                    break;

                case "4":
                    MostrarCarrito();
                    break;

                case "5":
                    ejecutando = false;
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion no valida");
                    Console.ResetColor();
                    break;
            }
        }
    }
}