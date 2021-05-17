using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class CalculateNumber: ICalculateNumber
    {
        public int Summ(int x, int y)
        {
            return x + y;
        }
        public int Subtraction(int x, int y)
        {
            return x - y;
        }
        public int Multiplication(int x, int y)
        {
            return x * y;
        }
        public int Division(int x, int y)
        {
            if (y == 0)
                return 0;
            else
                return x / y;
        }
    }
}
