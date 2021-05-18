using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class QuizViewModel
    {
        public List<Expression> expressions { get; set; } = new List<Expression>();

        public Int32 GuessedCorrect { get; set; }
    }
}
