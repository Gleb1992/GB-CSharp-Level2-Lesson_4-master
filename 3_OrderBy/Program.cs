using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFastDecisions;
using static System.Console;


namespace _3_OrderBy
{


    class Program
    {
        static void Main(string[] args)
        {
            var ex = new Extension();
            var q = new Questions();
            WriteLine("Задание 4.3");
            WriteLine("Грибков");
            WriteLine($"3* Дан фрагмент программы: {Environment.NewLine} а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.{ Environment.NewLine} b. * Развернуть обращение к OrderBy ");
            WriteLine("");

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                { "four",4 },
                { "two",2 },
                { "one",1 },
                { "three",3 },
            };

            dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; }).Select(pair => { Console.WriteLine("{0} - {1}", pair.Key, pair.Value); return pair; }).ToArray();

            WriteLine("a.");
            dict.OrderBy(x => x.Value).Select(pair => { Console.WriteLine("{0} - {1}", pair.Key, pair.Value); return pair; }).ToArray();
            WriteLine("b");
            dict.MyOrderBy(x => x.Value).Select(pair => { Console.WriteLine("{0} - {1}", pair.Key, pair.Value); return pair; }).ToArray();

            ex.Pause();
        }
    }

    static class Ext
    {
        /// <summary>
        /// Метод расширения для Dictionary<TSource, TKey> в виде OrderBy
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<TSource, TKey>> MyOrderBy<TSource, TKey>(this Dictionary<TSource, TKey> source, Func<KeyValuePair<TSource, TKey>, TKey> keySelector)
        {
            var array = source.Select(z => keySelector(z)).ToArray();
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    var element1 = (dynamic)array[j - 1];
                    var element2 = (dynamic)array[j];
                    if (element1.CompareTo(element2) > 0)
                    {
                        array[j - 1] = element2;
                        array[j] = element1;
                    }
                }
            if(source.ContainsValue(array[0]))
                foreach (var e in array)
                    yield return source.Where(x => x.Value == (dynamic)e).FirstOrDefault();
            else
                foreach (var e in array)
                    yield return source[(dynamic)e];
        }
    }

}
