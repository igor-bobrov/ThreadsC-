using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_with_paraments
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 5,
                size = 20000;
            int[][] mas1 = CreateTeethMas(count, size),
                    mas2 = CreateTeethMas(count, size),
                    mas3 = CreateTeethMas(count, size);
            List<Thread> threads = new List<Thread>();
            for(int i = 0; i < count; i++)
            {
                threads.Add(new Thread(new ParameterizedThreadStart(oIndex => {
                    int index = (int)oIndex;
                    for ( int i = 0; i < mas3[index].Length - 1; i++)
                    {
                        for (int j = 0; j < mas3[index].Length - 1; j++)
                        {
                            int temp = mas3[index][j];
                            mas3[index][j] = mas3[index][j + 1];
                            mas3[index][j + 1] = temp;
                        }
                    }
                })));
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i <  count; i++)
            {
                Bubbles(mas1[i]);
            }
            sw.Stop();
            long liner = sw.ElapsedMilliseconds;

            sw.Restart();
            Parallel.For(0, count, i =>
            {
                Bubbles(mas2[i]);
            });
            sw.Stop();
            long parFor = sw.ElapsedMilliseconds;
            Console.WriteLine((double)liner / (double)parFor);
            sw.Restart();
            for (int i = 0; i < count; i++)
            {
                threads[i].Start(i);
            }
            for (int i = 0; i < count; i++)
            {
                threads[i].Join();
            }
            long thread = sw.ElapsedMilliseconds;
            Console.WriteLine((double)liner / (double)thread);
            Console.ReadKey();
        }
        static int[][] CreateTeethMas(int count, int size)
        {
            Random ran = new Random();
            int[][] mas = new int[count][];
            for (int i = 0; i < count; i++)
            {
                mas[i] = new int[size];
                for(int j = 0;  j < size; j++)
                {
                    mas[i][j] = ran.Next(0, 1001);
                }
            }
            return mas;
        }
        static void Bubbles(int[] mas)
        {
            for(int i = 0; i < mas.Length-1; i++)
            {
                for(int j = 0; j < mas.Length - 1; j++)
                {
                    if(mas[j] > mas[j + 1])
                    {
                        int temp = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = temp;
                    }
                }
            }
        }
    }
}
