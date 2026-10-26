using DemoCinema.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCinema.BLL.Interfaces
{
    public interface IAuthService
    {
        MemberModel Login(string email, string password);
    }
}
