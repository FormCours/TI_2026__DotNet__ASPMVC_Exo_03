using DemoCinema.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCinema.BLL.Interfaces
{
    public interface IAuthService
    {
        bool CheckAlreadyExists(string email);
        MemberModel Login(string email, string password);
        void Register(string email, string username, string password);
    }
}
