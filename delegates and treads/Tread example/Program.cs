using System;
using System.Threading;

namespace Tread_example
{
    class Program
    {
        static void WriteSecond()
        {
            while (true)
            {
                Console.WriteLine("\t\tВторой поток");
            }
        }
        static void WriteThird()
        {
            while (true)
            {
                Console.WriteLine("\t\t\t\tТретий поток");
            }
        }
        static void Main(string[] args)
        {
            Thread second = new Thread(WriteSecond);
            Thread third = new Thread(WriteThird);
            second.Start();
            third.Start();
            while (true)
            {
                Console.WriteLine("Первый поток");
            }
        }
    }
}
