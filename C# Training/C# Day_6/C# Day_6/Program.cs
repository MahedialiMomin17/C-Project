using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Day_6
{
    internal class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter a number:");
                int num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Hashtable");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("");
                        Hashtable ht = new Hashtable();
                        ht.Add("ora", "oracle");
                        ht.Add("vb", "vb.net");
                        ht.Add("cs", "cs.net");
                        ht.Add("asp", "asp.net");

                        foreach (DictionaryEntry d in ht)
                        {
                            Console.WriteLine(d.Key + " " + d.Value);

                        }
                        Console.WriteLine("");
                        break;

                    case 2:
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("sortedlist");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("");
                        SortedList sl = new SortedList();
                        sl.Add("ora", "oracle");
                        sl.Add("vb", "vb.net");
                        sl.Add("cs", "cs.net");
                        sl.Add("asp", "asp.net");

                        foreach (DictionaryEntry d in sl)
                        {
                            Console.WriteLine(d.Key + " " + d.Value);
                        }

                        Console.WriteLine("");
                        break;

                    case 3:
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("list");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("");
                        List<int> lst = new List<int>();
                        lst.Add(100);
                        lst.Add(200);
                        lst.Add(300);
                        lst.Add(400);
                        foreach (int i in lst)
                        {
                            Console.WriteLine(i);
                        }

                        break;

                    case 4:
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("dictionary");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("");
                        Dictionary<int, string> dct = new Dictionary<int, string>();
                        dct.Add(1, "cs.net");
                        dct.Add(2, "vb.net");
                        dct.Add(3, "vb.net");
                        dct.Add(4, "vb.net");
                        foreach (KeyValuePair<int, string> kvp in dct)
                        {
                            Console.WriteLine(kvp.Key + " " + kvp.Value);
                        }

                        break;

                    case 5:
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("stack");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("");
                        Stack stk = new Stack();
                        stk.Push("cs.net");
                        stk.Push("vb.net");
                        stk.Push("asp.net");
                        stk.Push("sqlserver");

                        foreach (object o in stk)
                        {
                            Console.WriteLine(o);
                        }
                        Console.WriteLine("");

                        break;

                    case 6:
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("queue");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("");
                        Queue q = new Queue();
                        q.Enqueue("cs.net");
                        q.Enqueue("vb.net");
                        q.Enqueue("asp.net");
                        q.Enqueue("sqlserver");

                        foreach (object o in q)
                        {
                            Console.WriteLine(o);
                        }

                        Console.WriteLine("");

                        break;
                }
            }
        }
    }
}
