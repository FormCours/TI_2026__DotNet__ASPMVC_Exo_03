using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCinema.BLL.BusinessExceptions
{
    public class AuthException : Exception
    {
        public AuthException() { }
        public AuthException(string? message) : base(message) { }
    }

    public class AuthBadCredentialException : AuthException
    {
        public AuthBadCredentialException() : base("Bad credential") { }
    }
}
