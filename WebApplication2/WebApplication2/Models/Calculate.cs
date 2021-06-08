using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public static class Calculate
    {
        public static string Solution(string First, string Second, string Operand)
        {
            switch (Operand)
            {
                case "+":
                    return "" + (Convert.ToDouble(First) + Convert.ToDouble(Second));
                case "-":
                    return "" + (Convert.ToDouble(First) - Convert.ToDouble(Second));
                case "*":
                    return "" + (Convert.ToDouble(First) * Convert.ToDouble(Second));
                case "/":
                    return "" + (Convert.ToDouble(First) / Convert.ToDouble(Second));
                default:
                    return "unkown operand";
            }
        }
    }
}
