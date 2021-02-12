using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aberturas
{
    public class Puerta:Abertura
    {
        public int cantidadBisagras { get; set; }
        public override string ToString()
        {
            return $"Ancho:{Ancho},Alto :{Alto},Superfice:{SuperFicie()}";
        }
    }
}
