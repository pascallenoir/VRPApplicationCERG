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
    public class RestServiceEtsBancaire : IRestService<ETS_BANCAIRE>
    {
        // classe http client
        HttpClient client;

        //liste VRP
        public List<ETS_BANCAIRE> Items { get; private set; }

        public RestServiceEtsBancaire()
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
        public async Task<List<ETS_BANCAIRE>> RefreshDataAsync()
        {
            Items = new List<ETS_BANCAIRE>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrEtsBancaireListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<ETS_BANCAIRE>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<ETS_BANCAIRE>>(content);

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


        /// <summary>
        /// Service pour Afficher la liste des elements de la table apres raffraichissement de la liste via API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<List<ETS_BANCAIRE>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            Items = new List<ETS_BANCAIRE>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrEtsBancaireListe, string.Empty));
            try
            {

                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<ETS_BANCAIRE>>(key: uri.ToString());
                }

                if (isNewItem)
                {
                    HttpResponseMessage response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        Items = JsonConvert.DeserializeObject<List<ETS_BANCAIRE>>(content);

                        //sauvegarder les donnees dans le cache et lui donner un temps de sauvegarde(timespan)
                        Barrel.Current.Add(key: uri.ToString(), data: Items, expireIn: TimeSpan.FromDays(1));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }


        /// <summary>
        /// Service pour Afficher la liste des elements de la table avec une donnee precise via API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<List<ETS_BANCAIRE>> RefreshDataAsyncWithItem(string item)
        {
            Items = new List<ETS_BANCAIRE>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrEtsBancaireListe, item));
            try
            {

                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<ETS_BANCAIRE>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<ETS_BANCAIRE>>(content);


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



        /// <summary>
        /// Service pour l'ajout d"un nouvel element dans la base de donnees via l'api
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isNewItem"></param>
        /// <returns></returns>
        public async Task SaveTodoItemAsync(ETS_BANCAIRE item, bool isNewItem = false)
        {

            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrEtsBancaireSave));
                    response = await client.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine(@"\tTodoItem successfully saved.");
                        string result = await response.Content.ReadAsStringAsync();

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrEtsBancairePut));
                    response = await client.PutAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine(@"\tTodoItem successfully saved.");
                        string result = await response.Content.ReadAsStringAsync();

                    }
                    else
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }



        /// <summary>
        /// Service pour supprimer un element dans la table via API avec id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTodoItemAsync(string id)
        {
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrEtsBancaireDeleteID, id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }


        /// <summary>
        /// Recuperer les infos par id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<ETS_BANCAIRE> GetDataAsyncWithItem(string item)
        {
            var valeur = new ETS_BANCAIRE();
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrEtsBancaireDetail + item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<ETS_BANCAIRE>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    valeur = JsonConvert.DeserializeObject<ETS_BANCAIRE>(content);


                    //sauvegarder les donnees dans le cache et lui donner un temps de sauvegarde(timespan)
                    Barrel.Current.Add(key: uri.ToString(), data: Items, expireIn: TimeSpan.FromDays(1));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return valeur;

        }

        public Task<ETS_BANCAIRE> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<ETS_BANCAIRE>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<ETS_BANCAIRE>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<ETS_BANCAIRE>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<ETS_BANCAIRE>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}