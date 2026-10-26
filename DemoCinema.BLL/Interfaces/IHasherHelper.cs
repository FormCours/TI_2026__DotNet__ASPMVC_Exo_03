using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCinema.BLL.Interfaces
{
    public interface IHasherHelper
    {
        string Hash(string value);
        bool Verify(string hash, string value);
    }
}
