using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace delegate_example
{
    class Program
    {
        delegate void WriteMessage(); 
        delegate double Oper(double a, double b);
        static void Main(string[] args)
        {
            WriteMessage mes = Hello;
            mes();
            WriteOperRes(10, 10, (double a, double b) =>
            {
                return a * b;
            });
            WriteOperRes(10, 10, (double a, double b) =>
            {
                return a / b;
            });
            WriteStatisticsRes(new double[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, Avg);
            Console.ReadKey();
        }
        static void Hello() => Console.WriteLine("1: Hello");
        static void WriteOperRes(double a, double b, Oper oper) => Console.WriteLine("2: " + oper.Invoke(a, b));
        static void WriteStatisticsRes(double[] mas, Func<double[], double> math) => Console.WriteLine("3: " + math.Invoke(mas));
        static double Avg(double[] mas)
        {
            double sum = 0;
            foreach(double el in mas)
            {
                sum += el;
            }
            return sum / mas.Length;
        }
    }
}