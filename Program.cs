using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public delegate bool Reduce函数<T>(T a, T b);
        public static T Reduce<T>(Reduce函数<T> func, T[] arr)
        {
            T value = arr[0];
            for (int i = 1; i < arr.Length; i++ )
            {
                if (!func(value, arr[i]))
                    value = arr[i];
            }
            return value;
        }
        static bool max(int a, int b) { return a > b; }
        static bool longest(string a, string b) { return a.Length > b.Length; }
        static void Main(string[] args)
        {
            var func1 = new Reduce函数<int>(max);
            var func2 = new Reduce函数<string>(longest);
            Console.WriteLine(Reduce<int>(func1, new int[]{ 1, 2, 3, 5, 100 })); //Output: 100
            Console.WriteLine(Reduce<string>(func2, new string[]{"你好，世界", "Hello, world", "Bonjour, la monde"})); //Output: Bonjour, la monde
            Console.ReadKey();
        }
    }
}
