using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IRegistrationService registration;
        
        public SignUpController(IRegistrationService registration)
        {
            this.registration = registration;
        }

        public IActionResult Index()
        {
            var model = new SignUpViewModel();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SignUpViewModel model)
        {
            DateTime dob = new DateTime();
            try
            {
                dob = new DateTime(model.Year ?? -1, model.Month + 1 ?? -1, model.Day ?? -1);
            } catch(ArgumentOutOfRangeException){
                ModelState.AddModelError("DateOfBirth", "Incorrect date");
            }

            if(!ModelState.IsValid)
            {
                return this.View(model);
            }

            model.DateOfBirth = dob;
            if (registration.DoesUserExist(model.FirstName, model.SecondName, model.DateOfBirth, model.Gender))
            {
                return this.View("SignUpExists", new SignUpFoundViewModel
                {
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    WasFound = true
                }); 
            } else {
                return this.View("SignUpConfirm", new SignUpConfirmViewModel()
                {
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    WasFound = false
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUpExists(SignUpFoundViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.View("SignUpConfirm", new SignUpConfirmViewModel()
            {
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                WasFound = false
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUpConfirm(SignUpConfirmViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return this.View(model);
            }

            registration.RegisterUser(model.FirstName, model.SecondName, model.DateOfBirth, model.Gender);
            return this.View("SignUpResult", model);
        }

    }
}
