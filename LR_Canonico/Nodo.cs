using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_Canonico
{
    class Nodo
    {
        public List<List<string>> producciones = new List<List<string>>();
        public List<string> primero = new List<string>();
        public List<string> siguiente = new List<string>();
        public List<string> LRp = new List<string>();
        public List<string> LRproduccciones = new List<string>();
        public List<string> LRterminales = new List<string>();
        public List<Arista> aristas = new List<Arista>();


        public string name;
        public Nodo(string n) { name = n; }
        public Nodo() { }
    }
}
