using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_Canonico
{
    public partial class Form1 : Form
    {
        readonly List<string> gramatica = new List<string>();
        readonly List<string> lines = new List<string>();
        readonly List<Nodo> g = new List<Nodo>();
        readonly List<Nodo> conjuntos = new List<Nodo>();
        readonly List<string> X = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ArchivoToolStripMenuItem_DropDownItemClicked(sender, e);
        }

        private void ArchivoToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string line;
            string directorio = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\Gramaticas"));
            List<string> lineas = new List<string>();
            switch (e.ClickedItem.AccessibleName)
            {
                case "open":
                    openFileDialog1.InitialDirectory = directorio;
                    openFileDialog1.FileName = "";
                    openFileDialog1.Filter = "(*.txt)|*.txt";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        gram.Clear();
                        gramatica.Clear();
                        tablaCanonica.Rows.Clear();
                        tablaCanonica.Columns.Clear();
                        treeConjuntos.BeginUpdate();
                        treeConjuntos.Nodes.Clear();
                        treeConjuntos.EndUpdate();
                        StreamReader sr = new StreamReader(openFileDialog1.FileName);
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            lineas.Add(line);
                            gramatica.Add(line);
                            line = sr.ReadLine();
                        }
                        gram.Lines = lineas.ToArray();
                    }
                    break;

                case "save":
                    saveFileDialog1.InitialDirectory = directorio;
                    saveFileDialog1.FileName = "";
                    saveFileDialog1.Filter = "(*.txt)|*.txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                        foreach (string s in gram.Lines)
                        {
                            sw.WriteLine(s);
                        }
                        sw.Close();
                    }
                    break;
            }
        }

        private void GramaticaExpandida()
        {
            bool existe = true;
            Nodo nodo = new Nodo();
            List<string> exp = new List<string>();
            gramatica.Clear();
            foreach (string s in gram.Lines)
                gramatica.Add(s);
            for (int i = 0; i < gramatica.Count(); i++)
            {
                List<string> cad = new List<string>();
                cad = gramatica[i].Split('-').ToList();
                cad[1] = cad[1].Substring(1);
                nodo = BuscaNodo(cad[0]);
                if (nodo == null)
                {
                    existe = false;
                    nodo = new Nodo(cad[0]);
                }
                string element = "";
                List<string> elements = new List<string>();
                foreach (char c in cad[1])
                {
                    if (char.IsLower(c))
                    {
                        element += c;
                    }
                    else
                    {
                        if (element.Length > 0)
                            elements.Add(element);
                        elements.Add(c.ToString());
                        element = "";
                    }
                }
                if (element != "")
                    elements.Add(element);
                nodo.producciones.Add(elements);

                if (g.Count == 0)
                {
                    Nodo n = new Nodo(cad[0] + "'");
                    List<string> l = new List<string>
                    {
                        cad[0]
                    };
                    n.producciones.Add(l);
                    g.Add(n);
                    lines.Add(cad[0] + "'->" + cad[0]);
                }
                lines.Add(gramatica[i]);
                if (!existe)
                {
                    existe = true;
                    g.Add(nodo);
                }
            }
            expandida.Lines = lines.ToArray();
        }

        private void CalculaPrimero()
        {
            foreach (Nodo n in g)
            {
                foreach (List<string> ls in n.producciones)
                {
                    if (!char.IsUpper(ls[0][0]))
                    {
                        n.primero.Add(ls[0]);
                    }
                }
            }

            bool cambio = true;
            Nodo nAux;
            while (cambio)
            {
                cambio = false;
                foreach (Nodo n in g)
                {
                    foreach (List<string> ls in n.producciones)
                    {
                        if (char.IsUpper(ls[0][0]) && ls[0] != n.name)
                        {
                            nAux = BuscaNodo(ls[0]);
                            if (CambioGenerado(n.primero, nAux.primero))
                            {
                                cambio = true;
                                n.primero = n.primero.Union(nAux.primero).ToList();
                            }
                        }
                    }
                }
            }

            treePrimero.BeginUpdate();
            for (int i = 0; i < g.Count; i++)
            {
                treePrimero.Nodes.Add("PRI(" + g[i].name + ")");
                foreach (string s in g[i].primero)
                {
                    treePrimero.Nodes[i].Nodes.Add(s);
                }
            }
            treePrimero.ExpandAll();
            treePrimero.EndUpdate();
        }

        private void CalculaSiguiente()
        {
            Nodo nAux = new Nodo();
            bool cambio = true;
            g[0].siguiente.Add("$");
            while (cambio)
            {
                cambio = false;
                foreach (Nodo n in g)
                {
                    foreach (List<string> p in n.producciones)
                    {
                        if (char.IsUpper(p.Last()[0]))
                        {
                            nAux = BuscaNodo(p.Last());
                            if (CambioGenerado(nAux.siguiente, n.siguiente))
                            {
                                nAux.siguiente = nAux.siguiente.Union(n.siguiente).ToList();
                                cambio = true;
                            }
                        }
                    }
                    foreach (Nodo nc in g)
                    {
                        foreach (List<string> ls in nc.producciones)
                        {
                            for (int i = 0; i < ls.Count; i++)
                            {
                                if (ls[i].Equals(n.name))
                                {
                                    if (i + 1 < ls.Count)
                                    {
                                        if (char.IsUpper(ls[i + 1][0]))
                                        {
                                            nAux = BuscaNodo(ls[i + 1]);
                                            if (CambioGenerado(n.siguiente, nAux.primero))
                                            {
                                                n.siguiente = n.siguiente.Union(nAux.primero).ToList();
                                                cambio = true;
                                            }
                                        }
                                        else
                                        {
                                            if (!n.siguiente.Contains(ls[i + 1]))
                                            {
                                                n.siguiente.Add(ls[i + 1]);
                                                cambio = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            treeSiguiente.BeginUpdate();
            for (int i = 0; i < g.Count; i++)
            {
                treeSiguiente.Nodes.Add("SIG(" + g[i].name + ")");
                foreach (string s in g[i].siguiente)
                {
                    treeSiguiente.Nodes[i].Nodes.Add(s);
                }
            }
            treeSiguiente.ExpandAll();
            treeSiguiente.EndUpdate();
        }

        private Nodo BuscaNodo(string cad)
        {
            foreach (Nodo n in g)
            {
                if (cad == n.name)
                    return n;
            }
            return null;
        }

        private bool CambioGenerado(List<string> d, List<string> p)
        {
            if (p.Count == 0)
                return false;
            else
            {
                foreach (string s in p)
                {
                    if (!d.Contains(s))
                        return true;
                }
            }
            return false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GramaticaExpandida();
            CalculaPrimero();
            CalculaSiguiente();
            GeneraP();
            GeneraConjuntos();
            GeneraTabla();
        }

        private void GeneraP()
        {
            string aux = "";
            foreach(Nodo n in g)
            {
                foreach(List<string> p in n.producciones)
                {
                    aux = "";
                    foreach(string s in p)
                    {
                        aux += s;
                    }
                    n.LRp.Add(aux);
                }
            }
        }
        
        private void GeneraConjuntos()
        {
            Nodo nAux = new Nodo();
            Nodo nodo = new Nodo("I0");
            nodo.LRproduccciones.Add(g[0].name + "->•" + g[0].LRp[0]);
            nodo.LRterminales.Add("$");
            string componentes = "", cad = "";
            Cerradura(nodo, 0);
            conjuntos.Add(nodo);
            ObtenerX();
            for (int k = 0; k < conjuntos.Count; k++)
            {
                foreach (string x in X)
                {
                    Nodo conjuntoAux = new Nodo("I" + conjuntos.Count().ToString());
                    for (int i = 0; i < conjuntos[k].LRproduccciones.Count; i++)
                    {
                        componentes = SeparaPunto(conjuntos[k].LRproduccciones[i]);
                        if(componentes.Count() > 0 && ComparaCadenas(componentes, x))
                        {
                            cad = RecorrePunto(conjuntos[k].LRproduccciones[i]);
                            componentes = SeparaPunto(cad);
                            conjuntoAux.LRproduccciones.Add(cad);
                            conjuntoAux.LRterminales.Add(conjuntos[k].LRterminales[i]);
                            if(componentes.Length > 0 && char.IsUpper(componentes[0]))
                            {
                                Cerradura(conjuntoAux, conjuntoAux.LRproduccciones.Count - 1);
                            }
                        }
                    }
                    if (conjuntoAux.LRproduccciones.Count > 0)
                    {
                        nAux = VerificaRepetido(conjuntoAux);
                        if (nAux != null)
                        {
                            Arista a = new Arista(nAux, x);
                            conjuntoAux.aristas.Add(a);
                        }
                        else
                            conjuntos.Add(conjuntoAux);
                    }
                }
            }
            DibujarConuntos();
        }

        private bool ComparaCadenas(string a, string x)
        {
            bool band = false;
            string cad = "";
            foreach (char c in a)
            {
                if (char.IsUpper(c))
                {
                    if (!band)
                        cad = c.ToString();
                    break;
                }
                else
                {
                    cad += c;
                    band = true;
                }
            }

            return cad == x;
        }

        private Nodo VerificaRepetido(Nodo n)
        {
            int cont = 0;
            foreach(Nodo c in conjuntos)
            {
                if(c.LRproduccciones.Count == n.LRproduccciones.Count)
                {
                    for (int i = 0; i < n.LRproduccciones.Count; i++)
                    {
                        for (int j = 0; j < c.LRproduccciones.Count; j++)
                        {
                            if(n.LRproduccciones[i] == c.LRproduccciones[j])
                                cont++;
                        }
                    }
                    if (cont == n.LRproduccciones.Count)
                    {
                        for (int i = 0; i < n.LRproduccciones.Count; i++)
                        {
                            for (int j = 0; j < c.LRproduccciones.Count; j++)
                            {
                                if (n.LRproduccciones[i] == c.LRproduccciones[j])
                                {
                                    List<string> t = new List<string>();
                                    t = n.LRterminales[i].Split('/').ToList();
                                    foreach(string s in t)
                                    {
                                        if (!c.LRterminales[j].Contains(s))
                                            c.LRterminales[j] += "/" + s;
                                    }
                                }
                            }
                        }
                        return c;
                    }
                    else
                        cont = 0;
                }
            }
            return null;

        }

        private string RecorrePunto(string oracion)
        {
            string res = "";
            List<string> r = new List<string>();

            r = oracion.Split('•').ToList();
            if(char.IsLower(r[1][0]))
            {
                string cad = "";
                while(r[1].Length > 0 && char.IsLower(r[1][0]))
                {
                    cad += r[1][0];
                    r[1] = r[1].Substring(1);
                    
                }
                res = r[0] + cad + "•" + r[1];
            }
            else
                res += r[0] + r[1][0] + "•" + r[1].Substring(1);

            return res;
        }

        private void DibujarConuntos()
        {
            treeConjuntos.BeginUpdate();
            for (int i = 0; i < conjuntos.Count; i++)
            {
                treeConjuntos.Nodes.Add(conjuntos[i].name);
                for (int j = 0; j < conjuntos[i].LRproduccciones.Count; j++)
                {
                    treeConjuntos.Nodes[i].Nodes.Add(conjuntos[i].LRproduccciones[j] + "  ,  " + conjuntos[i].LRterminales[j]);
                }
            }
            treeConjuntos.ExpandAll();
            treeConjuntos.EndUpdate();
        }

        private void ObtenerX()
        {
            foreach (Nodo nodo in g)
            {
                foreach (List<string> ls in nodo.producciones)
                {
                    foreach (string s in ls)
                    {
                        if (!X.Contains(s))
                            X.Add(s);
                    }
                }
            }
        }

        private void Cerradura(Nodo edo, int pos)
        {
            string componentes = "", terminales = "";
            Nodo nodoAux = new Nodo();

            for (int i = pos; i < edo.LRproduccciones.Count; i++)
            {
                componentes = SeparaPunto(edo.LRproduccciones[i]);
                nodoAux = BuscaNodo(componentes[0].ToString());
                if (nodoAux != null)
                {
                    if (componentes.Length > 1)
                    {
                        if (char.IsUpper(componentes[1]))
                            terminales = ObtenerPrimeros(componentes[1].ToString());
                        else
                            terminales = componentes[1].ToString();
                    }
                    else
                    {
                        terminales = edo.LRterminales[i];
                    }
                    foreach (string s in nodoAux.LRp)
                    {
                        if (edo.LRproduccciones.Contains(nodoAux.name + "->•" + s))
                        {
                            int x;
                            x = ObtenerPosicion(edo.LRproduccciones, nodoAux.name + "->•" + s);

                            if (!edo.LRterminales[x].Contains(terminales))
                                edo.LRterminales[x] += "/" + terminales;
                        }
                        else
                        {
                            edo.LRproduccciones.Add(nodoAux.name + "->•" + s);
                            edo.LRterminales.Add(terminales);
                        }
                    }
                }
            }
        }

        private int ObtenerPosicion(List<string> l, string b)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] == b)
                    return i;
            }
            return -1;
        }

        private string SeparaPunto(string cad)
        {
            string aux = "";
            bool b = false;
            foreach(char c in cad)
            {
                if (b)
                    aux += c;
                if(c == '•')
                    b = true;
            }
            return aux;
        }

        private string ObtenerPrimeros(string n)
        {
            string res = "";
            Nodo nodo = new Nodo();
            nodo = BuscaNodo(n);
            foreach (string s in nodo.primero)
                res += s + "/";
            res = res.Remove(res.Length - 1);
            return res;
        }

        private void GeneraTabla()
        {
            X.Sort(delegate (string x, string y)
            {
                if (char.IsUpper(x[0]) && !char.IsUpper(y[0])) return 1;
                else if (char.IsUpper(y[0]) && !char.IsUpper(x[0])) return -1;
                else return 0;
            });
            
            tablaCanonica.Columns.Add("Estados", "Estados");

            foreach (string x in X)
            {
                tablaCanonica.Columns.Add(x, x);
            }
            foreach(Nodo edo in conjuntos)
            {
                tablaCanonica.Rows.Add(edo.name);
            }
        }
    }
}
