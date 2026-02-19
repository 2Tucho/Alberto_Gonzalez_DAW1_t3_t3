// Crear el menú de opciones: login, registro, cierre
int opcion;
do
{
    Console.WriteLine("¡Bienvenido al sistema de gestión de entrenamientos!\n  1. Login\n  2. Registro\n  3. Cerrar aplicación");
    Console.WriteLine("Indica la opción deseada escribiendo su número de opción (1-3)");

    opcion = int.Parse(Console.ReadLine());
    
    if (opcion == 1)
    {
        Console.WriteLine($"La opcion elegida es {opcion}");
    }
    else if (opcion == 2)
    {
        Console.WriteLine($"La opcion elegida es {opcion}");
    }
    else if (opcion == 3)
    {
        Console.WriteLine($"La opcion elegida es {opcion}");
    }
    else
    {
        Console.WriteLine("\nOpción no válida. Introduce un número del 1 al 3 dependiendo de la opción que quieras escoger.\n");
    }
} while (opcion <= 0 || opcion >= 4);


