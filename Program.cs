/*
 * Author: PECman
 * Date: 2018/3/17
 * Introduction:
 * Three functions in the code of functional programming(FP): Reduce, Map & Fold.They are all in C#.Enjoy my code!
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public delegate bool Reduce函数<T>(T a, T b);
        public delegate T Map函数<T>(T a);
        public delegate T Fold函数<T>(T a, T b);
        public static T Reduce<T>(Reduce函数<T> func, T[] arr)
        {
            T val = arr[0];
            for (int i = 1; i < arr.Length; i++ )
            {
                if (!func(val, arr[i]))
                    val = arr[i];
            }
            return val;
        }
        public static T[] Map<T>(Map函数<T> func, T[] arr)
        {
            List<T> list = new List<T>();
            foreach (T item in arr)
            {
                list.Add(func(item));
            }
            return list.ToArray();
        }
        public static T Fold<T>(Fold函数<T> func, T[] arr)
        {
            T val = arr[0];
            foreach (T item in arr)
            {
                val = func(val, item);
            }
            return val;
        }
        static bool max(int a, int b) { return a > b; }
        static bool longest(string a, string b) { return a.Length > b.Length; }
        static int plus1(int a) { return a + 10; }
        static int plus2(int a, int b) { return a + b; }
        static void Main(string[] args)
        {
            var func1 = new Reduce函数<int>(max);
            var func2 = new Reduce函数<string>(longest);
            var func3 = new Map函数<int>(plus1);
            var func4 = new Fold函数<int>(plus2);
            Console.WriteLine(Reduce<int>(func1, new int[]{ 1, 2, 3, 5, 100 })); //Output: 100
            Console.WriteLine(Reduce<string>(func2, new string[]{"你好，世界", "Hello, world", "Bonjour, la monde"})); //Output: Bonjour, la monde
            var arr = Map<int>(func3, new int[] { 1, 2, 3, 4});
            foreach (int item in arr)
            {
                Console.Write(string.Format("{0} ", item));
            }
            Console.WriteLine();
            Console.WriteLine(Fold<int>(func4, new int[]{1, 2, 3, 4, 5, 6, 7}));

            Console.ReadKey();
        }
    }
}
