using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IRegistrationService
    {
        Boolean DoesUserExist(String firstName, String secondName, DateTime dob, Gender gender);
        void RegisterUser(String firstName, String secondName, DateTime dob, Gender gender);
    }
}
