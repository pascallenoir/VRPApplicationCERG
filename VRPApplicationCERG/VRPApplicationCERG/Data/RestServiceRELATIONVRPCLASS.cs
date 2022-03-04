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
    class RestServiceRELATIONVRPCLASS : IRestService<RELATIONVRPCLASS>
    {
        // classe http client
        HttpClient client;

        //liste VRP
        public List<RELATIONVRPCLASS> Items { get; private set; }

        public RestServiceRELATIONVRPCLASS()
        {
            // Instanciation de la classe
            client = new HttpClient();

            Barrel.ApplicationId = Constants.Constants.ApplicationNameCache;

        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<RELATIONVRPCLASS> GetDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<RELATIONVRPCLASS> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RELATIONVRPCLASS>> GetItemsAsyncById(string item, string itemsecond)
        {
            
            Items = new List<RELATIONVRPCLASS>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueVRPAccueilListeParvrp + "codeVrp=" + item + "&banqueCodeBceao=" + itemsecond));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<RELATIONVRPCLASS>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<RELATIONVRPCLASS>>(content);


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

        public Task<List<RELATIONVRPCLASS>> RefreshDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(RELATIONVRPCLASS item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}
