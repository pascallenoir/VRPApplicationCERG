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
using Xamarin.Forms;

namespace VRPApplicationCERG.Data
{
    public class RestServicePaysNational : IRestService<PAYS_NATIONAL>
    {
        // classe http client
        HttpClient client;

        //liste VRP
        public List<PAYS_NATIONAL> Items { get; private set; }

        public RestServicePaysNational()
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
        public async Task<List<PAYS_NATIONAL>> RefreshDataAsync()
        {
            Items = new List<PAYS_NATIONAL>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlPaysListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<PAYS_NATIONAL>>(key: uri.ToString());
                }

                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Items = JsonConvert.DeserializeObject<List<PAYS_NATIONAL>>(content);


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
        /// Supprimer un element dans la table a a partir de son id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTodoItemAsync(string id)
        {
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlPaysNationalDeleteID, id));
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

        public async Task<PAYS_NATIONAL> GetDataAsyncWithItem(string item)
        {
            var valeur = new PAYS_NATIONAL();
            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlPaysDetailID + item));
            try
            {

                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<PAYS_NATIONAL>(key: uri.ToString());
                }
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    valeur = JsonConvert.DeserializeObject<PAYS_NATIONAL>(content);

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

        public Task<List<PAYS_NATIONAL>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<PAYS_NATIONAL> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<PAYS_NATIONAL>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<PAYS_NATIONAL>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PAYS_NATIONAL>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            Items = new List<PAYS_NATIONAL>();

            Uri uri = new Uri(string.Format(Constants.Constants.RestUrlPaysListe, string.Empty));
            try
            {
                //Verifier l'etat de la connexion
                if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
                    !Barrel.Current.IsExpired(key: uri.ToString()))
                {
                    await Task.Yield();
                    UserDialogs.Instance.Toast("Vous utilisez le mode hors ligne actuellement. Vérifiez l'état de votre connexion pour actualiser les informations", TimeSpan.FromSeconds(5));
                    return Barrel.Current.Get<List<PAYS_NATIONAL>>(key: uri.ToString());
                }

                if (isNewItem)
                {
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();

                        Items = JsonConvert.DeserializeObject<List<PAYS_NATIONAL>>(content);

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
        /// Fonction d'enregistrement  ou de Mise a jour d'un nouvel element dans la base de donnees
        /// </summary>
        /// <param name="item"></param>
        /// <param name="isNewItem"></param>
        /// <returns></returns>
        public async Task SaveTodoItemAsync(PAYS_NATIONAL item, bool isNewItem = false)
        {
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrlPaysNationalSave));
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
                    Uri uri = new Uri(string.Format(Constants.Constants.RestUrlPaysNationalPut));
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
                await Shell.Current.DisplayAlert("Alerte", "Nous rencontrons un problème avec cette opération. Si le problème persite, contacter votre administrateur", "Bien");

            }
        }

        public Task<List<PAYS_NATIONAL>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<PAYS_NATIONAL>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}
