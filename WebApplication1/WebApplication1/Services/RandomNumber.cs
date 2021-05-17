using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class RandomNumber: IRandomNumber
    {
        public int GetRandomNumber()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 10);
            return value;
        }
    }
}
