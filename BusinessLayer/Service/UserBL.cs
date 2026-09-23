using BusinessLayer.Interfaces;
using ModelLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        public IUserRL _userRL;
        public UserBL(IUserRL _userRL)
        {
            this._userRL = _userRL;
        }
        public RegistrationModel RegisterUserBL(RegistrationModel registrationModel)
        {
            return _userRL.RegisterUserRL(registrationModel);
        }
    }
}
