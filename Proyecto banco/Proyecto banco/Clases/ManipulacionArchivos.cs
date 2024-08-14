using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Proyecto_banco
{

    public static class ManipulacionArchivos
    {
        private static string directoryPathCliente = "C:\\ArchivosProyecto\\ArchivosCliente";
        private static string directoryPathBanco = "C:\\ArchivosProyecto\\ArchivosBanco";
        private static string directoryPathCuentaBancaria = "C:\\ArchivosProyecto\\ArchivosCuentaBancaria";
        private static string directoryPathtrasacciones = "C:\\ArchivosProyecto\\Archivostrasacciones";

        public static void CrearArchivoCliente(Cliente cliente)
        {
            try
            {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPathCliente))
                {
                    Directory.CreateDirectory(directoryPathCliente);
                }

                string filePath = Path.Combine(directoryPathCliente, cliente.numerodeidentificacion + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, cliente);
                }

                Console.WriteLine("Archivo creado con el cliente.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
        public static Cliente GetArchivoCliente(string numerodeidentificacion)
        {
            Cliente cliente = null;

            try
            {
                string filePath = Path.Combine(directoryPathCliente, numerodeidentificacion + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    cliente = (Cliente)formatter.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El archivo no existe.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Error de serialización: {e.Message}");
            }
            return cliente;
        }
        public static void ActualizarArchivoCliente(Cliente cliente)
        {
            CrearArchivoCliente(cliente);
        }
        public static void DeleteFileCliente(string numerodeidentificacion)
        {
            try
            {
                string filePath = Path.Combine(directoryPathCliente, numerodeidentificacion + ".bin");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Archivo eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("El archivo no existe y no se puede eliminar.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al eliminar el archivo: {e.Message}");
            }
        }



        public static void CrearArchivoBanco(Banco banco)
        {
            try
            {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPathBanco))
                {
                    Directory.CreateDirectory(directoryPathBanco);
                }

                string filePath = Path.Combine(directoryPathBanco, banco.sIdentificacion + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, banco);
                }

                //Console.WriteLine("Archivo creado con el Banco.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
        public static Banco GetArchivoBanco(string nombredelbanco)
        {
            Banco banco = null;

            try
            {
                string filePath = Path.Combine(directoryPathBanco, nombredelbanco + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    banco = (Banco)formatter.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El archivo no existe.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Error de serialización: {e.Message}");
            }
            return banco;
        }
        public static void ActualizarArchivoBanco(Banco banco)
        {
            CrearArchivoBanco(banco);
        }
        public static void DeleteFileBanco(string nombredelbanco)
        {
            try
            {
                string filePath = Path.Combine(directoryPathBanco, nombredelbanco + ".bin");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Archivo eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("El archivo no existe y no se puede eliminar.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al eliminar el archivo: {e.Message}");
            }
        }



        public static void CrearArchivoCuentaBancaria(CuentaBancaria cuentabancaria)
        {
            try
            {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPathCuentaBancaria))
                {
                    Directory.CreateDirectory(directoryPathCuentaBancaria);
                }

                string filePath = Path.Combine(directoryPathCuentaBancaria, cuentabancaria.numerodecuenta + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, cuentabancaria);
                }

                Console.WriteLine("Archivo creado la cuenta bancaria.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
        public static CuentaBancaria GetArchivoCuentaBancaria (string numerodecuenta)
        {
            CuentaBancaria cuentabancaria = null;

            try
            {
                string filePath = Path.Combine(directoryPathCuentaBancaria, numerodecuenta + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    cuentabancaria = (CuentaBancaria)formatter.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El archivo no existe.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Error de serialización: {e.Message}");
            }
            return cuentabancaria;
        }
        public static void ActualizarArchivoCuentaBancaria(CuentaBancaria cuentabancaria)
        {
            CrearArchivoCuentaBancaria(cuentabancaria);
        }
        public static void DeleteFileCuentaBancaria(string numerodecuenta)
        {
            try
            {
                string filePath = Path.Combine(directoryPathCuentaBancaria, numerodecuenta + ".bin");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Archivo eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("El archivo no existe y no se puede eliminar.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al eliminar el archivo: {e.Message}");
            }
        }



        public static void CrearArchivotrasacciones(Transacciones objTransacciones)
        {
            try
            {
                // Asegurarse de que el directorio exista
                if (!Directory.Exists(directoryPathtrasacciones))
                {
                    Directory.CreateDirectory(directoryPathtrasacciones);
                }

                string filePath = Path.Combine(directoryPathtrasacciones, objTransacciones.fecha + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, objTransacciones);
                }

                Console.WriteLine("Archivo creado con el cliente.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al crear el archivo: {e.Message}");
            }
        }
        public static Transacciones GetArchivotrasacciones (string fecha)
        {
            Transacciones trasacciones = null;

            try
            {
                string filePath = Path.Combine(directoryPathtrasacciones, trasacciones.fecha + ".bin");

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    trasacciones = (Transacciones)formatter.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("El archivo no existe.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al leer el archivo: {e.Message}");
            }
            catch (SerializationException e)
            {
                Console.WriteLine($"Error de serialización: {e.Message}");
            }
            return trasacciones;
        }
        public static void ActualizarArchivotrasacciones(Transacciones trasacciones)
        {
            CrearArchivotrasacciones(trasacciones);
        }
        public static void DeleteFiletrasacciones(string fecha)
        {
            try
            {
                string filePath = Path.Combine(directoryPathtrasacciones, fecha + ".bin");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Archivo eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("El archivo no existe y no se puede eliminar.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error al eliminar el archivo: {e.Message}");
            }
        }

    }
}
