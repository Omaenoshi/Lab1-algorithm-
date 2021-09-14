using System;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using System.IO;

namespace lab1beta
{
    class Program
    {
        static int[] vector = new int[2000];

        delegate double CurrentFunc(int i);

        static void Main(string[] args)
        {
            CreateVector();

            Start(FourthFunc);
         
        }

        static void Start(CurrentFunc currentFunc)
        {
            string[] results = new string[2000];
        
            for (int i = 0; i < 2000; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                currentFunc(i);
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;
                decimal res = (decimal)ts.TotalMilliseconds;
                Console.WriteLine(res);
                results[i] = $"{i}.{res}";
            }

            File.WriteAllLines(@"../../../TextFile1.csv", results);
        }

        static void CreateVector()
        {
            Random rnd = new Random();
            for (var i = 0; i < 2000; i++)
                vector[i] = rnd.Next();
        }

        static double FirstFunc(int n)
        {
            return 1;
        }

        static double SecondFunc(int i)
        {
            int result = 0;
            for(var j = 0; j < i; j++)
            {
                result += vector[j];
            }
            return result;
        }

        static double ThirdFunc(int i)
        {
            int result = 0;
            for (var j = 0; j < i; j++)
            {
                result *= vector[j];
            }
            return result;
        }

        static double FourthFunc(int i)
        {
            double x = 1.5;
            var result = 0.0;
            for (var j = 0; j < i; j++)
            {
                result += vector[i] * Math.Pow(x, i);
            }
            return result;
        }

        static double BubbleSort(int i)
        {
            for (var j = 0; j < i - 1; j++)
            {
                if (vector[j] < vector[j+1])
                {
                    int num = vector[j];
                    vector[j] = vector[j + 1];
                    vector[j + 1] = num;
                }
            }

            return 0;
        }
    }
}
