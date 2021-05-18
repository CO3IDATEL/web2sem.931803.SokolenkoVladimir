using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public interface ICalculatorService
    {
        Int32 Calculate(Int32 Left, Int32 Right, Char Operator);
    }
}
