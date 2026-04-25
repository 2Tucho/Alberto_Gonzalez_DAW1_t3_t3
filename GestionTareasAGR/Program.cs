
public class Program
{
    static void Main(string[] args)
    {
        GestorTareas gestor = new GestorTareas();
        bool cerrar = false;

        while (!cerrar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearTarea(gestor);
                    break;
                case "2":
                    BuscarTareaPorTipo(gestor);
                    break;
                case "3":
                    gestor.MostrarTodas();
                    break;
                case "4":
                    EliminarTarea(gestor);
                    break;
                case "5":
                    gestor.ExportarTareas();
                    break;
                case "6":
                    gestor.ImportarTareas();
                    break;
                case "0":
                    cerrar = true;
                    Console.WriteLine("\n¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                    break;
            }

            if (!cerrar)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== GESTOR DE TAREAS ===\n1. Crear tarea\n2. Buscar tareas por tipo\n3. Mostrar todas las tareas\n4. Eliminar tarea por ID\n5. Exportar tareas a archivo\n6. Importar tareas desde archivo\n0. Salir");
        Console.Write("\nSeleccione una opción: ");
    }

    static void CrearTarea(GestorTareas gestor)
    {
        Console.Clear();
        Console.WriteLine("=== CREAR NUEVA TAREA ===");

        Console.Write("Nombre: ");
        string? nombre = Console.ReadLine();

        Console.Write("Descripción: ");
        string? descripcion = Console.ReadLine();

        Console.WriteLine("Tipos disponibles: personal, trabajo, ocio");
        Console.Write("Tipo: ");
        string tipoStr = Console.ReadLine().ToLower();
        TipoTarea tipo;
        while (!Enum.TryParse(tipoStr, out tipo))
        {
            Console.Write("Tipo no válido. Elija personal, trabajo o ocio: ");
            tipoStr = Console.ReadLine().ToLower();
        }

        Console.Write("¿Es prioridad alta? (s/n): ");
        bool prioridad = Console.ReadLine().ToLower() == "s";

        gestor.CrearTarea(nombre, descripcion, tipo, prioridad);
    }

    static void BuscarTareaPorTipo(GestorTareas gestor)
    {
        Console.Clear();
        Console.WriteLine("=== BUSCAR TAREAS POR TIPO ===\nTipos disponibles: personal, trabajo, ocio");
        Console.Write("Tipo: ");
        string tipoStr = Console.ReadLine().ToLower();
        TipoTarea tipo;

        if (Enum.TryParse(tipoStr, out tipo))
        {
            gestor.BuscarPorTipo(tipo);
        }
        else
        {
            Console.WriteLine("\nTipo no válido.");
        }
    }

    static void EliminarTarea(GestorTareas gestor)
    {
        Console.Clear();
        Console.WriteLine("=== ELIMINAR TAREA ===\nIngrese el ID de la tarea a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            gestor.EliminarTarea(id);
        }
        else
        {
            Console.WriteLine("\nID no válido.");
        }
    }
}
