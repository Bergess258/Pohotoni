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
            Value = val;
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
            type = "";
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
        }
        public Method(string name, string Type)
        {
            Name = name;
            type = Type;
            CalcHash();
        }
        public override string ToString()
        {
            return Name + " | " + hash + " | " + "CONSTS" + " | " + type + "_type" + " | " + param.ToString();
        }
    }
}