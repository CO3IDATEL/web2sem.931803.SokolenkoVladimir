using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public class CalculatorService : ICalculatorService
    {
        public Int32 Calculate(Int32 Left, Int32 Right, Char Operator)
        {
            switch (Operator) 
            {
                case '+':
                    return Left + Right;
                case '-':
                    return Left - Right;
                case '*':
                    return Left * Right;
                case '/':
                    if (Right == 0) throw new ArgumentException();
                    else return Left / Right;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
