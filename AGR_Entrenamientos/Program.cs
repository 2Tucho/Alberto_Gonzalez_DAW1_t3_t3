Dictionary<string, string> usuarios = new Dictionary<string, string>();
usuarios.Add("agr@gmail.com", "1234"); // Usuario de prueba
int opcion;

do
{
    Console.WriteLine("SISTEMA DE GESTIÓN DE ENTRENAMIENTOS\n  1. Login\n  2. Registro\n  3. Cerrar aplicación\n");
    Console.WriteLine("Indica la opción deseada escribiendo su número de opción (1-3)");

    opcion = int.Parse(Console.ReadLine()); //Convierto a entero por comodidad

    switch (opcion)
    {
        case 1:
            Console.WriteLine("\n---LOGIN---");
            string correoLogin, passwordLogin;
            do // Para comprobar que el correo que pida está en el Diccionario, sino pedirá uno hasta que se de uno válido
            {
                Console.WriteLine("Dime un correo electrónico:");
                correoLogin = Console.ReadLine();
                if (!usuarios.ContainsKey(correoLogin))
                {
                    Console.WriteLine("Ese correo no está registrado, prueba otro diferente.\n"); //Mensaje que solo se muestra en caso de dar uno incorrecto
                }
            } while (!usuarios.ContainsKey(correoLogin));

            do // Si correo correcto pasa a pedir la contraseña, de la misma forma hasta que se de la que corresponde
            {
                Console.WriteLine("\nDime una contraseña:");
                passwordLogin = Console.ReadLine();

                if (usuarios[correoLogin] == passwordLogin) // Contraseña correcta así que lleva al menú de los entrenamientos
                {
                    Dictionary<string, string> marcas = new Dictionary<string, string>(); // Lo meto aquí fuera porque dentro del "do" me lo crea de nuevo cada vez que acabo con una opción del menú
                    int opcionEntreno;

                    do
                    {

                        Console.WriteLine($"\n¡Bienvenido al sistema de entrenamientos {correoLogin}!\n  1. Registar entrenamiento\n  2. Lista de entrenamientos\n  3. Vaciar lista de entrenamientos\n  4. Cerrar sesión\n");

                        Console.WriteLine("Indica la opción deseada escribiendo su número de opción (1-4)");
                        opcionEntreno = int.Parse(Console.ReadLine());

                        switch (opcionEntreno)
                        {
                            case 1:
                                Console.WriteLine("\n---REGISTRO ENTRENO---");
                                Console.WriteLine("Fecha del entreno (en formato 00/00/00)");
                                string fecha = Console.ReadLine();

                                Console.WriteLine("Marca realizada (en formato 00.00)");
                                string tiempo = Console.ReadLine();

                                marcas.Add(fecha, tiempo);
                                break;
                            case 2:
                                Console.WriteLine("\n---LISTA DE ENTRENOS---");
                                foreach (KeyValuePair<string, string> marca in marcas)
                                {
                                    Console.WriteLine($"  Fecha: {marca.Key} | Marca: {marca.Value} minutos");
                                }
                                break;
                            case 3:
                            marcas.Clear();
                                Console.WriteLine("\nLista de entrenamientos vaciada con éxito");
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("\nOpción no válida. Introduce un número del 1 al 4 dependiendo de la opción que quieras escoger.\n");
                                break;
                        }
                    } while (opcionEntreno != 4); // Se repite hasta que se cierre la sesión con la opción 4. Cierre

                    break;
                }
                else
                {
                    Console.WriteLine("\nEsa contraseña no es válida, prueba otra diferente.");
                }
            } while (true);

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
                    Console.WriteLine("Ese correo ya existe, prueba otro diferente.\n");
                }
            } while (usuarios.ContainsKey(correoRegistro));

            Console.WriteLine("\nY dime una contraseña:");
            passwordRegistro = Console.ReadLine();
            usuarios.Add(correoRegistro, passwordRegistro);

            break;

        case 3:
            break;

        default:
            Console.WriteLine("\nOpción no válida. Introduce un número del 1 al 3 dependiendo de la opción que quieras escoger.\n");
            break;
    }

} while (opcion != 3);
