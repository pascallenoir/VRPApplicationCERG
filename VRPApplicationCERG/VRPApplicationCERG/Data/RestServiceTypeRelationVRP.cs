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
    public class RestServiceTypeRelationVRP : IRestService<TYPE_RELATION_VRP>
    { 
        // classe http client
        HttpClient client;

        //liste VRP
        public List<TYPE_RELATION_VRP> Items { get; private set; }

        public RestServiceTypeRelationVRP()
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
        public async Task<List<TYPE_RELATION_VRP>> RefreshDataAsync()
        {
            Items = new List<TYPE_RELATION_VRP>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrTypeRelationListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<TYPE_RELATION_VRP>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<TYPE_RELATION_VRP>>(content);

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
        public async Task<List<TYPE_RELATION_VRP>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            Items = new List<TYPE_RELATION_VRP>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrTypeRelationListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<TYPE_RELATION_VRP>>(key: uri.ToString());
                }

                if (isNewItem)
                {
                    HttpResponseMessage response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        Items = JsonConvert.DeserializeObject<List<TYPE_RELATION_VRP>>(content);

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
        public async Task<List<TYPE_RELATION_VRP>> RefreshDataAsyncWithItem(string item)
        {
            Items = new List<TYPE_RELATION_VRP>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrTypeRelationListe, item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<TYPE_RELATION_VRP>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<TYPE_RELATION_VRP>>(content);

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
        public async Task SaveTodoItemAsync(TYPE_RELATION_VRP item, bool isNewItem = false)
        {

            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrTypeRelationSave));
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
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrTypeRelationPut));
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
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrTypeRelationDeleteID, id));

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
        public async Task<TYPE_RELATION_VRP> GetDataAsyncWithItem(string item)
        {
            var valeur = new TYPE_RELATION_VRP();
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrTypeRelationDetail + item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<TYPE_RELATION_VRP>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    valeur = JsonConvert.DeserializeObject<TYPE_RELATION_VRP>(content);

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

        public Task<TYPE_RELATION_VRP> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<TYPE_RELATION_VRP>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<TYPE_RELATION_VRP>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<TYPE_RELATION_VRP>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TYPE_RELATION_VRP>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}

