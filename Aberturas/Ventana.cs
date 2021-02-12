using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aberturas
{
    public class Ventana:Abertura
    {
        public bool doblevidrio { get; set; }
        public string TieneDobleVidrio()
        {
            if (doblevidrio==true)
            {
                return "si";
            }
            return "no";
        }


        public override string ToString()
        {
            return $"Ancho:{Ancho},Alto :{Alto},Superfice:{SuperFicie()},Tiene Doble Vidrio: {TieneDobleVidrio()}";
        }
    }
}
