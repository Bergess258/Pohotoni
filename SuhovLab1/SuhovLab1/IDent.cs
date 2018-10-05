using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuhovLab1
{
    class IDent
    {
        public string Name;
        public int hash;
        public string id;
        public string type;
        
        public int Hash
        {
            get { return hash; }
        }
        virtual public void CalcHash()
        {
            int a = 0;
            foreach(char s in Name)
            {
                a += s;
            }
            foreach (char s in type)
            {
                a += s;
            }
            hash = a * 100 + a;
        }
    }
    class Const : IDent
    {
        string Value;
        public Const(string name, string Type,string val)
        {
            Name = name;
            type = Type;
            if (val[0] == '\''|| val[0] == '\"')
            {
                val = val.Remove(val.Length - 1);
                val = val.Remove(0);
            }
            Value = val;
            id = "CONST";
            CalcHash();
        }
        public override void CalcHash()
        {
            base.CalcHash();
            string val = Value.ToString();
            foreach(char s in val)
            hash += s;
        }
        public override string ToString()
        {
            return Name+ " | " + hash+ " | " + "CONSTS"+ " | " + type+"_type" + " | " + Value;
        }
    }
    class Class : IDent
    {
        public Class(string name)
        {
            Name = name;
            id = "CLASSES";
            type = "class";
            CalcHash();
        }
        public override string ToString()
        {
            return Name + " | " + hash + " | " + "CLASSES" + " | " + "class_type";
        }
    }
    class Var : IDent
    {
        public Var(string name,string Type)
        {
            Name = name;
            type = Type;
            CalcHash();
            id = "VAR";
        }
        public override string ToString()
        {
            return Name + " | " + hash + " | " + "VARS" + " | " + type + "_type";
        }
    }
    class Method : IDent
    {
        NList param;
        public Method(string name, string Type,NList param)
        {
            Name = name;
            type = Type;
            this.param = param;
            CalcHash();
            id = "METHOD";
        }
        public Method(string name, string Type)
        {
            Name = name;
            type = Type;
            CalcHash();
            id = "METHOD";
        }
        public override string ToString()
        {
            return Name + " | " + hash + " | " + "Method" + " | " + type + "_type" + " | " + param.ToString();
        }
    }
}