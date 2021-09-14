using System;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using System.IO;

namespace lab1beta
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] results = new string[2000];
            for (int i = 1; i < 2000; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                ThirdFunc(GenerateFunc(i));
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                decimal res = (decimal)ts.TotalMilliseconds;
                Console.WriteLine(res);
                results[i] = $"{i} : {res}";
            }

            File.WriteAllLines(@"../../../TextFile1.csv", results);
        }

        static int FirstFunc(int n)
        {
            return 1;
        }

        static int[] GenerateFunc(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Random rnd = new Random();
                arr[i] = rnd.Next();
            }
            return arr;
        }

        static int SecondFunc(int[] arr)
        {
            int result = 0;
            for(var i = 0; i < arr.Length; i++)
            {
                result += arr[i];
            }
            return result;
        }

        static int ThirdFunc(int[] arr)
        {
            int result = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                result *= arr[i];
            }
            return result;
        }
    }
}
