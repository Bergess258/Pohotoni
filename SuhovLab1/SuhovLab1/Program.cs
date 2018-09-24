using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SuhovLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree=new Tree();
            StreamReader Reader = new StreamReader("input.txt");
            string varReg = @"(int||sbyte||short||long||byte||ushort||uint||ulong||char||float||double||decimal||bool||object||string)";
            Regex vars = new Regex(varReg+@"(\[\]||\[\,\])(\s)\D\w*(\;)");
            Regex type = new Regex(varReg);
            Regex var = new Regex(@"\D\w*\s*\=\s*\d+\;");
            Regex Class = new Regex(@"class\s\D\w*\;");
            Regex method = new Regex(@"(int||sbyte||short||long||byte||ushort||uint||ulong||char||float||double||decimal||bool||object||string||void)\s\D\w*\(((\s*((ref||out)\s)*"+varReg+ @"\s\D\w*\,)*(\s((ref||out)\s)*" + varReg + @"\s\D\w*))?\)\;");
            while (true)
            {
                string line = line = Reader.ReadLine();
                string[] masLine;
                try
                {
                    masLine = line.Split(' ');
                }
                catch
                {
                    break;
                }
                
                masLine[masLine.Length - 1].Remove(masLine[masLine.Length - 1].Length - 1);
                if (vars.IsMatch(line))
                {
                    tree.Add(new Var(masLine[1], masLine[0]));
                }
                else
                {
                    if (masLine[0] == "const")
                    {
                        if (type.IsMatch(masLine[1]))
                        {
                            string s = "";
                            for (int i = 2; i < masLine.Length; i++)
                                s += masLine[i];

                            if (var.IsMatch(s))
                            {
                                tree.Add(new Const(masLine[2], masLine[1], masLine[masLine.Length - 1]));
                            }

                        }
                    }
                    else
                        if (Class.IsMatch(line))
                    {
                        tree.Add(new Class(masLine[1]));
                    }
                    else
                    {
                        if (method.IsMatch(line))
                        {
                            string methodType = masLine[0];
                            string name = line.Split(' ', '(')[1];
                            string[] paraMs = line.Split('(', ',', ')');
                            string[] temp = new string[paraMs.Length - 2];
                            NList paramsMet;
                            for (int i = 1; i < paraMs.Length - 1; i++)
                                temp[i - 1] = paraMs[i];
                            if (temp[0] != "")
                            {
                                string[] s = temp[0].Split(' ');
                                if(s.Length==3)
                                paramsMet = new NList(s[0], s[1]);
                                else
                                    paramsMet = new NList("var", s[1]);
                                for (int i = 1; i < temp.Length; i++)
                                {
                                    string[] s1 = temp[i].Split(' ');
                                    if (s.Length == 3)
                                        paramsMet.Add(s1[0], s1[1]);
                                    else
                                        paramsMet.Add("var", s1[1]);
                                }
                                tree.Add(new Method(name, methodType, paramsMet));
                            }
                            else
                                tree.Add(new Method(name, methodType));
                        }
                        else
                        {
                            Console.WriteLine("PolniyPizdec");
                        }
                    }
                }
            }
            Reader.Close();
        }
    }
}
