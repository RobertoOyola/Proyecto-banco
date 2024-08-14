using Proyecto_banco;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_banco
{
    internal class Program
    {
        private static void PrintPage( PrintPageEventArgs e,Cliente cliente,int numerocuenta)
        {
            // Aquí puedes dibujar lo que quieras imprimir en el objeto Graphics

            Graphics g = e.Graphics;
            float x = 0;
            int xint = Convert.ToInt32(x);
            float y = 0;
            int yint = Convert.ToInt32(y);
            string imagenpath = "C:\\Users\\SirLancelotR pc\\Downloads\\Proyecto nuevo (1).png";
            Image image = Image.FromFile(imagenpath);
            Font font = new Font("Arial", 15, FontStyle.Bold);
            Font font2 = new Font("Times New Roman", 13, FontStyle.Bold);
            Font font3 = new Font("Times New Roman", 11, FontStyle.Bold);

            e.Graphics.DrawImage(image, x, y, 340, 212);
            g.DrawString(cliente.numerodeidentificacion.Substring(0,4) +" "+ cliente.numerodeidentificacion.Substring(4, 4)+" "+ cliente.numerodeidentificacion.Substring(8, 2) + "00 " + cliente.numerocliente + "00" + cliente.cuentasbasociadas[numerocuenta].numerodecuenta, font, Brushes.White, xint + 26, yint + 146);
            g.DrawString(cliente.nombre+" "+cliente.apellido, font3, Brushes.White, xint+26 , yint + 168);
            g.DrawString("Valida hasta  "+"  09/24", font3, Brushes.White, xint + 26, yint + 185);

        }

        private static void PrintEstado(PrintPageEventArgs e, Cliente cliente, int numerocuenta)
        {
            Graphics g = e.Graphics;
            float x = 0;
            int xint = 35;
            float y = 0;
            int yint = 220;
            string banner = "C:\\Users\\SirLancelotR pc\\Downloads\\PikPng.com_lineas-png_3248788.png";
            string logo = "C:\\Users\\SirLancelotR pc\\Downloads\\Sin-titulo-9.png";
            Image image = Image.FromFile(banner);
            Image logo1 = Image.FromFile(logo);
            Font titulo = new Font("Times New Roman", 30, FontStyle.Bold);
            Font subtitulo = new Font("Times New Roman", 25, FontStyle.Bold);
            Font letra = new Font("Times New Roman", 20, FontStyle.Regular);
            Font letra2 = new Font("Times New Roman", 20, FontStyle.Bold);

            Font letraestado = new Font("Times New Roman", 15, FontStyle.Bold);
            Font letraestado2 = new Font("Times New Roman", 15, FontStyle.Regular);

            e.Graphics.DrawImage(image, x, y, 900, 250);
            g.DrawImage(logo1, 20, 10, 130, 130);
            g.DrawString("TecnoBanco", titulo, Brushes.White, 151, 10);
            g.DrawString("Cristiano", titulo, Brushes.White, 151, 45);
            g.DrawString("Innovador", titulo, Brushes.White, 155, 80);
            g.DrawString("Estado de cuenta", titulo, Brushes.Black, xint + 220, yint - 50);
            g.DrawString("Informacion Personal", subtitulo, Brushes.Red, xint, yint);
            g.DrawString("- Nombre:          ", letra2, Brushes.Black, xint + 10, yint + 35);
            g.DrawString("- Identificacion:  ", letra2, Brushes.Black, xint + 10, yint + 65);
            g.DrawString("- Cuenta:          ", letra2, Brushes.Black, xint + 10, yint + 95);
            g.DrawString("- Tipo de cuenta:  ", letra2, Brushes.Black, xint + 10, yint + 125);
            g.DrawString(cliente.nombre+" "+cliente.apellido, letra, Brushes.Black, xint + 225, yint + 35);
            g.DrawString(cliente.numerodeidentificacion, letra, Brushes.Black, xint + 225, yint + 65);
            g.DrawString("000" + cliente.cuentasbasociadas[numerocuenta].numerodecuenta, letra, Brushes.Black, xint + 225, yint + 95);
            g.DrawString(cliente.cuentasbasociadas[numerocuenta].tipodecuenta, letra, Brushes.Black, xint + 225, yint + 125);

            g.DrawString("=============================================", letra, Brushes.Blue, xint + 10, yint + 180);
            int yestado = yint + 185;
            for (int i = 1; i < cliente.cuentasbasociadas[numerocuenta].historialtransaciones.Count + 1; i++)
            {
                g.DrawString("- Movimiento:   ", letraestado, Brushes.Black, xint + 10, yestado + 20);
                g.DrawString(cliente.cuentasbasociadas[numerocuenta].historialtransaciones[i-1].tipodemovimiento, letraestado2, Brushes.Black, xint + 160, yestado + 20);
                g.DrawString("- Fecha y Hora: ", letraestado, Brushes.Black, xint + 10, yestado + 40);
                g.DrawString(cliente.cuentasbasociadas[numerocuenta].historialtransaciones[i - 1].fecha.ToString(), letraestado2, Brushes.Black, xint + 160, yestado + 40);
                g.DrawString("- Monto:        $", letraestado, Brushes.Black, xint + 10, yestado + 60);
                g.DrawString(cliente.cuentasbasociadas[numerocuenta].historialtransaciones[i - 1].monto.ToString(), letraestado2, Brushes.Black, xint + 160, yestado + 60);

                yestado = yestado + 70;
            }

        }

        static void Main(string[] args)
        {
            Banco SistemaBancarioGeneral = new Banco();
            string sCodigoBanco = "1234";
            SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);

            if (SistemaBancarioGeneral == null)
            {
                sCodigoBanco = "1234";
                string nombrebanco = "Tecnobanco Cristiano Innovador";
                string direccionbanco = "Av. Juan Tanca Marengo km 3.5";
                string telefonobanco = "0992940360";
                Banco objBanco = new Banco(nombrebanco, direccionbanco, telefonobanco);
                objBanco.sIdentificacion = sCodigoBanco;
                ManipulacionArchivos.CrearArchivoBanco(objBanco);
            }
            else
            {

                string opcion = " ";

                while (opcion != "3")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("████████████████████████████████████████████████");
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("█");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("█");

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("░░░░░░░");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Tecnobanco Cristiano Innovador");

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("░░░░░░░░░");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("█");
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("█");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("█");
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("█");

                    Console.WriteLine("████████████████████████████████████████████████");
                    Console.WriteLine();
                    Console.WriteLine("                       ██      ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                     ██████        ");
                    Console.WriteLine("                       ██       ");
                    Console.WriteLine("                       ██       ");
                    Console.WriteLine("                       ██       ");
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("                 Ingrese una opción:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($" 1");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($" --------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" Crear cliente");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($" 2");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($" --------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" Ingresar usuario");
                    Console.WriteLine("");
                    Console.Write($" 3");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($" --------");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" Salir");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                    opcion = Console.ReadLine();
                    Console.Clear();
                    
                    switch (opcion)
                    {
                        case "1":
                            
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("████████████████████████████████████████████████");
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Tecnobanco Cristiano Innovador");

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");

                            Console.WriteLine("████████████████████████████████████████████████");
                            Console.WriteLine();
                            Console.WriteLine("                       ██      ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("                     ██████        ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine();
                            SistemaBancarioGeneral.crearcliente();
                            SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                            Console.Clear();

                            break;

                        case "2":
                            string opcion2 = " ";
                            string contrasena =" ";
                            
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("████████████████████████████████████████████████");
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Tecnobanco Cristiano Innovador");

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");

                            Console.WriteLine("████████████████████████████████████████████████");
                            Console.WriteLine();
                            Console.WriteLine("                       ██      ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("                     ██████        ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;



                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" ════════════════════════════════════════════════════════");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(" Por favor, ingrese su Cedula ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string cedula = Console.ReadLine();
                            int numerousuario = 0;
                            for (int i = 0; i < SistemaBancarioGeneral.listaclientes.Count; i++)
                            {
                                if (cedula == SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion)
                                {
                                    numerousuario = i;
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                                    Console.WriteLine(" Ingrese contrasena");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    contrasena = Console.ReadLine();
                                    if (contrasena == SistemaBancarioGeneral.listaclientes[i].contrasena)
                                    {
                                        Console.Clear();

                                        while (opcion2 != "11")
                                        {
                                            
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("████████████████████████████████████████████████");
                                            Console.Write("█");
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("█");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("█");
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("█");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("█");
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.Write("░░░░░░░");
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("Tecnobanco Cristiano Innovador");
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.Write("░░░░░░░░░");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("█");
                                            Console.Write("█");
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("█");
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write("█");
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("█");
                                            Console.WriteLine("████████████████████████████████████████████████");
                                            Console.WriteLine();
                                            Console.WriteLine("                       ██      ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("                     ██████        ");
                                            Console.WriteLine("                       ██       ");
                                            Console.WriteLine("                       ██       ");
                                            Console.WriteLine("                       ██       ");
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" ════════════════════════════════════════════════════════");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" -");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" Usuario:");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" -");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" Numero de cuenta:");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" -");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" Codigo de cliente: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" ════════════════════════════════════════════════════════");

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine("    Ingrese una de las siguientes opciones: ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" ════════════════════════════════════════════════════════");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 1");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Abrir Cuenta Bancaria                 ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 2");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Depositar                             ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 3");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Retirar                               ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 4");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Transferir                            ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 5");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Obtener Saldo                         ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 6");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Mostrar Transacciones                 ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 7");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Enviar Estado de cuenta al correo     ");

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 8");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");

                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Imprimir Tarjeta de Debito            ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($" 9");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Imprimir Estado de Cuenta             ");

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($"10");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" Cerrar Cuenta Bancaria                ");
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.Write($"11");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($" --------");
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine(" Salir                                 ");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine(" ═════════════════════════════════════════════════════════");


                                            opcion2 = Console.ReadLine();
                                            Console.Clear();
                                            Console.WriteLine();
                                            switch (opcion2)
                                            {
                                                case "1":
                                                    //Console.Clear();
                                                   
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    SistemaBancarioGeneral.abrircuenta(cedula, SistemaBancarioGeneral.listaclientes[i]);
                                                    SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                    Console.Clear();
                                                    break;

                                                case "2":
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    SistemaBancarioGeneral.depositar(cedula);
                                                    SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                    Console.Clear();
                                                    break;

                                                case "3":

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    SistemaBancarioGeneral.retirar(cedula);
                                                    SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                    Console.Clear();
                                                    break;

                                                case "4":

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    SistemaBancarioGeneral.transferir(cedula);
                                                    SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                    Console.Clear();
                                                    break;

                                                case "5":

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    SistemaBancarioGeneral.imprimircuentasdecliente(cedula);
                                                    Console.Clear();
                                                    break;

                                                case "6":

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    SistemaBancarioGeneral.imprimirtrasnacciones(cedula);
                                                    Console.Clear();
                                                    break;

                                                case "7":

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    EnvioCorreo correo = new EnvioCorreo();
                                                    
                                                    //Console.WriteLine("Cargando...");
                                                    correo.enviarCorreoEstadodeceunta(SistemaBancarioGeneral.listaclientes[i]);
                                                    //Console.WriteLine("Correo Enviado");

                                                    Console.ReadLine();
                                                    Console.Clear() ;
                                                    break;

                                                case "8":

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    int numerocuenta = 0;
                                                        
                                                    for (int j = 0; j < SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas.Count; j++)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Blue;
                                                        Console.Write("Numero de cuenta: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                                                        Console.ForegroundColor = ConsoleColor.Blue;
                                                        Console.Write("Saldo:            ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas[j].saldo);
                                                        Console.ForegroundColor = ConsoleColor.Blue;
                                                        Console.Write("Tipo de cuenta:   ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                                                        Console.WriteLine();

                                                    }
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("Ingrese el numero de cuenta de la cuenta a Imprimir la tarjeta");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    numerocuenta = Convert.ToInt32(Console.ReadLine());
                                                        numerocuenta = numerocuenta - 1;

                                                    if (SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas[numerocuenta].sino == "no")
                                                    {
                                                        PrintDocument pd = new PrintDocument();
                                                        pd.PrintPage += new PrintPageEventHandler((sender, e) => PrintPage(e, SistemaBancarioGeneral.listaclientes[i], numerocuenta));
                                                        //pd.PrinterSettings.PrinterName = "EPSON L355 Series";
                                                        pd.PrinterSettings.PrinterName = "EPSON087EF0 (L355 Series)";
                                                        Banco obj = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                        obj.listaclientes[i].cuentasbasociadas[numerocuenta].sino = "si";
                                                        ManipulacionArchivos.CrearArchivoBanco(obj);
                                                        SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);

                                                        // Puedes configurar la impresora aquí si es necesario
                                                        // pd.PrinterSettings.PrinterName = "Nombre de la impresora";

                                                        pd.Print();
                                                        Console.Clear();
                                                    }
                                                    else
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine("Usted ya dispone de una tarjeta bancaria de esta cuenta");
                                                        Console.ReadLine();
                                                        Console.Clear() ;
                                                        
                                                    }
                                                    
                                                    break;

                                                case "9":

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");

                                                    int numerocuenta2 = 0;

                                                    for (int j = 0; j < SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas.Count; j++)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Blue;
                                                        Console.Write("Numero de cuenta: ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas[j].numerodecuenta);
                                                        Console.ForegroundColor = ConsoleColor.Blue;
                                                        Console.Write("Saldo:            ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas[j].saldo);
                                                        Console.ForegroundColor = ConsoleColor.Blue;
                                                        Console.Write("Tipo de cuenta:   ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.WriteLine(SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas[j].tipodecuenta);
                                                        Console.WriteLine();

                                                    }
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("Ingrese el numero de cuenta de la cuenta a Imprimir el estado de cuenta");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    numerocuenta2 = Convert.ToInt32(Console.ReadLine());
                                                    numerocuenta2 = numerocuenta2 - 1;

                                                    if (SistemaBancarioGeneral.listaclientes[i].cuentasbasociadas[numerocuenta2].sino != null)
                                                    {
                                                        PrintDocument pd = new PrintDocument();
                                                        pd.PrintPage += new PrintPageEventHandler((sender, e) => PrintEstado(e, SistemaBancarioGeneral.listaclientes[i], numerocuenta2));
                                                        //pd.PrinterSettings.PrinterName = "EPSON L355 Series";
                                                        pd.PrinterSettings.PrinterName = "EPSON087EF0 (L355 Series)";
                                                        Banco obj = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                        obj.listaclientes[i].cuentasbasociadas[numerocuenta2].sino = "si";
                                                        ManipulacionArchivos.CrearArchivoBanco(obj);
                                                        SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);

                                                        pd.Print();
                                                        Console.Clear();
                                                    }
                                                    break;

                                                case "10":

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Usuario:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].nombre} {SistemaBancarioGeneral.listaclientes[i].apellido}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Numero de cuenta:");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($"{SistemaBancarioGeneral.listaclientes[i].numerodeidentificacion}");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write($" -");
                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                    Console.Write($" Codigo de cliente: ");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine($" 0000{SistemaBancarioGeneral.listaclientes[i].numerocliente}");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");


                                                    SistemaBancarioGeneral.cerrarcuenta(cedula);
                                                    SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                    Console.Clear();
                                                    break;

                                                case "11":
                                                    opcion = "3";
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.Write("Tecnobanco Cristiano Innovador");

                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.Write("█");
                                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("█");

                                                    Console.WriteLine("████████████████████████████████████████████████");
                                                    Console.WriteLine();
                                                    Console.WriteLine("                       ██      ");
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("                     ██████        ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine("                       ██       ");
                                                    Console.WriteLine();

                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.WriteLine(" ════════════════════════════════════════════════════════");

                                                    Console.WriteLine();
                                                    Console.WriteLine("Fue un placer atenderle en el Tecnobanco Cristiano Innovador  ");
                                                    break;

                                                default:
                                                    Console.WriteLine();
                                                    Console.WriteLine("El " + opcion + " no es un opcion valida");

                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    break;

                                            }
                                        }
                                    }
                                        
                                }
                                
                             }
                            if (opcion2 == "10")
                            {

                            }
                            else
                            {
                                if (cedula == SistemaBancarioGeneral.listaclientes[numerousuario].numerodeidentificacion)
                                {
                                    if (opcion2 == "10")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine(" Contrasena Incorrecta");
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Usuario no encontra vuelva a intentar");
                                    Console.ReadLine();
                                    Console.Clear();

                                }
                            }
                            
                            
                            break;

                        case "3":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("████████████████████████████████████████████████");
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Tecnobanco Cristiano Innovador");

                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("█");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("█");

                            Console.WriteLine("████████████████████████████████████████████████");
                            Console.WriteLine();
                            Console.WriteLine("                       ██      ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("                     ██████        ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine("                       ██       ");
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" ════════════════════════════════════════════════════════");

                            Console.WriteLine();
                            Console.WriteLine("Fue un placer atenderle en el Tecnobanco Cristiano Innovador  ");
                            //Console.ReadLine();
                            break;

                        case "142536":
                            string opcion3 = " ";
                            
                            try
                            {
                                    
                                 while (opcion3 != "4")
                                 {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("████████████████████████████████████████████████");
                                    Console.Write("█");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("█");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("█");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("█");

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("█");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("░░░░░░░");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Tecnobanco Cristiano Innovador");

                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("░░░░░░░░░");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("█");
                                    Console.Write("█");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("░░░░░░░");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("       B a n c a r i o        ");

                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("░░░░░░░░░");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("█");

                                    Console.Write("█");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("█");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("█");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("█");

                                    Console.WriteLine("████████████████████████████████████████████████");
                                    Console.WriteLine();
                                    Console.WriteLine("                       ██      ");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("                     ██████        ");
                                    Console.WriteLine("                       ██       ");
                                    Console.WriteLine("                       ██       ");
                                    Console.WriteLine("                       ██       ");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Ingrese una de las siguientes opciones");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                    Console.WriteLine();
                                    Console.Write($" 1");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write($" --------");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(" Agregar Cliente");
                                    Console.Write($" 2");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write($" --------");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(" Eliminar Cliente");
                                    Console.Write($" 3");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write($" --------");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(" Buscar Cliente por cedula");
                                    Console.Write($" 4");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write($" --------");
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" Salir");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(" ════════════════════════════════════════════════════════");
                                    Console.WriteLine();
                                    opcion3 = Console.ReadLine();
                                    Console.ReadLine();
                                    Console.WriteLine();
                                    switch (opcion3)
                                    {
                                        case "1":
                                                 SistemaBancarioGeneral.crearcliente();
                                                 SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                 Console.Clear();
                                                 break;

                                        case "2":
                                                 SistemaBancarioGeneral.eliminarcliente();
                                                 SistemaBancarioGeneral = ManipulacionArchivos.GetArchivoBanco(sCodigoBanco);
                                                 break;

                                        case "3": 
                                                SistemaBancarioGeneral.buscarcliente();
                                                break;

                                        case "4":
                                                opcion = "3";

                                            Console.WriteLine("Fue un placer atenderle en el Tecnobanco Cristiano Innovador  ");
                                            break;

                                        default:
                                        Console.WriteLine();
                                        Console.WriteLine("El " + opcion + " no es un opcion valida");
                                        Console.ReadLine() ;
                                        break;
                                    }
                                 }
                                
                            }
                            catch (Exception ex) { Console.WriteLine("Algo sucedio intente de nuevo");
                                Console.ReadLine();
                            };


                            break;

                        default:
                            Console.WriteLine() ;
                            Console.WriteLine("El " + opcion + " no es un opcion valida");
                            Console.ReadLine ();
                            break;


                    }
                }

               
            }

            Console.ReadLine();

        }
    }
}
