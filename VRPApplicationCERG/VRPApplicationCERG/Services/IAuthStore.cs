using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VRPApplicationCERG.Services
{
    interface IAuthStore
    {
        Task<bool> AddUserAsync(string item, string itemsecond, string itemthird);
        Task<string> CheckUserExistAsync(string item, string itemsecond);
    }
}
