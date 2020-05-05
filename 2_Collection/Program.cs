using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFastDecisions;
using static System.Console;

namespace _2_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            var ex = new Extension();
            var q = new Questions();
            WriteLine("Задание 4.2");
            WriteLine("Грибков");
            WriteLine($"2.Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции: {Environment.NewLine} a  для целых чисел;{Environment.NewLine} b *для обобщенной коллекции;{Environment.NewLine} c**используя Linq.");
            WriteLine("");
            var r = new Random();
            //a
            var a = new MyClass<int>();
            for(int i = 0; i < 50; i++)            
                a.db.Add(r.Next(0, 3));

            WriteLine("a-b.");
            a.PrintA();
            WriteLine("c.");
            a.PrintB();
            WriteLine("");
            var b = new MyClass<string>();
            for (int i = 0; i < 500; i++)
                b.db.Add(new string(new char[] { (char)r.Next(40, 61) }));
            WriteLine("a-b.");
            b.PrintA();
            WriteLine("c.");
            b.PrintB();

            ex.Pause();

        }
    }

    class MyClass<T>
    {
        public List<T> db = new List<T>();

        public void PrintA()
        {
            var d = new Dictionary<T, int>();
            foreach (var e in db)
                if (d.ContainsKey((dynamic)e))
                    d[(dynamic)e]++;
                else
                    d.Add((dynamic)e, 0);

            foreach (var e in d)
                WriteLine($"Значение \"{Convert.ToString(e.Key)}\" встречается {e.Value} раз");
        }

        public void PrintB() => db.GroupBy(x => x).Select(s => { WriteLine($"Значение \"{Convert.ToString(s.Key)}\" встречается {s.Count()-1} раз"); return s; }).ToList();
        
    }

}
