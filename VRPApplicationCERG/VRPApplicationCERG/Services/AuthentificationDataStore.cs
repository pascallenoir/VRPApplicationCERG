using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;

namespace VRPApplicationCERG.Services
{
    public class AuthentificationDataStore : IAuthStore
    {

        IRestAuthentification restService;

        //Constructeur
        public AuthentificationDataStore(IRestAuthentification service)
        {

            restService = service;

        }

        /// <summary>
        /// fonction inscription AuthentificationDataStore
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemsecond"></param>
        /// <param name="itemthird"></param>
        /// <returns></returns>
        public Task<bool> AddUserAsync(string item, string itemsecond, string itemthird)
        {
            return restService.RegisterAsync(item, itemsecond, itemthird);
        }

        /// <summary>
        /// fonction login AuthentificationDataStore
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemsecond"></param>
        /// <returns></returns>
        public Task<string> CheckUserExistAsync(string item, string itemsecond)
        {
            return restService.LoginAsync(item, itemsecond);
        }
    }
}
