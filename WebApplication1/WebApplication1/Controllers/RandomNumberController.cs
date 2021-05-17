using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class RandomNumberController : Controller
    {
        private readonly IRandomNumber randomNumberService;
        private readonly ICalculateNumber calculateNumberService;
        public RandomNumberController(ICalculateNumber calculateNumberService, IRandomNumber randomNumberService)
        {
            this.calculateNumberService = calculateNumberService;
            this.randomNumberService = randomNumberService;
        }
        public ActionResult CalculateUsingViewData()
        {
            var number1 = randomNumberService.GetRandomNumber();
            var number2 = randomNumberService.GetRandomNumber();
            var summ = calculateNumberService.Summ(number1, number2);
            var subtraction = calculateNumberService.Subtraction(number1, number2);
            var multiplication = calculateNumberService.Multiplication(number1, number2);
            var division = calculateNumberService.Division(number1, number2);

            this.ViewData["Number1"] = number1;
            this.ViewData["Number2"] = number2;
            this.ViewData["Summ"] = summ;
            this.ViewData["Subtraction"] = subtraction;
            this.ViewData["Multiplication"] = multiplication;
            this.ViewData["Division"] = division;

            return this.View();
        }

        public ActionResult CalculateUsingViewBag()
        {
            var number1 = randomNumberService.GetRandomNumber();
            var number2 = randomNumberService.GetRandomNumber();
            var summ = calculateNumberService.Summ(number1, number2);
            var subtraction = calculateNumberService.Subtraction(number1, number2);
            var multiplication = calculateNumberService.Multiplication(number1, number2);
            var division = calculateNumberService.Division(number1, number2);

            this.ViewBag.Number1 = number1;
            this.ViewBag.Number2 = number2;
            this.ViewBag.Summ = summ;
            this.ViewBag.Subtraction = subtraction;
            this.ViewBag.Multiplication = multiplication;
            this.ViewBag.Division = division;

            return this.View();
        }
        public ActionResult CalculateUsingModel()
        {
            var model = new NumbersViewModel();
            var number1 = randomNumberService.GetRandomNumber();
            var number2 = randomNumberService.GetRandomNumber();
            model.number1 = number1;
            model.number2 = number2;
            model.Summ = calculateNumberService.Summ(number1, number2);
            model.Subtraction = calculateNumberService.Subtraction(number1, number2);
            model.Multiplication = calculateNumberService.Multiplication(number1, number2);
            model.Division = calculateNumberService.Division(number1, number2);

            return this.View(model);
        }
        public ActionResult AccessServiceDirectly()
        {
            return View();
        }

    }

}
