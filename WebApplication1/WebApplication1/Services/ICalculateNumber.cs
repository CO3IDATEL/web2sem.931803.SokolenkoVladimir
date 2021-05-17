using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface ICalculateNumber
    {
        int Summ(int x, int y);
        int Subtraction(int x, int y);
        int Multiplication(int x, int y);
        int Division(int x, int y);
    }
}
