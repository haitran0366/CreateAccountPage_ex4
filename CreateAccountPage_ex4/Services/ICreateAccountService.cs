using CreateAccountPage_ex4.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountPage_ex4.Services
{
    interface ICreateAccountService
    {
        Task<bool> CreateAccount(UserModel user);
    }
}
