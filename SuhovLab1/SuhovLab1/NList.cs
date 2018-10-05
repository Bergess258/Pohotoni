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
        string method;
        NList next;
        public NList(string t,string p)
        {
            type = p;
            method = t;
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
                if (temp == null) break;
                s += temp.method + " " + temp.type+ " |";
                temp = temp.next;
            }
            s = s.Remove(s.Length - 1);
            return s;
        }
    }
}
