using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuhovLab1
{
    enum Id
    {
        CONST,
        VAR,
        METHOD,
        CLASS
    }
    enum Type
    {
        int_type, sbyte_type, short_type, long_type, byte_type, ushort_type, uint_type, ulong_type,
        char_type, float_type, double_type, decimal_type, bool_type, object_type, string_type,class_type
    }
    class IDent
    {
        public string Name;
        public int hash;
        public Id id;
        public Type type;
        
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
            foreach (char s in type.ToString())
            {
                a += s;
            }
            hash = a * 100 + a;
        }
    }
    class Const : IDent
    {
        object Value;
        public Const(string name, string typeI,string val)
        {
            Name = name;
            type = (Type)Enum.Parse(typeof(Type), typeI+"_type"); ;
            if (val[0] == '\''|| val[0] == '\"')
            {
                val = val.Remove(val.Length - 1);
                val = val.Remove(0);
            }
            Value = val;
            id = Id.CONST;
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
            id = Id.CLASS;
            type = Type.class_type;
            CalcHash();
        }
        public override string ToString()
        {
            return Name + " | " + hash + " | " + "CLASSES" + " | " + "class_type";
        }
    }
    class Var : IDent
    {
        public Var(string name,string typeI)
        {
            Name = name;
            type = (Type)Enum.Parse(typeof(Type), typeI + "_type");
            CalcHash();
            id = Id.VAR;
        }
        public override string ToString()
        {
            return Name + " | " + hash + " | " + "VARS" + " | " + type + "_type";
        }
    }
    class Method : IDent
    {
        NList param;
        public Method(string name, string typeI,NList param)
        {
            Name = name;
            type = (Type)Enum.Parse(typeof(Type), typeI + "_type");
            this.param = param;
            CalcHash();
            id = Id.METHOD;
        }
        public Method(string name, string typeI)
        {
            Name = name;
            type = (Type)Enum.Parse(typeof(Type), typeI + "_type");
            CalcHash();
        }
        public override string ToString()
        {
            return Name + " | " + hash + " | " + "Method" + " | " + type + "_type" + " | " + param.ToString();
        }
    }
}