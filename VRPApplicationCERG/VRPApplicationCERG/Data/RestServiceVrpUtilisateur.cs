using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Data
{
    public class RestServiceVrpUtilisateur : IRestService<UTILISATEURVRPCERGI>
    {
        // classe http client
        HttpClient client;

        public List<UTILISATEURVRPCERGI> Items { get; private set; }

        public RestServiceVrpUtilisateur()
        {
            // Instanciation de la classe
            client = new HttpClient();

        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UTILISATEURVRPCERGI> GetDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<UTILISATEURVRPCERGI>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<UTILISATEURVRPCERGI>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<UTILISATEURVRPCERGI>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<UTILISATEURVRPCERGI> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<UTILISATEURVRPCERGI>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<UTILISATEURVRPCERGI>> RefreshDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<UTILISATEURVRPCERGI>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<UTILISATEURVRPCERGI>> RefreshDatafreshAsync(bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(UTILISATEURVRPCERGI item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }

      
    }
}
