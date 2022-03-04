using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VRPApplicationCERG.Models;
using Xamarin.Essentials;

namespace VRPApplicationCERG.Data
{
    public class RestServiceVRPAuthentification : IRestAuthentification
    {
        // classe http client
        HttpClient client1;

        //liste VRP

        public RestServiceVRPAuthentification()
        {
            // Instanciation de la classe
            client1 = new HttpClient();
        }

        /// <summary>
        /// authentification ou connexion
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> LoginAsync(string email, string password)
        {
            var accessToken = string.Empty;

                var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")

                };

                var request = new HttpRequestMessage(HttpMethod.Post, Constants.Constants.RestUrlLoginUser);

                request.Content = new FormUrlEncodedContent(keyValues);

                var response = client1.SendAsync(request).Result;
                using (HttpContent content1 = response.Content)
                {
                    var json = content1.ReadAsStringAsync();
                    JObject jwtDynamick = JsonConvert.DeserializeObject<dynamic>(json.Result);
                    var accessTokenExpiration = jwtDynamick.Value<DateTime>(".expires");
                    accessToken = jwtDynamick.Value<string>("access_token");

                    var username = jwtDynamick.Value<string>("username");

                    try
                    {
                        await SecureStorage.SetAsync("accessTokenExpirationDate", accessTokenExpiration.ToString());
                    }
                    catch (Exception ex)
                    {
                        // Possible that device doesn't support secure storage on device.

                    }
                }


                return accessToken;

        }


        /// <summary>
        /// Inscription utilisateur
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="confirmpassword"></param>
        /// <param name="isNewItem"></param>
        /// <returns></returns>
        public async Task<bool> RegisterAsync(string email, string password, string confirmpassword)
        {
                         
             var model = new UTILISATEURVRPCERGI
             {
                 E_MAIL_USER_VRP = email,
                 MOTDEPASSE_USER_VRP = password,
                 CONFIRM_MOTDEPASSE_USER_VRP = confirmpassword
             };

             var json = JsonConvert.SerializeObject(model);

             HttpContent content = new StringContent(json);
             content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
             var response = await client1.PostAsync(Constants.Constants.RestUrlInscriptionUser, content);

             if (response.IsSuccessStatusCode)
             {
                 return true;
             }

            return false;
        }

    }
}
