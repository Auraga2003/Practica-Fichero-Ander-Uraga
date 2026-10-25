
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string nombreFichero = "";
        int opcion = 0;

        while (opcion <= 6)
        {
            Console.WriteLine("\n--- GESTION DE FICHEROS ---");
            Console.WriteLine("1. Crear un nuevo fichero");
            Console.WriteLine("2. Añadir registros");
            Console.WriteLine("3. Eliminar todos los registros");
            Console.WriteLine("4. Eliminar el fichero");
            Console.WriteLine("5. Visualizar los registros");
            Console.WriteLine("6. Cerrar la aplicacion");
            Console.Write("Elige una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Introduce un numero valido.");
                continue;
            }

            try
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Introduce el nombre del fichero: ");
                        nombreFichero = Console.ReadLine() ?? "";

                        if (nombreFichero.Trim() == "")
                        {
                            Console.WriteLine("El nombre no puede estar vacio.");
                            break;
                        }

                        if (File.Exists(nombreFichero))
                        {
                            Console.WriteLine("Ese fichero ya existe.");
                        }
                        else
                        {
                            using (File.Create(nombreFichero))
                            {
                            }

                            Console.WriteLine("Fichero creado correctamente.");
                        }
                        break;

                    case 2:
                        if (!File.Exists(nombreFichero))
                        {
                            Console.WriteLine("Primero debes crear o seleccionar un fichero.");
                            break;
                        }

                        Console.WriteLine("Escribe los registros. Pulsa Enter sin escribir nada para terminar.");

                        using (StreamWriter escritor = new StreamWriter(nombreFichero, true))
                        {
                            string registro;

                            while (true)
                            {
                                Console.Write("Registro: ");
                                registro = Console.ReadLine() ?? "";

                                if (registro == "")
                                {
                                    break;
                                }

                                escritor.WriteLine(registro);
                            }
                        }

                        Console.WriteLine("Registros guardados.");
                        break;

                    case 3:
                        if (!File.Exists(nombreFichero))
                        {
                            Console.WriteLine("El fichero no existe.");
                            break;
                        }

                        File.WriteAllText(nombreFichero, "");
                        Console.WriteLine("Se han eliminado todos los registros.");
                        break;

                    case 4:
                        if (!File.Exists(nombreFichero))
                        {
                            Console.WriteLine("El fichero no existe.");
                            break;
                        }

                        File.Delete(nombreFichero);
                        nombreFichero = "";
                        Console.WriteLine("Fichero eliminado correctamente.");
                        break;

                    case 5:
                        if (!File.Exists(nombreFichero))
                        {
                            Console.WriteLine("El fichero no existe.");
                            break;
                        }

                        string[] registros = File.ReadAllLines(nombreFichero);

                        if (registros.Length == 0)
                        {
                            Console.WriteLine("El fichero esta vacio.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- REGISTROS GUARDADOS ---");

                            foreach (string registro in registros)
                            {
                                Console.WriteLine(registro);
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Cerrando la aplicacion...");
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        break;
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error al leer, escribir o eliminar el fichero.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("No tienes permisos para acceder al fichero.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("El nombre o la ruta del fichero no son validos.");
            }
        }
    }
}
