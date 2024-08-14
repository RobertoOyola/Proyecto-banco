using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_banco
{
    [Serializable]
    public class CuentaBancaria
    {
        public int numerodecuenta;
        public string tipodecuenta;
        public decimal saldo = 0;
        public string propietario;
        public string sino="n";
        public List<Transacciones> historialtransaciones = new List<Transacciones>();

        public CuentaBancaria()
        {
            historialtransaciones = new List<Transacciones>();
        }
        public CuentaBancaria(int numerodecuenta, string tipodecuenta, decimal saldo, string propietario, string sino)
        {
            this.numerodecuenta = numerodecuenta;
            this.tipodecuenta = tipodecuenta;
            this.saldo = saldo;
            this.propietario = propietario;
            this.sino = sino;
            historialtransaciones = new List<Transacciones>();
        }

    }
}
