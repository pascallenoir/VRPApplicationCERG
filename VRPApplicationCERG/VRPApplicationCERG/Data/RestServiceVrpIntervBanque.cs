using Acr.UserDialogs;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Models;
using Xamarin.Essentials;

namespace VRPApplicationCERG.Data
{
    public class RestServiceVrpIntervBanque : IRestService<VRPINTERV_BANQUE>
    {
        // classe http client
        HttpClient client;

        //liste VRP
        public List<VRPINTERV_BANQUE> Items { get; private set; }

        //CONSTRUCTEUR
        public RestServiceVrpIntervBanque()
        {
            // Instanciation de la classe
            client = new HttpClient();

            Barrel.ApplicationId = Constants.Constants.ApplicationNameCache;

        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<VRPINTERV_BANQUE> GetDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Recuperer la liste des banques dans lesquels interviennent un vrp
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<List<VRPINTERV_BANQUE>> GetElementsById(string item)
        {
            Items = new List<VRPINTERV_BANQUE>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrletsBancaireByvrp + item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<VRPINTERV_BANQUE>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<VRPINTERV_BANQUE>>(content);

                    //sauvegarder les donnees dans le cache et lui donner un temps de sauvegarde(timespan)
                    Barrel.Current.Add(key: uri.ToString(), data: Items, expireIn: TimeSpan.FromDays(1));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }


        public Task<VRPINTERV_BANQUE> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> RefreshDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(VRPINTERV_BANQUE item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}
