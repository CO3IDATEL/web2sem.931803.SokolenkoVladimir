using WebApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebApplication4.Services
{
    public class RegistrationService : IRegistrationService
    {
        private ILogger<IRegistrationService> logger;
        private readonly List<User> users = new List<User>();

        public RegistrationService(ILogger<IRegistrationService> logger)
        {
            this.logger = logger;
        }

        public bool DoesUserExist(string firstName, string secondName, DateTime dob, Gender gender)
        {
            Boolean found = false;
            lock (this.users)
            {
                found = users.Any(x => x.firstName == firstName && x.secondName == secondName && x.dob.Month == dob.Month && x.dob.Day == dob.Day && x.dob.Year == dob.Year && x.gender == gender);
            }
            String msg = found ? "Found" : "Couldn\'t find";
            logger.LogInformation("{0} a user whose name is {1} {2} with Date of Birth: {3} and Gender: {4}",
                                     msg, firstName, secondName, dob, gender);
            return found;
        }

        public void RegisterUser(string firstName, string secondName, DateTime dob, Gender gender)
        {
            lock (this.users)
            {
                users.Add(new User(firstName, secondName, dob, gender));
            }
            logger.LogInformation("Registered {0} {1} with Date of Birth: {2} and Gender {3}",
                                    firstName, secondName, dob, gender);
        }

        private class User
        {
            public String firstName     { get; set; }
            public String secondName    { get; set; }
            public DateTime dob         { get; set; }
            public Gender gender        { get; set; }

            public User(String firstName, String secondName, DateTime dob, Gender gender)
            {
                this.firstName = firstName; this.secondName = secondName;
                this.dob = dob; this.gender = gender;
            }

        }
    }
}
