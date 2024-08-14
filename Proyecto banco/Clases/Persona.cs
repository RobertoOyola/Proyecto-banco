using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_banco
{
    [Serializable]
    public class Persona
    {
        
            public string nombre;
            public string apellido;
            public string numerodeidentificacion;

            public Persona() { }

            public Persona(string nombre, string apellido, string numerodeidentificacion)
            {
                this.nombre = nombre;
                this.apellido = apellido;
                this.numerodeidentificacion = numerodeidentificacion;
            }
        
    }
}
