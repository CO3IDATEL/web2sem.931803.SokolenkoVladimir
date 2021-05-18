using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Expression
    {
        public Int32 Left       { get; set; }
        public Int32 Right      { get; set; }
        public Char Operator    { get; set; }
        public Int32 Result    { get; set; }
        public Int32 Expected   { get; set; }
        public Expression(Int32 Left, Int32 Right, Char Operator, Int32 Expected)
        {
            this.Left = Left; this.Right = Right; this.Operator = Operator; this.Expected = Expected;
            this.Result = 0; 
        }

        public Expression()
        {
            Left = Right = Result = Expected = 0;
            Operator = '+';
        }
    }
}
