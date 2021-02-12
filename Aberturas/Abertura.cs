using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aberturas
{
    public class Abertura
    {
        public int Alto { get; set; }
        public int Ancho { get; set; }

        public static void CantidadAberturas()
        {

        }

        public int SuperFicie()
        {
            return Ancho*Alto;
        }


        public virtual string ToString() {
            return $"";
        }



    }
}
