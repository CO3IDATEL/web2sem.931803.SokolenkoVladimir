using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public interface IRandomNumberGeneratorService
    {
        Int32 randomNumber { get; }
    }
}
