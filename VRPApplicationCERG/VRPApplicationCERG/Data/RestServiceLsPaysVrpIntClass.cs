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
    public class RestServiceLsPaysVrpIntClass : IRestService<LSPAYSVRPINTCLASS>
    {
        // classe http client
        HttpClient client;

        //liste VRP
        public List<LSPAYSVRPINTCLASS> Items { get; private set; }

        public RestServiceLsPaysVrpIntClass()
        {
            // Instanciation de la classe
            client = new HttpClient();

            Barrel.ApplicationId = Constants.Constants.ApplicationNameCache;

        }

        /// <summary>
        /// Service pour Afficher la liste des elements de la table via API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<List<LSPAYSVRPINTCLASS>> RefreshDataAsync()
        {
            Items = new List<LSPAYSVRPINTCLASS>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlPaysListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<LSPAYSVRPINTCLASS>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<LSPAYSVRPINTCLASS>>(content);

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


        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<LSPAYSVRPINTCLASS> GetDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<LSPAYSVRPINTCLASS> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Service pour Afficher la liste des elements de la table via API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<List<LSPAYSVRPINTCLASS>> GetItemsAsyncById(string item, string itemsecond)
        {
            Items = new List<LSPAYSVRPINTCLASS>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlVrpParPaysEtBanque + item + "&paysCode=" + itemsecond));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<LSPAYSVRPINTCLASS>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<LSPAYSVRPINTCLASS>>(content);

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

        public Task<List<LSPAYSVRPINTCLASS>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(LSPAYSVRPINTCLASS item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}

