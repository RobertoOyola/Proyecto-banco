using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_banco
{
    [Serializable]
    public class Transacciones
    {
        public int id;
        public DateTime fecha;
        public string tipodemovimiento;
        public decimal monto;

        public Transacciones() { }

        public Transacciones(DateTime fecha, string tipodemovimiento, decimal monto)
        {
            this.fecha = fecha;
            this.tipodemovimiento = tipodemovimiento;
            this.monto = monto;
        }

        
    }
}
