using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Services;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class Quiz : Controller
    {
        private readonly IRandomNumberGeneratorService rand;
        private readonly ICalculatorService calc;

        private readonly Char[] OperatorDictionary = new Char[] { '+', '-', '*', '/' };

        public Quiz(IRandomNumberGeneratorService randomNumberGenerator, ICalculatorService calculator)
        {
            this.rand = randomNumberGenerator;
            this.calc = calculator;
        }

        public IActionResult Index()
        {
            var model = new QuizViewModel();
            MakeQuestion(model);
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(QuizAction action, Int32 answer, QuizViewModel model)
        {
            ViewData["PreviousUserInput"] = answer;
            if (action != QuizAction.Finish)
            {
                if(action != QuizAction.Next)
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);

                ValidateUserInput(answer, model);
            } 
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Int32 listLength = model.expressions.Count;
            if (listLength > 0)
            {
                model.expressions[listLength - 1].Result = answer;
                //ModelState.Remove($"expressions[{listLength - 1}].Result");
                if (model.expressions[listLength - 1].Expected == answer)
                {
                    model.GuessedCorrect += 1;
                    //ModelState.Remove("GuessedCorrect");
                }
                ModelState.Clear();
            }

            if(action == QuizAction.Finish)
            {
                return this.View("Result", model);
            }

            ViewData["PreviousUserInput"] = "";
            MakeQuestion(model);

            return this.View(model);
        }

        private void ValidateUserInput(Int32? input, QuizViewModel model)
        {
            if (input == null)
                ModelState.AddModelError("", "Input should not be empty");

            if (model.GuessedCorrect >= model.expressions.Count)
                ModelState.AddModelError("", "That's cheating");
        }   

        private void MakeQuestion(QuizViewModel model) 
        {
            Int32 Left = rand.randomNumber, Right = rand.randomNumber;
            Char Operator = OperatorDictionary[(rand.randomNumber % 4)];

            if (Operator == '/' && Right == 0)
                Operator = '+';

            model.expressions.Add(new Expression(Left, Right, Operator,
                calc.Calculate(Left, Right, Operator)));
        }

    }
}
