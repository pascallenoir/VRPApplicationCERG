using Acr.UserDialogs;
using MonkeyCache.FileStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;
//using System.Xml.Serialization;
using VRPApplicationCERG.Models;
using Xamarin.Essentials;

namespace VRPApplicationCERG.Data
{
    public class RestServiceBanqueVRP : IRestService<BANQUE_VRP>
    {
        // classe http client
        HttpClient client;

        //liste VRP
        public List<BANQUE_VRP> ListeBanques { get; private set; }

        public RestServiceBanqueVRP()
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
        public async Task<List<BANQUE_VRP>> RefreshDataAsync()
        {
            ListeBanques = new List<BANQUE_VRP>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueVRPListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<BANQUE_VRP>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    ListeBanques = JsonConvert.DeserializeObject<List<BANQUE_VRP>>(content);

                    //sauvegarder les donnees dans le cache et lui donner un temps de sauvegarde(timespan)
                    Barrel.Current.Add(key: uri.ToString(), data: ListeBanques, expireIn: TimeSpan.FromDays(1));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ListeBanques;
        }


        /// <summary>
        /// Service pour Afficher la liste des elements de la table apres raffraichissement de la liste via API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<List<BANQUE_VRP>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            ListeBanques = new List<BANQUE_VRP>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueVRPListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<BANQUE_VRP>>(key: uri.ToString());
                }

                if (isNewItem)
                {
                    HttpResponseMessage response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        ListeBanques = JsonConvert.DeserializeObject<List<BANQUE_VRP>>(content);

                        //sauvegarder les donnees dans le cache et lui donner un temps de sauvegarde(timespan)
                        Barrel.Current.Add(key: uri.ToString(), data: ListeBanques, expireIn: TimeSpan.FromDays(1));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ListeBanques;
        }


        /// <summary>
        /// Service pour Afficher la liste des elements de la table avec une donnee precise via API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<List<BANQUE_VRP>> RefreshDataAsyncWithItem(string item)
        {
            ListeBanques = new List<BANQUE_VRP>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueVRPListe, item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<BANQUE_VRP>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
               if (response.IsSuccessStatusCode)
               {
                   string content = await response.Content.ReadAsStringAsync();

                    ListeBanques = JsonConvert.DeserializeObject<List<BANQUE_VRP>>(content);

                    //sauvegarder les donnees dans le cache et lui donner un temps de sauvegarde(timespan)
                    Barrel.Current.Add(key: uri.ToString(), data: ListeBanques, expireIn: TimeSpan.FromDays(1));
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return ListeBanques;
        }



        /// <summary>
        /// Service pour l'ajout d"un nouvel element dans la base de donnees via l'api
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isNewItem"></param>
        /// <returns></returns>
        public async Task SaveTodoItemAsync(BANQUE_VRP banquevrps, bool isNewItem = false)
        {

            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(banquevrps), Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueVRPSave));
                    response = await client.PostAsync(uri, content);
                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine(@"\tTodoItem successfully saved.");
                        var result = JsonConvert.DeserializeObject<BANQUE_VRP>(await response.Content.ReadAsStringAsync());

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
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueVRPDeleteID + id));

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
        public async Task<BANQUE_VRP> GetDataAsyncWithItem(string item)
        {
            var valeur = new BANQUE_VRP();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlBanqueVRPDetail +item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<BANQUE_VRP>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                   valeur = JsonConvert.DeserializeObject<BANQUE_VRP>(content);

                    //sauvegarder les donnees dans le cache et lui donner un temps de sauvegarde(timespan)
                    Barrel.Current.Add(key: uri.ToString(), data: valeur, expireIn: TimeSpan.FromDays(1));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return valeur;
        }



        public Task<BANQUE_VRP> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANQUE_VRP>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANQUE_VRP>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANQUE_VRP>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANQUE_VRP>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}



