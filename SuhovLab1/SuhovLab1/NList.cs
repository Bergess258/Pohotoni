using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuhovLab1
{
    class NList
    {
        string type;
        string param;
        NList next;
        public NList(string t,string p)
        {
            type = t;
            param = p;
        }
        public void Add(string t,string p)
        {
            NList temp = this;
            while (true)
            {
                if (temp.next == null) { temp.next = new NList(t, p); break; }
                temp = temp.next;
            }
        }
        public override string ToString()
        {
            string s = "";
            NList temp = this;
            while (true)
            {
                if (temp.next == null) break;
                s += temp.param + " | " + temp.type;
                temp = temp.next;
            }
            return s;
        }
    }
}
