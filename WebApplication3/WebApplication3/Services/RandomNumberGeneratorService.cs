using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public class RandomNumberGeneratorService : IRandomNumberGeneratorService
    {
        private readonly Random ranomNumberGeneratorEngine = new Random();
        public Int32 randomNumber
        {
            get
            {
                return ranomNumberGeneratorEngine.Next(101);
            }
        }
    }
}
