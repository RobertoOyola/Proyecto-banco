using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Drawing.Printing;

namespace Proyecto_banco
{
    [Serializable]
    public class EnvioCorreo
    {

        private string sSmtpServer = "smtp.outlook.com";
        private int iPuertoSmtp = 587;
        private string sCorreoRemitente = "tecnobanco_cristiano_innovador@outlook.com";
        private string sContrasena = "TecnoBanco1234";

        public string sCorreoDestinatario = "";
        public string sContenido = "";
        public string sAsunto = "";



        public EnvioCorreo() { }
        public EnvioCorreo(string sContenido, string sAsunto, string sCorreoDestinatario)
        {
            this.sContenido = sContenido;
            this.sAsunto = sAsunto;
            this.sCorreoDestinatario = sCorreoDestinatario;
        }

        public void enviarCorreo()
        {
            MailMessage correo = new MailMessage(sCorreoRemitente, sCorreoDestinatario, sAsunto, sContenido);
            correo.IsBodyHtml = true;
            SmtpClient clienteSmtp = new SmtpClient(sSmtpServer)
            {
                Port = iPuertoSmtp,
                Credentials = new NetworkCredential(sCorreoRemitente, sContrasena),
                EnableSsl = true,
            };
            try
            {
                clienteSmtp.Send(correo);
                Console.WriteLine("Correo enviado con éxito!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Existió un error al enviar: " + ex.Message);

            }

        }

        public void enviarCorreodeposito(string correocliente, decimal montodeposito, int numerocuenta)
        {
            string contenido = " ";
            contenido =
                "<br/>" +
                "Se ha realizado un depósito con éxito <br/>" +
                "El Depósito ha sido de " + montodeposito.ToString() + " dólares a su cuenta 0000" + (numerocuenta + 1) + "<br/>" +
                "<br/>" +
                "Si usted no ha realizado este depósito o algo ha salido mal por favor comunicarse al " +
                "0992940360 <br/>" +
                "<br/>"+
                "<br/>"+
                "Tecnobanco Cristiano Innovador"
                ;

            MailMessage correo = new MailMessage(sCorreoRemitente, correocliente, "Depósito", contenido);
            correo.IsBodyHtml = true;
            SmtpClient clienteSmtp = new SmtpClient(sSmtpServer)
            {
                Port = iPuertoSmtp,
                Credentials = new NetworkCredential(sCorreoRemitente, sContrasena),
                EnableSsl = true,
            };
            try
            {
                clienteSmtp.Send(correo);
                Console.WriteLine("Correo enviado con éxito!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Existió un error al enviar: " + ex.Message);

            }

        }

        public void enviarCorreoRetiro(string correocliente, decimal montoaretirar, int numerocuenta, decimal saldo)
        {
            string contenido = " ";
            contenido =
                "<br/>" +
                "Se ha realizado un Retiro con éxito <br/>" +
                "El Retiro ha sido de " + montoaretirar.ToString() + " dólares a su cuenta 0000" + (numerocuenta + 1) +" teniendo un saldo de "+saldo+ " dólares en su cuenta<br/>" +
                "<br/>" +
                "Si usted no ha realizado este Retiro o algo ha salido mal por favor comunicarse al " +
                "0992940360 <br/>" +
                "<br/>" +
                "<br/>" +
                "Tecnobanco Cristiano Innovador"
                ;

            MailMessage correo = new MailMessage(sCorreoRemitente, correocliente, "Retiro", contenido);
            correo.IsBodyHtml = true;
            SmtpClient clienteSmtp = new SmtpClient(sSmtpServer)
            {
                Port = iPuertoSmtp,
                Credentials = new NetworkCredential(sCorreoRemitente, sContrasena),
                EnableSsl = true,
            };
            try
            {
                clienteSmtp.Send(correo);
                Console.WriteLine("Correo enviado con éxito!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Existió un error al enviar: " + ex.Message);

            }

        }

        public void enviarCorreoEnviotranferencia(string correocliente, decimal montoaretirar, int numerocuenta, decimal saldo , string  nombreyapellido)
        {
            string contenido = " ";
            contenido =
                "<br/>" +
                "Se ha realizado su transferencia a "+ nombreyapellido +" con éxito <br/>" +
                "La transferencia ha sido de " + montoaretirar.ToString() + " dólares de su cuenta 0000" + (numerocuenta + 1) + " teniendo un saldo de " + saldo + " dólares en su cuenta<br/>" +
                "<br/>" +
                "Si usted no ha realizado esta Transferencia o algo ha salido mal por favor comunicarse al " +
                "0992940360 <br/>" +
                "<br/>" +
                "<br/>" +
                "Tecnobanco Cristiano Innovador"
                ;

            MailMessage correo = new MailMessage(sCorreoRemitente, correocliente, "Tranferencia Enviada", contenido);
            correo.IsBodyHtml = true;
            SmtpClient clienteSmtp = new SmtpClient(sSmtpServer)
            {
                Port = iPuertoSmtp,
                Credentials = new NetworkCredential(sCorreoRemitente, sContrasena),
                EnableSsl = true,
            };
            try
            {
                clienteSmtp.Send(correo);
                Console.WriteLine("Correo enviado con éxito!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Existió un error al enviar: " + ex.Message);
            }
        }

