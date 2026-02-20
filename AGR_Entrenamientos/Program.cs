Dictionary<string, string> usuarios = new Dictionary<string, string>();
int opcion;
do
{
    Console.WriteLine("SISTEMA DE GESTIÓN DE ENTRENAMIENTOS\n  1. Login\n  2. Registro\n  3. Cerrar aplicación");
    Console.WriteLine("Indica la opción deseada escribiendo su número de opción (1-3)");

    opcion = int.Parse(Console.ReadLine());
    usuarios.Add("agr@gmail.com", "1234");

    switch (opcion)
    {
        case 1:
            Console.WriteLine($"La opcion elegida es {opcion}");
            break;
        case 2:
            Console.WriteLine("\n---REGISTRO---");
            string correoRegistro, passwordRegistro;
            do
            {
                Console.WriteLine("Dime un correo electrónico:");
                correoRegistro = Console.ReadLine();
                if (usuarios.ContainsKey(correoRegistro))
                {
                    Console.WriteLine("Es correo ya existe, prueba otro diferente.\n");
                }
            } while (usuarios.ContainsKey(correoRegistro));

            Console.WriteLine("\nY dime una contraseña:");
            passwordRegistro = Console.ReadLine();
            usuarios.Add(correoRegistro, passwordRegistro);

            // foreach (KeyValuePair<string, string> usuario in usuarios)
            // {
            //     Console.WriteLine($"Email: {usuario.Key} - Contraseña: {usuario.Value}");
            // }

            opcion = 4;
            break;
        case 3:
            break;
        default:
            Console.WriteLine("\nOpción no válida. Introduce un número del 1 al 3 dependiendo de la opción que quieras escoger.\n");
            break;
    }

    // {
    //     string correoRegistro, passwordRegistro;
    //     do
    //     {
    //         Console.WriteLine("Dime correo para el registro:");
    //         correoRegistro = Console.ReadLine();
    //         //Console.WriteLine("Es correo ya existe, prueba otro diferente.");
    //     } while (usuarios.ContainsKey(correoRegistro));

    //     Console.WriteLine("Y dime una contraseña:");
    //     passwordRegistro = Console.ReadLine();
    //     usuarios.Add(correoRegistro, passwordRegistro);

    //     foreach (KeyValuePair<string, string> usuario in usuarios)
    //         {
    //             Console.WriteLine($"Email: {usuario.Key} - Contraseña: {usuario.Value}");
    //         }

    // Console.WriteLine("Dime correo para el registro:");
    // string correoRegistro = Console.ReadLine();

    // if (usuarios.ContainsKey(correoRegistro))
    // {
    //     Console.WriteLine($"\nUsuario {correoRegistro} ya existe en la base de datos");
    //     opcion = 2;
    // }
    // else
    // {
    //     Console.WriteLine("Y dime una contraseña:");
    //     string passwordRegistro = Console.ReadLine();
    //     usuarios.Add(correoRegistro, passwordRegistro);
    //     foreach (KeyValuePair<string, string> usuario in usuarios)
    //     {
    //         Console.WriteLine($"Email: {usuario.Key} - Contraseña: {usuario.Value}");
    //     }
    // }

} while (opcion <= 0 || opcion >= 4);
