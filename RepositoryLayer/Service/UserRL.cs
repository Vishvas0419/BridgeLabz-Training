using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        public RegistrationModel RegisterUserRL(RegistrationModel registrationModel)
        {
            Console.WriteLine(registrationModel.userName);
            return registrationModel;
        }

    }
}
