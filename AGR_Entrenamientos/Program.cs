Dictionary<string, string> usuarios = new Dictionary<string, string>();
usuarios.Add("agr@gmail.com", "1234");
int opcion;

do
{
    Console.WriteLine("SISTEMA DE GESTIÓN DE ENTRENAMIENTOS\n  1. Login\n  2. Registro\n  3. Cerrar aplicación\n");
    Console.WriteLine("Indica la opción deseada escribiendo su número de opción (1-3)");

    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.WriteLine("\n---LOGIN---");
            string correoLogin, passwordLogin;
            do
            {
                Console.WriteLine("Dime un correo electrónico:");
                correoLogin = Console.ReadLine();
                if (!usuarios.ContainsKey(correoLogin))
                {
                    Console.WriteLine("Ese correo no está registrado, prueba otro diferente.\n");
                }
            } while (!usuarios.ContainsKey(correoLogin));

            do
            {
                Console.WriteLine("\nDime una contraseña:");
                passwordLogin = Console.ReadLine();

                if (usuarios[correoLogin] == passwordLogin)
                {
                    int opcionEntreno;
                    do
                    {

                        Console.WriteLine($"¡Bienvenido al sistema de entrenamientos {correoLogin}!\n  1. Registar entrenamiento\n  2. Lista de entrenamientos\n  3. Vaciar lista de entrenamientos\n  4. Cerrar sesión\n");

                        Console.WriteLine("Indica la opción deseada escribiendo su número de opción (1-4)");
                        opcionEntreno = int.Parse(Console.ReadLine());

                        switch (opcionEntreno)
                        {
                            case 1:
                            Console.WriteLine("\n---REGISTRO ENTRENO---");
                                break;
                            case 2:
                            Console.WriteLine("\n---LISTA DE ENTRENOS---");
                                break;
                            case 3:
                            Console.WriteLine("\nLista de entrenamientos vaciada con éxito");
                                break;
                            case 4:
                                break;
                            default:
                                Console.WriteLine("\nOpción no válida. Introduce un número del 1 al 4 dependiendo de la opción que quieras escoger.\n");
                                break;
                        }
                    //} while (opcionEntreno <= 0 || opcionEntreno >= 4);
                    } while (opcionEntreno != 4);

                    break;
                }
                else
                {
                    Console.WriteLine("\nEsa contraseña no es válida, prueba otra diferente.");
                }
            //} while (usuarios[correoLogin] != passwordLogin);
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

} while (opcion != 3);
