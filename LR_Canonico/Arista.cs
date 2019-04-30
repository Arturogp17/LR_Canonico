using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_Canonico
{
    class Arista
    {
        public string name;
        public Nodo destino;

        public Arista()
        {
            name = "";
        }
        public Arista(Nodo d, string n)
        {
            destino = d;
            name = n;
        }

        public Arista(string n)
        {
            name = n;
        }
    }
}