        public void enviarCorreoRecibotranferencia(string correocliente, decimal montoarecibir, int numerocuentarecibe, string nombreyapellidodelqueenvia)
        {
            string contenido = " ";
            contenido =
                "<br/>" +
                "Usted a recibido un transferencia de " + nombreyapellidodelqueenvia + " con éxito <br/>" +
                "La transferencia ha sido de " + montoarecibir.ToString() + " dólares a su cuenta 0000" + (numerocuentarecibe + 1) +"<br/>" +
                "<br/>" +
                "Si tiene algun problema con la trasferencia o algo ha salido mal por favor comunicarse al " +
                "0992940360 <br/>" +
                "<br/>" +
                "<br/>" +
                "Tecnobanco Cristiano Innovador"
                ;

            MailMessage correo = new MailMessage(sCorreoRemitente, correocliente, "Tranferencia Enviada", contenido);
            correo.IsBodyHtml = true;
            SmtpClient clienteSmtp = new SmtpClient(sSmtpServer)
            {
                Port = iPuertoSmtp,
                Credentials = new NetworkCredential(sCorreoRemitente, sContrasena),
                EnableSsl = true,
            };
            try
            {
                clienteSmtp.Send(correo);
                Console.WriteLine("Correo enviado con éxito!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Existió un error al enviar: " + ex.Message);
            }
        }

        public void enviarCorreoEstadodeceunta(Cliente cliente)
        {
            int a = 0;
            int numerocuenta = 0;
            try
            {
                Console.WriteLine();
                for (int i = 0; i < cliente.cuentasbasociadas.Count; i++)
                {
                    //esto es lo que se vera en el programa
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Número de cuenta: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(cliente.cuentasbasociadas[i].numerodecuenta);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Saldo:            ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(cliente.cuentasbasociadas[i].saldo);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Tipo de cuenta:   ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(cliente.cuentasbasociadas[i].tipodecuenta);
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Ingrese el número de cuenta de la cuenta a sacar el estado de cuenta");
                Console.ForegroundColor = ConsoleColor.White;
                numerocuenta = Convert.ToInt32(Console.ReadLine());
                numerocuenta = numerocuenta - 1;

                string contenido = " ";
                contenido +=
                    //No tocar de aqui para abajo
                    "<br/>" +
                    "Estado de cuenta de la tarjeta: 000" + cliente.cuentasbasociadas[numerocuenta].numerodecuenta+"<br/>" +
                    "Nombre del Dueño de la tarjeta: " + cliente.nombre +" "+ cliente.apellido + "<br/>" +
                    "Número de Usuario             : " + cliente.numerodeidentificacion + "<br/>"+
                    "<br/>" +
                    "-----------------------------------------"+"<br/>" +
                    "<br/>" +
                    "-------Fecha y hora ----- Cuenta -- Monto -- Tipo de Movimiento<br/>";
                for (int i = 0; i < cliente.cuentasbasociadas[numerocuenta].historialtransaciones.Count; i++)
                {
                    a++;
                    contenido += a + ".- " + cliente.cuentasbasociadas[numerocuenta].historialtransaciones[i].fecha.ToShortDateString() + " " + cliente.cuentasbasociadas[numerocuenta].historialtransaciones[i].fecha.ToShortTimeString() +
                        " --- 00" + cliente.cuentasbasociadas[numerocuenta].numerodecuenta + "  ----  $" + cliente.cuentasbasociadas[numerocuenta].historialtransaciones[i].monto + "  ---- "
                        + cliente.cuentasbasociadas[numerocuenta].historialtransaciones[i].tipodemovimiento + "<br/>";
                }
                contenido +=
                    "<br/>" +
                    "<br/>" +
                    "Tecnobanco Cristiano Innovador";

                Console.WriteLine("Cargando...");

                MailMessage correo = new MailMessage(sCorreoRemitente, cliente.correo, "Estado de cuenta de la tarjeta 000" + cliente.cuentasbasociadas[numerocuenta].numerodecuenta, contenido);
                correo.IsBodyHtml = true;
                SmtpClient clienteSmtp = new SmtpClient(sSmtpServer)
                {
                    Port = iPuertoSmtp,
                    Credentials = new NetworkCredential(sCorreoRemitente, sContrasena),
                    EnableSsl = true,
                };
                try
                {
                    clienteSmtp.Send(correo);
                    Console.WriteLine("Correo enviado con éxito!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Existió un error al enviar: " + ex.Message);

                }
            }
            catch (Exception ex) { Console.WriteLine("Algo sucedio intente de nuevo"); };
            
            

        }

    }
}