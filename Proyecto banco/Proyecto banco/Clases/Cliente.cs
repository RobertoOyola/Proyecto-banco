using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_banco
{
    [Serializable]
    public class Cliente:Persona
    {
        public int numerocliente;
        public string contrasena;
        public string correo;

        public List<CuentaBancaria> cuentasbasociadas = new List<CuentaBancaria>();

        public Cliente()
        {
            cuentasbasociadas = new List<CuentaBancaria>();
        }
        public Cliente(string nombre, string apellido, string numerodeidentificacion , int numerocliente, string contrasena, string correo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.numerodeidentificacion = numerodeidentificacion;
            this.numerocliente = numerocliente;
            this.contrasena = contrasena;
            this.correo = correo;
            cuentasbasociadas = new List<CuentaBancaria>();
        }

        
    }
}
