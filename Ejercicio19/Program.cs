/* 19.	Validación de fecha (día, mes, año)
Desarrolla un programa que:
Pida al usuario ingresar una fecha (día, mes, año).
Valide si la fecha es válida (mes entre 1-12, días válidos según el mes, etc.).
•	Determine si el año es bisiesto.
•	Use funciones para cada validación (por ejemplo, EsBisiesto, DiaValido, MesValido).
•	Muestra si la fecha ingresada es correcta o no.
Requisitos técnicos:
	Funciones para validaciones lógicas.
	Uso de variables locales y globales. */

using System;

class Program
{
    // Variables globales para almacenar la fecha
    static int diaGlobal, mesGlobal, añoGlobal;
    static bool fechaValida = false;

    static void Main()
    {
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("          Validación fecha");
        Console.WriteLine(new string('=', 50));

        PedirFecha();
        ValidarFechaCompleta();
        MostrarResultados();

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    // Función para pedir la fecha al usuario
    static void PedirFecha()
    {
        Console.WriteLine("\nPor favor ingrese una fecha:");

        añoGlobal = PedirAño();
        mesGlobal = PedirMes();
        diaGlobal = PedirDia();
    }

    // Función para validar toda la fecha
    static void ValidarFechaCompleta()
    {
        bool mesValido = MesValido(mesGlobal);
        bool añoValido = AñoValido(añoGlobal);
        bool diaValido = DiaValido(diaGlobal, mesGlobal, añoGlobal);

        fechaValida = mesValido && añoValido && diaValido;
    }

    // Función para mostrar los resultados
    static void MostrarResultados()
    {
        Console.WriteLine("\n" + new string('-', 40));
        Console.WriteLine("Resultados validación");
        Console.WriteLine(new string('-', 40));

        Console.WriteLine($"Fecha ingresada: {diaGlobal:00}/{mesGlobal:00}/{añoGlobal}");

        if (fechaValida)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fecha válida");
            Console.ResetColor();

            // Mostrar información adicional
            MostrarInformacionAdicional();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fecha inválida");
            Console.ResetColor();

            // Mostrar qué específicamente está mal
            MostrarErroresDetallados();
        }
    }

    // Función para mostrar información adicional de la fecha válida
    static void MostrarInformacionAdicional()
    {
        bool esBisiesto = EsBisiesto(añoGlobal);
        string nombreMes = ObtenerNombreMes(mesGlobal);
        int diasEnMes = ObtenerDiasEnMes(mesGlobal, añoGlobal);

        Console.WriteLine($"\nInformación de la fecha:");
        Console.WriteLine($"- Mes: {nombreMes}");
        Console.WriteLine($"- Días en el mes: {diasEnMes}");
        Console.WriteLine($"- Año bisiesto: {(esBisiesto ? "Sí" : "No")}");
        
    }

    // Función para mostrar errores detallados
    static void MostrarErroresDetallados()
    {
        if (!MesValido(mesGlobal))
        {
            Console.WriteLine("- El mes debe estar entre 1 y 12");
        }

        if (!AñoValido(añoGlobal))
        {
            Console.WriteLine("- El año debe ser un número positivo");
        }

        if (MesValido(mesGlobal) && AñoValido(añoGlobal) && !DiaValido(diaGlobal, mesGlobal, añoGlobal))
        {
            int diasEnMes = ObtenerDiasEnMes(mesGlobal, añoGlobal);
            Console.WriteLine($"- El día debe estar entre 1 y {diasEnMes} para el mes {mesGlobal}");
        }
    }

    // FUNCIONES DE VALIDACIÓN PRINCIPALES

    // Función para validar si el año es bisiesto
    static bool EsBisiesto(int año)
    {
        // Variable local para el cálculo
        bool esBisiesto = (año % 4 == 0 && año % 100 != 0) || (año % 400 == 0); // Año divisible por 4 y no por 100, o divisible por 400
        return esBisiesto;
    }

    // Función para validar si el día es válido
    static bool DiaValido(int dia, int mes, int año)
    {
        // Variable local para el número máximo de días
        int diasEnMes = ObtenerDiasEnMes(mes, año);
        return dia >= 1 && dia <= diasEnMes;
    }

    // Función para validar si el mes es válido
    static bool MesValido(int mes)
    {
        return mes >= 1 && mes <= 12;
    }

    // Función para validar si el año es válido
    static bool AñoValido(int año)
    {
        return año > 0;
    }


    // Función para obtener el número de días en un mes
    static int ObtenerDiasEnMes(int mes, int año)
    {
        // Variable local para almacenar los días
        int dias;

        switch (mes)
        {
            case 2: // Febrero
                dias = EsBisiesto(año) ? 29 : 28; // Año bisiesto o no
                break;
            case 4:
            case 6:
            case 9:
            case 11: // Abril, Junio, Septiembre, Noviembre
                dias = 30;
                break;
            default: // Meses con 31 días
                dias = 31;
                break;
        }

        return dias;
    }

    // Función para obtener el nombre del mes
    static string ObtenerNombreMes(int mes)
    {
        // Variable local con los nombres de los meses 
        string[] nombresMeses = {
            "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
        };

        return MesValido(mes) ? nombresMeses[mes - 1] : "Mes inválido"; 
    }

    // validación

    static int PedirAño()
    {
        int año;
        while (true)
        {
            Console.Write("Ingrese el año: ");
            if (int.TryParse(Console.ReadLine(), out año) && AñoValido(año))
            {
                return año;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Año inválido. Debe ser un número positivo.");
            Console.ResetColor();
        }
    }

    static int PedirMes()
    {
        int mes;
        while (true)
        {
            Console.Write("Ingrese el mes (1-12): ");
            if (int.TryParse(Console.ReadLine(), out mes) && MesValido(mes))
            {
                return mes;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Mes inválido. Debe estar entre 1 y 12.");
            Console.ResetColor();
        }
    }

    static int PedirDia()
    {
        int dia;
        while (true)
        {
            Console.Write("Ingrese el día: ");
            if (int.TryParse(Console.ReadLine(), out dia))
            {
                // Validaremos el día completo después de tener todos los datos
                if (dia >= 1 && dia <= 31)
                {
                    return dia;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Día inválido. Debe estar entre 1 y 31.");
            Console.ResetColor();
        }
    }
}