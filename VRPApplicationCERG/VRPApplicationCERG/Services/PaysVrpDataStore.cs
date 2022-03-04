using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class PaysVrpDataStore : IDataStoreWEB<PAYS_NATIONAL>
    {
        IRestService<PAYS_NATIONAL> restService;

        //readonly List<BANQUE_VRP> ListeBanqueVRP;

        public PaysVrpDataStore(IRestService<PAYS_NATIONAL> service)
        {

            restService = service;

        }
        public Task DeleteTodoItemAsync(string id)
        {
            return restService.DeleteTodoItemAsync(id);
        }

        public Task<List<PAYS_NATIONAL>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<PAYS_NATIONAL>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<PAYS_NATIONAL>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<PAYS_NATIONAL> GetItemAsync(string item)
        {
            return restService.GetDataAsyncWithItem(item);
        }

        public Task<PAYS_NATIONAL> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<PAYS_NATIONAL>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Recuperer la liste des pays
        /// </summary>
        /// <returns></returns>
        public Task<List<PAYS_NATIONAL>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<List<PAYS_NATIONAL>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<PAYS_NATIONAL>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            return restService.RefreshDatafreshAsync(forceRefresh);
        }

        public Task SaveTodoItemAsync(PAYS_NATIONAL item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
    }
}
