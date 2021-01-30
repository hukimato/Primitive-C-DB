using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    class TestCollections<TKey, TValue>
    {
        private List<TKey> list_key = new List<TKey>();
        private List<string> list_string = new List<string>();
        private Dictionary<TKey, TValue> dict_key = new Dictionary<TKey, TValue>();
        private Dictionary<string, TValue> dict_string = new Dictionary<string, TValue>();
        private GenerateElement<TKey, TValue> generate;

        public TestCollections(long count, GenerateElement<TKey, TValue>j)
        {
            if (count <= 0) { throw new ArgumentException("Количство элементов указано неверно."); }

            generate = j;
            for (int i =0; i < count; i++)
            {
                var element = generate(i);
                dict_key.Add(element.Key, element.Value);
                dict_string.Add(element.Key.ToString(), element.Value);
                list_key.Add(element.Key);
                list_string.Add(element.Key.ToString());
            }
        }

        public void searchInTKeyList()
        {
            var first = list_key[0];
            var center = list_key[list_key.Count / 2];
            var last = list_key[list_key.Count -1];
            var another = generate(list_key.Count * 2).Key;
            var timer = new System.Diagnostics.Stopwatch();
            Console.WriteLine("________Поиск в TKey List__________");
            timer.Start();
            list_key.Contains(first);
            timer.Stop();
            Console.WriteLine("Первый элемент:" + timer.ElapsedMilliseconds);

            timer.Restart();
            list_key.Contains(center);
            timer.Stop();
            Console.WriteLine("Центральный элемент:" + timer.ElapsedMilliseconds);

            timer.Restart();
            list_key.Contains(last);
            timer.Stop();
            Console.WriteLine("Последний элемент:" + timer.ElapsedMilliseconds);

            timer.Restart();
            list_key.Contains(another);
            timer.Stop();
            Console.WriteLine("Несущетсвующий элемент:" + timer.ElapsedMilliseconds);
        }

        public void searchInStrList()
        {
            var first = list_string[0];
            var center = list_string[list_key.Count / 2];
            var last = list_string[list_key.Count - 1];
            var another = generate(list_string.Count * 2).Key.ToString();
            var timer = new System.Diagnostics.Stopwatch();
            Console.WriteLine("________Поиск в String List__________");
            timer.Start();
            list_string.Contains(first);
            timer.Stop();
            Console.WriteLine("Первый элемент:" + timer.ElapsedMilliseconds);

            timer.Restart();
            list_string.Contains(center);
            timer.Stop();
            Console.WriteLine("Центральный элемент:" + timer.ElapsedMilliseconds);

            timer.Restart();
            list_string.Contains(last);
            timer.Stop();
            Console.WriteLine("Последний элемент:" + timer.ElapsedMilliseconds);

            timer.Restart();
            list_string.Contains(another);
            timer.Stop();
            Console.WriteLine("Несущетсвующий элемент:" + timer.ElapsedMilliseconds);
        }

        public void searchInKeyDict()
        {
            var first = dict_key.ElementAt(0).Key;
            var center = dict_key.ElementAt(dict_key.Count /2).Key;
            var last = dict_key.ElementAt(dict_key.Count - 1).Key;
            var another = generate(dict_key.Count * 2).Key;
            var timer = new System.Diagnostics.Stopwatch();
            Console.WriteLine("________Поиск в Dictionary по Key__________");

            timer.Start();
            dict_key.ContainsKey(first);
            timer.Stop();
            Console.WriteLine("Первый элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_key.ContainsKey(center);
            timer.Stop();
            Console.WriteLine("Центральный элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_key.ContainsKey(last);
            timer.Stop();
            Console.WriteLine("Последний элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_key.ContainsKey(another);
            timer.Stop();
            Console.WriteLine("Несущетсвующий элемент:" + timer.ElapsedMilliseconds);
        }

        public void searchInStrDict()
        {
            var first = dict_string.ElementAt(0).Key;
            var center = dict_string.ElementAt(dict_key.Count / 2).Key;
            var last = dict_string.ElementAt(dict_key.Count - 1).Key;
            var another = generate(dict_string.Count * 2).Key.ToString();
            var timer = new System.Diagnostics.Stopwatch();
            Console.WriteLine("________Поиск в Dictionary по Str__________");

            timer.Start();
            dict_string.ContainsKey(first);
            timer.Stop();
            Console.WriteLine("Первый элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_string.ContainsKey(center);
            timer.Stop();
            Console.WriteLine("Центральный элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_string.ContainsKey(last);
            timer.Stop();
            Console.WriteLine("Последний элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_string.ContainsKey(another);
            timer.Stop();
            Console.WriteLine("Несущетсвующий элемент:" + timer.ElapsedMilliseconds);
        }

        public void searchInKeyDictByValue()
        {
            var first = dict_key.ElementAt(0).Value;
            var center = dict_key.ElementAt(dict_key.Count / 2).Value;
            var last = dict_key.ElementAt(dict_key.Count - 1).Value;
            var another = generate(dict_key.Count * 2).Value;
            var timer = new System.Diagnostics.Stopwatch();
            Console.WriteLine("________Поиск в Dictionary по Key__________");

            timer.Start();
            dict_key.ContainsValue(first);
            timer.Stop();
            Console.WriteLine("Первый элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_key.ContainsValue(center);
            timer.Stop();
            Console.WriteLine("Центральный элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_key.ContainsValue(last);
            timer.Stop();
            Console.WriteLine("Последний элемент:" + timer.ElapsedMilliseconds);

            timer.Start();
            dict_key.ContainsValue(another);
            timer.Stop();
            Console.WriteLine("Несущетсвующий элемент:" + timer.ElapsedMilliseconds);
        }
    }
}
