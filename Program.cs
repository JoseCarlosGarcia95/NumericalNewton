using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalNewton
{
    class Program
    {

        static double CalculatePi(double x)
        {
            return Math.Cos(x);
        }
        static void Main(string[] args)
        {
            NumericalNewton num = new NumericalNewton(CalculatePi, 1);
            Console.WriteLine(2*num.GetRootAroundStartPoint());

            Console.ReadLine();
        }
    }
}
