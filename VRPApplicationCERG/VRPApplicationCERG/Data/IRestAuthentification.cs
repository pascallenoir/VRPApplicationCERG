using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VRPApplicationCERG.Data
{
    public interface IRestAuthentification
    {
        Task<bool> RegisterAsync(string email, string password, string confirmpassword);
        Task<string> LoginAsync(string email, string password);
    }
}
