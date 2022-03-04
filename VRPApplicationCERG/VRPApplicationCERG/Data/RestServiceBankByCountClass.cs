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
    public class RestServiceBankByCountClass : IRestService<BANKBYCOUNTCLASS>
    {
        // classe http client
        HttpClient client;

        //liste VRP
        public List<BANKBYCOUNTCLASS> Items { get; private set; }

        public RestServiceBankByCountClass()
        {
            // Instanciation de la classe
            client = new HttpClient();
            Barrel.ApplicationId = Constants.Constants.ApplicationNameCache;

        }


        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BANKBYCOUNTCLASS> GetDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANKBYCOUNTCLASS>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<BANKBYCOUNTCLASS> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANKBYCOUNTCLASS>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANKBYCOUNTCLASS>> RefreshDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BANKBYCOUNTCLASS>> RefreshDataAsyncWithItem(string item)
        {
            Items = new List<BANKBYCOUNTCLASS>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueParPaysListe + item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<BANKBYCOUNTCLASS>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<BANKBYCOUNTCLASS>>(content);

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

        public Task<List<BANKBYCOUNTCLASS>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(BANKBYCOUNTCLASS item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BANKBYCOUNTCLASS>> GetElementsByIdAndNull(string item = null)
        {
            Items = new List<BANKBYCOUNTCLASS>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueParPaysListe + item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<BANKBYCOUNTCLASS>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<BANKBYCOUNTCLASS>>(content);

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

        public Task<List<BANKBYCOUNTCLASS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}
