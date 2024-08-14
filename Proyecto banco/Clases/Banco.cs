using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_banco
{
    [Serializable]
    public class Banco
    {
        public string sIdentificacion;
        public string nombredelbanco;
        public string direccion;
        public string telefono;
        public List<Cliente> listaclientes = new List<Cliente>();

        public Banco()
        {
            listaclientes = new List<Cliente>();
        }

        public Banco(string nombredelbanco, string direccion, string telefono)
        {
            this.nombredelbanco = nombredelbanco;
            this.direccion = direccion;
            this.telefono = telefono;
            listaclientes = new List<Cliente>();

        }
        public void imprimirinfobanco()
        {
            Console.WriteLine("Nombre del banco "+ ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion).nombredelbanco);
            Console.WriteLine("Direccion del banco " + ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion).direccion);
            Console.WriteLine("Telefono del banco " + ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion).telefono);
            Console.WriteLine();
            Console.ReadLine();
        }

        public void crearcliente()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Ingrese Nombre");
                Console.ForegroundColor = ConsoleColor.White;
                string nombre = Console.ReadLine();
                if (string.IsNullOrEmpty(nombre))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Usted no ingreso nada intentelo de nuevo");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Ingrese Apellido");
                Console.ForegroundColor = ConsoleColor.White;
                string apellido = Console.ReadLine();
                if (string.IsNullOrEmpty(apellido))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Usted no ingreso nada intentelo de nuevo");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Ingrese Cedula");
                Console.ForegroundColor = ConsoleColor.White;
                string cedula = Console.ReadLine();
                if (string.IsNullOrEmpty(cedula))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Usted no ingreso nada intentelo de nuevo");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                else
                {
                    if (cedula.Substring(0).Length != 10)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ingrese una cedula valida");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Ingrese Correo Electronico");
                Console.ForegroundColor = ConsoleColor.White;
                string correo = Console.ReadLine();
                if (string.IsNullOrEmpty(correo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Usted no ingreso nada intentelo de nuevo");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Ingrese Contrasena");
                Console.ForegroundColor = ConsoleColor.White;
                string contasena = Console.ReadLine();
                if (string.IsNullOrEmpty(contasena))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Usted no ingreso nada intentelo de nuevo");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                int numerocliente = this.listaclientes.Count + 1;
                numerocliente = (ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion).listaclientes.Count) + 1;
                Cliente obj = new Cliente(nombre, apellido, cedula, numerocliente, contasena , correo);
                Banco objBanco = ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion);
                objBanco.listaclientes.Add(obj);
                ManipulacionArchivos.CrearArchivoBanco(objBanco);
                Console.WriteLine("Cliente creado con éxito");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ingreso un valor erroneo intentar de nuevo");
                Console.ReadLine();
            }
        }

        public void eliminarcliente()
        {
            string cedula = " ";
            try
            {
                Console.WriteLine("Ingrese el numero de cedula del cliente a Eliminar");
                cedula = Console.ReadLine();
                for (int i = 0; i < listaclientes.Count; i++)
                {
                    if (this.listaclientes[i].numerodeidentificacion == cedula)
                    {
                        Banco objBanco = ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion);
                        objBanco.listaclientes.RemoveAt(i);

                        ManipulacionArchivos.CrearArchivoBanco(objBanco);
                        Console.WriteLine("Cliente Eliminado con exito");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }
        }

        public void buscarcliente()
        {
            string cedula = " ";
            try
            {
                Console.WriteLine("Ingrese el numero de cedula del cliente a buscar");
                cedula = Console.ReadLine();
                for (int i = 0; i < listaclientes.Count; i++)
                {
                    if (listaclientes[i].numerodeidentificacion == cedula)
                    {
                        Console.WriteLine("Posicion " + (i + 1));
                        Console.WriteLine("Nombre: " + this.listaclientes[i].nombre);
                        Console.WriteLine("Apellido: " + this.listaclientes[i].apellido);
                        Console.WriteLine("Numero de indentificacion: " + this.listaclientes[i].numerodeidentificacion);
                        Console.WriteLine("Numero de cliente: " + this.listaclientes[i].numerocliente);
                        Console.WriteLine("Lista " + (i + 1) + ":");
                        for (int j = 0; j < this.listaclientes[i].cuentasbasociadas.Count; j++)
                        {
                            Console.WriteLine("Numero de cuenta: " + this.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                            Console.WriteLine("Saldo: " + this.listaclientes[i].cuentasbasociadas[j].saldo);
                            Console.WriteLine("Tipo de cuenta: " + this.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                        }
                    }
                }
                Console.ReadLine();
            }catch (Exception ex) { Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }
        }

        public void imprimirclientesycuentas()
        {
            for (int i = 0; i < this.listaclientes.Count; i++)
            {
                
                Console.WriteLine("Nombre: " + this.listaclientes[i].nombre);
                Console.WriteLine("Apellido: " + this.listaclientes[i].apellido);
                Console.WriteLine("Numero de indentificacion: " + this.listaclientes[i].numerodeidentificacion);
                Console.WriteLine("Numero de cliente: " + this.listaclientes[i].numerocliente);
                Console.WriteLine();
                for (int j = 0; j < this.listaclientes[i].cuentasbasociadas.Count; j++)
                {
                    Console.WriteLine("Cuenta de banco = " + (j + 1));
                    Console.WriteLine("Numero de cuenta: " + this.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                    Console.WriteLine("Saldo: " + this.listaclientes[i].cuentasbasociadas[j].saldo);
                    Console.WriteLine("Tipo de cuenta: " + this.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public void abrircuenta(string cedula,Cliente cliente)
        {
            int numerodecuenta = 0;
            //Console.Clear();
            
            try
            {
                for (int i = 0; i < this.listaclientes.Count; i++)
                {
                    if (cedula == this.listaclientes[i].numerodeidentificacion)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(" Escribir tipo de cuenta (Corriente o Ahorro)");
                        string tipocuenta = " ";
                        Console.ForegroundColor = ConsoleColor.White;
                        tipocuenta = Console.ReadLine();
                        tipocuenta = tipocuenta.ToLower();
                        if (tipocuenta == "corriente" | tipocuenta == "ahorro")
                        {
                            numerodecuenta = (this.listaclientes[i].cuentasbasociadas.Count) + 1;
                            CuentaBancaria obj = new CuentaBancaria(numerodecuenta, tipocuenta, 0, this.listaclientes[i].numerodeidentificacion,"no");
                            this.listaclientes[0].cuentasbasociadas.Add(obj);
                            Banco objBanco = ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion);
                            objBanco.listaclientes[i].cuentasbasociadas.Add(obj);
                            ManipulacionArchivos.CrearArchivoBanco(objBanco);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Cuenta creada con exito");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" Escriba el tipo de cuenta correctamente");
                        }
                    }
                }
                Console.ReadLine();
            } catch (Exception ex) {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }
        }

        public void cerrarcuenta(string cedula)
        {
            int numerocuenta = 0;
            //string cedula = " ";
            try
            {
                //Console.WriteLine("Ingrese el numero de cedula del cliente");
                //cedula = Console.ReadLine();
                //Console.WriteLine();
                for (int i = 0; i < this.listaclientes.Count; i++)
                {
                    if (cedula == this.listaclientes[i].numerodeidentificacion)
                    {
                        for (int j = 0; j < this.listaclientes[i].cuentasbasociadas.Count; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Numero de cuenta: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Saldo:            ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].saldo);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Tipo de cuenta:   ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                            Console.WriteLine();
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ingrese el numero de cuenta de la cuenta a borrar") ;
                        Console.ForegroundColor = ConsoleColor.White;
                        numerocuenta = Convert.ToInt32(Console.ReadLine());
                        numerocuenta= numerocuenta-1;

                        Banco objBanco = ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion);
                        objBanco.listaclientes[i].cuentasbasociadas.RemoveAt(numerocuenta);

                        ManipulacionArchivos.CrearArchivoBanco(objBanco);
                        Console.WriteLine();
                        Console.WriteLine("Cuenta cerrada con exito");
                        Console.ReadLine();
                    }
                }
                
            }
            catch (Exception ex) { Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }
        }

        public void infocliente()
        {
            try
            {
                Console.WriteLine("Ingrese el numero de cedula del cliente");
                string cedula = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < this.listaclientes.Count; i++)
                {
                    if (cedula == this.listaclientes[i].numerodeidentificacion)
                    {
                        Console.WriteLine("Nombre: " + this.listaclientes[i].nombre);
                        Console.WriteLine("Apellido: " + this.listaclientes[i].apellido);
                        Console.WriteLine("Numero ID: " + this.listaclientes[i].numerodeidentificacion);
                        Console.WriteLine("Numero Cliente: " + this.listaclientes[i].numerocliente);
                        Console.WriteLine("Numero de cuentas asociadas = "+ this.listaclientes[i].cuentasbasociadas.Count);
                    }
                }
                Console.ReadLine();
                Console.WriteLine();
            }
            catch (Exception ex) { Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }

        }

        public void imprimircuentasdecliente(string cedula)
        {
            try
            {
                for (int i = 0; i < this.listaclientes.Count; i++)
                {
                    if (cedula == this.listaclientes[i].numerodeidentificacion)
                    {
                        for (int j = 0; j < this.listaclientes[i].cuentasbasociadas.Count; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Numero de cuenta: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Saldo:            ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].saldo);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Tipo de cuenta:   ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                            Console.WriteLine();
                        }
                    }
                }
                Console.ReadLine() ;
                Console.WriteLine();
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }

        }

        public void depositar(string cedula)
        {
            try
            {
                decimal montodepocito = 0;
                decimal saldonuevo =0;
                int numerocuenta = 0;
                for (int i = 0; i < this.listaclientes.Count; i++)
                {
                    if (cedula == this.listaclientes[i].numerodeidentificacion)
                    {
                        for (int j = 0; j < this.listaclientes[i].cuentasbasociadas.Count; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Numero de cuenta: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].numerodecuenta) ;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Saldo:            ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].saldo) ;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Tipo de cuenta:   ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                            Console.WriteLine();
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ingrese el numero de cuenta de la cuenta a depositar");
                        Console.ForegroundColor = ConsoleColor.White;
                        numerocuenta = Convert.ToInt32(Console.ReadLine());
                        numerocuenta = numerocuenta - 1;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ingrese monto a depositar");
                        Console.ForegroundColor = ConsoleColor.White;
                        montodepocito = Convert.ToDecimal(Console.ReadLine());
                        saldonuevo = montodepocito + (this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo);
                        Transacciones transacciones = new Transacciones(DateTime.Now, "Deposito", montodepocito);
                        Banco objBanco = ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion);
                        objBanco.listaclientes[i].cuentasbasociadas[numerocuenta].saldo = saldonuevo;
                        objBanco.listaclientes[i].cuentasbasociadas[numerocuenta].historialtransaciones.Add(transacciones);
                        ManipulacionArchivos.CrearArchivoBanco(objBanco);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Cargando...");
                        EnvioCorreo correo = new EnvioCorreo();
                        correo.enviarCorreodeposito(this.listaclientes[i].correo, montodepocito ,numerocuenta);
                        Console.WriteLine() ;
                        Console.WriteLine("Deposito realizado con exito");
                        Console.ReadLine();
                    }
                }
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }
        }

        public void retirar(string cedula)
        {
            try
            {
                decimal montoaretirar = 0;
                decimal saldonuevo = 0;
                int numerocuenta = 0;
                for (int i = 0; i < this.listaclientes.Count; i++)
                {
                    if (cedula == this.listaclientes[i].numerodeidentificacion)
                    {
                        for (int j = 0; j < this.listaclientes[i].cuentasbasociadas.Count; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Numero de cuenta: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Saldo:            ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].saldo);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Tipo de cuenta:   ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                            Console.WriteLine();
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ingrese el numero de cuenta de la  cuenta a retirar");
                        Console.ForegroundColor = ConsoleColor.White;
                        numerocuenta = Convert.ToInt32(Console.ReadLine());
                        numerocuenta = numerocuenta - 1;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ingrese monto a retirar");
                        Console.ForegroundColor = ConsoleColor.White;
                        montoaretirar = Convert.ToDecimal(Console.ReadLine());

                        if (montoaretirar <= this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo)
                        {
                            saldonuevo =(this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo) - montoaretirar;

                            CuentaBancaria obj = new CuentaBancaria(this.listaclientes[i].cuentasbasociadas[numerocuenta].numerodecuenta, this.listaclientes[i].cuentasbasociadas[numerocuenta].tipodecuenta, saldonuevo, this.listaclientes[i].cuentasbasociadas[numerocuenta].propietario, this.listaclientes[i].cuentasbasociadas[numerocuenta].sino);

                            Transacciones transacciones = new Transacciones(DateTime.Now, "Deposito", montoaretirar);
                            Banco objBanco = ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion);
                            objBanco.listaclientes[i].cuentasbasociadas[numerocuenta].saldo = saldonuevo;
                            objBanco.listaclientes[i].cuentasbasociadas[numerocuenta].historialtransaciones.Add(transacciones);
                            ManipulacionArchivos.CrearArchivoBanco(objBanco);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Cargando...");
                            Console.WriteLine();
                            EnvioCorreo correo = new EnvioCorreo();
                            correo.enviarCorreoRetiro(this.listaclientes[i].correo, montoaretirar, numerocuenta, (this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo-montoaretirar));
                            Console.WriteLine("Retiro realizado con exito");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("El monto a retirar es mayor al saldo disponible");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Usted dispone de " + this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo + " en la cuenta " + this.listaclientes[i].cuentasbasociadas[numerocuenta].numerodecuenta);
                            Console.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }
        }

        public void transferir(string cedula)
        {
            try
            {
                string cedula2;
                decimal montoaretirar = 0;
                decimal montoatransferir = 0;
                decimal saldonuevo = 0;
                decimal saldonuevo2 = 0;
                int numerocuenta = 0;
                int numerocuenta2 = 0;
                Console.WriteLine();
                for (int i = 0; i < this.listaclientes.Count; i++)
                {
                    if (cedula == this.listaclientes[i].numerodeidentificacion)
                    {
                        for (int j = 0; j < this.listaclientes[i].cuentasbasociadas.Count; j++)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Numero de cuenta: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Saldo:            ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].saldo);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Tipo de cuenta:   ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                            Console.WriteLine();
                        }
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ingrese el numero de cuenta de la  cuenta a retirar");
                        Console.ForegroundColor = ConsoleColor.White;
                        numerocuenta = Convert.ToInt32(Console.ReadLine());
                        numerocuenta = numerocuenta - 1;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Ingrese monto a retirar");
                        Console.ForegroundColor = ConsoleColor.White;
                        montoaretirar = Convert.ToDecimal(Console.ReadLine());
                        montoatransferir = montoaretirar;
                        if (montoaretirar <= this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo)
                        {
                            saldonuevo = (this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo) - montoaretirar;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Ingrese el numero de cedula del cliente al que transferira");
                            Console.ForegroundColor = ConsoleColor.White;
                            cedula2 = Console.ReadLine();
                            Console.WriteLine();
                            for ( int z  = 0; z < this.listaclientes.Count; z++)
                            {
                                if ( cedula2 == this.listaclientes[z].numerodeidentificacion)
                                {
                                    for (int x = 0; x < this.listaclientes[z].cuentasbasociadas.Count; x++)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write("Numero de cuenta: ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(this.listaclientes[z].cuentasbasociadas[x].numerodecuenta);
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write("Tipo de cuenta:   ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(this.listaclientes[z].cuentasbasociadas[x].tipodecuenta);
                                        Console.WriteLine();
                                    }
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Ingrese el numero de cuenta de la cuenta a depositar");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    numerocuenta2 = Convert.ToInt32(Console.ReadLine());
                                    numerocuenta2 = numerocuenta2 - 1;
                                    saldonuevo2 = montoatransferir + (this.listaclientes[z].cuentasbasociadas[numerocuenta2].saldo);
                                    Transacciones trans1 = new Transacciones(DateTime.Now,"Transferencia Enviada",saldonuevo);
                                    Transacciones trans2 = new Transacciones(DateTime.Now, "Transferencia Recibida", saldonuevo2);
                                    Banco objBanco = ManipulacionArchivos.GetArchivoBanco(this.sIdentificacion);
                                    objBanco.listaclientes[i].cuentasbasociadas[numerocuenta].saldo = saldonuevo;
                                    objBanco.listaclientes[i].cuentasbasociadas[numerocuenta].historialtransaciones.Add(trans1);
                                    objBanco.listaclientes[z].cuentasbasociadas[numerocuenta2].saldo = saldonuevo2;
                                    objBanco.listaclientes[z].cuentasbasociadas[numerocuenta2].historialtransaciones.Add(trans2);
                                    ManipulacionArchivos.CrearArchivoBanco(objBanco);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Cargando...");
                                    Console.WriteLine();
                                    EnvioCorreo correoenvia = new EnvioCorreo();
                                    EnvioCorreo correorecibe = new EnvioCorreo();
                                    correoenvia.enviarCorreoEnviotranferencia(this.listaclientes[i].correo, montoaretirar, numerocuenta , this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo - montoaretirar, this.listaclientes[z].nombre + " " + this.listaclientes[z].apellido);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Cargando...");
                                    Console.WriteLine();
                                    correorecibe.enviarCorreoRecibotranferencia(this.listaclientes[z].correo, montoatransferir, numerocuenta2 , this.listaclientes[i].nombre + " " + this.listaclientes[i].apellido);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Transferencia de "+montoaretirar+" a la cuenta de " + this.listaclientes[z].nombre +" " + this.listaclientes[z].apellido+" realizada con exito") ;
                                    Console.ReadLine();
                                }
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("El monto a retirar es mayor al saldo disponible");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Usted dispone de " + this.listaclientes[i].cuentasbasociadas[numerocuenta].saldo + " en la cuenta " + this.listaclientes[i].cuentasbasociadas[numerocuenta].numerodecuenta);
                            Console.ReadLine() ;
                        }
                    }
                }
                Console.WriteLine();
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }
        }

        public void imprimirtrasnacciones (string cedula)
        {
            try
            {
                for (int i = 0; i < this.listaclientes.Count; i++)
                {
                    if (cedula == this.listaclientes[i].numerodeidentificacion)
                    {
                        for (int j = 0; j < this.listaclientes[i].cuentasbasociadas.Count; j++)
                        {
                            for (int k = 0; k < this.listaclientes[i].cuentasbasociadas[j].historialtransaciones.Count; k++)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("Cuenta ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("000" + this.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("Tipo de movimiento ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].historialtransaciones[k].tipodemovimiento + " $" + this.listaclientes[i].cuentasbasociadas[j].historialtransaciones[k].monto);
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("Fecha y hora de la transaccion ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(this.listaclientes[i].cuentasbasociadas[j].historialtransaciones[k].fecha);
                                Console.WriteLine();
                            }
                        }
                    }
                }
                Console.ReadLine();
                Console.WriteLine();
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Intente de nuevo");
                Console.ReadLine();
            }
        }

    }
}
