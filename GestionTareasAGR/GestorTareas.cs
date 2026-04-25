public class GestorTareas
{
    private List<Tarea> tareas = new List<Tarea>();
    private int siguienteId = 0;

    public void CrearTarea(string nombre, string descripcion, TipoTarea tipo, bool prioridad)
    {
        Tarea nuevaTarea = new Tarea
        {
            Id = siguienteId++, //Para que nunca pueda repetirse el mismo, siempre será cada vez uno mayor
            Nombre = nombre,
            Descripcion = descripcion,
            Tipo = tipo,
            Prioridad = prioridad
        };
        tareas.Add(nuevaTarea);
        Console.WriteLine($"\nTarea creada con ID: {nuevaTarea.Id}");

    }

    public void BuscarPorTipo(TipoTarea tipo)
    {
        List<Tarea> tareasFiltradas = new List<Tarea>(); //Lo mismo que List<Tarea> tareasFiltradas = tareas.Where(tarea => tarea.Tipo == tipo).ToList();
        foreach (var tarea in tareas)
        {
            if (tarea.Tipo == tipo)
            {
                tareasFiltradas.Add(tarea);
            }
        }

        if (tareasFiltradas.Count == 0)
        {
            Console.WriteLine($"\nNo hay tareas del tipo {tipo}");
        }
        else
        {
            Console.WriteLine($"\n___ Tareas de tipo {tipo} ___");
            foreach (var tarea in tareasFiltradas)
            {
                Console.WriteLine(tarea.Mostrar());
            }
        }
    }

    public bool EliminarTarea(int id)
    {
        for (int i = 0; i < tareas.Count; i++)
        {
            if (tareas[i].Id == id)
            {
                tareas.RemoveAt(i);
                Console.WriteLine("Tarea eliminada correctamente.");
                return true;
            }
        }

        Console.WriteLine($"No se encontró ninguna tarea con el ID {id}.");
        return false;
    }

    public void ExportarTareas()
    {
        if (tareas.Count == 0)
        {
            Console.WriteLine("\nNo hay tareas para exportar.");
            return;
        }

        using (StreamWriter writer = new StreamWriter("tareas.txt"))
        {
            foreach (var tarea in tareas)
            {
                writer.WriteLine(tarea.ToString());
            }
        }
        Console.WriteLine($"\nTareas exportadas correctamente a 'tareas.txt' ({tareas.Count} tareas)");
    }

    public void ImportarTareas()
    {
        if (!File.Exists("tareas.txt"))
        {
            Console.WriteLine("\nNo se encontró el archivo 'tareas.txt'");
            return;
        }

        int tareasImportadas = 0;
        int maxId = siguienteId - 1;

        using (StreamReader reader = new StreamReader("tareas.txt"))
        {
            string linea;
            while ((linea = reader.ReadLine()) != null)
            {
                string[] partes = linea.Split('/');
                if (partes.Length == 5) //5 porque son 5 las cosas que lleva: id, nombre, descripción, tipo y prioridad
                {
                    Tarea tarea = new Tarea
                    {
                        Id = int.Parse(partes[0]),
                        Nombre = partes[1],
                        Descripcion = partes[2],
                        Tipo = (TipoTarea)Enum.Parse(typeof(TipoTarea), partes[3]),
                        Prioridad = bool.Parse(partes[4])
                    };

                    tareas.Add(tarea);
                    tareasImportadas++;

                    if (tarea.Id > maxId) //Para que no se vuelva loco y se bloquee porque ya no está el ID correcto
                        maxId = tarea.Id;
                }
            }
        }

        siguienteId = maxId + 1;
        Console.WriteLine($"\n{tareasImportadas} tareas importadas correctamente desde 'tareas.txt'");
    }

    // Mostrar todas las tareas (útil para debugging)
    public void MostrarTodas()
    {
        if (tareas.Count == 0)
        {
            Console.WriteLine("\nNo hay tareas registradas.");
            return;
        }

        Console.WriteLine("\n--- LISTA DE TAREAS ---");
        foreach (var tarea in tareas)
        {
            Console.WriteLine(tarea.Mostrar());
        }
        Console.WriteLine($"Total: {tareas.Count} tareas");
    }
}
