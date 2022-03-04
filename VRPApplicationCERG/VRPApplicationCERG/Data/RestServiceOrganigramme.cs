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
    public class RestServiceOrganigramme : IRestService<ORGANIGRAMME>
    {
        // classe http client
        HttpClient client;

        //liste VRP
        public List<ORGANIGRAMME> Items { get; private set; }

        public RestServiceOrganigramme()
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
        public async Task<List<ORGANIGRAMME>> RefreshDataAsync()
        {
            Items = new List<ORGANIGRAMME>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrOrganigrammeListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<ORGANIGRAMME>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<ORGANIGRAMME>>(content);


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
        public async Task<List<ORGANIGRAMME>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            Items = new List<ORGANIGRAMME>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrOrganigrammeListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<ORGANIGRAMME>>(key: uri.ToString());
                }

                if (isNewItem)
                {
                    HttpResponseMessage response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        Items = JsonConvert.DeserializeObject<List<ORGANIGRAMME>>(content);

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
        public async Task<List<ORGANIGRAMME>> RefreshDataAsyncWithItem(string item)
        {
            Items = new List<ORGANIGRAMME>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrOrganigrammeListe, item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<ORGANIGRAMME>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<ORGANIGRAMME>>(content);

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
        public async Task SaveTodoItemAsync(ORGANIGRAMME item, bool isNewItem = false)
        {

            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrOrganigrammeSave));
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
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrOrganigrammePut));
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
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrOrganigrammeDeleteID, id));

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
        public async Task<ORGANIGRAMME> GetDataAsyncWithItem(string item)
        {
            var valeur = new ORGANIGRAMME();
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrOrganigrammeDetail + item));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<ORGANIGRAMME>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    valeur = JsonConvert.DeserializeObject<ORGANIGRAMME>(content);

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

        public Task<ORGANIGRAMME> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<ORGANIGRAMME>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<ORGANIGRAMME>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<ORGANIGRAMME>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<ORGANIGRAMME>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}
