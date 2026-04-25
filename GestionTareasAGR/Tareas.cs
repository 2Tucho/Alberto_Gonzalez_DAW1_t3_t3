
// Enumerado para los tipos de tarea
public enum TipoTarea
{
    personal,
    trabajo,
    ocio
}

public class Tarea
{
    public Tarea() { }
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public TipoTarea Tipo { get; set; }
    public bool Prioridad { get; set; }

    public override string ToString() //Este es el formato con el que en GestorTareas voy a escribir las tareas en el archivo .txt
    {
        return $"{Id}/{Nombre}/{Descripcion}/{Tipo}/{Prioridad}";
    }

    public string Mostrar()
    {
        string prioridadStr = Prioridad ? "SI" : "NO"; //If con ternario: si Prioridad es true lo cambio por un "SI" y si es falso por un "NO"
        return $"ID: {Id} / Nombre: {Nombre} / Descripción: {Descripcion} / Tipo: {Tipo} / Prioridad: {prioridadStr}"; //Que aparezca el ID al mostrar la lista de tareas para saber cuál es si se quiere borrar alguna
    }
}
