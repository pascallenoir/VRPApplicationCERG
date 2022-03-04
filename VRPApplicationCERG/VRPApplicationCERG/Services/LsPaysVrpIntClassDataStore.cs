using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class LsPaysVrpIntClassDataStore : IDataStoreWEB<LSPAYSVRPINTCLASS>
    {
        IRestService<LSPAYSVRPINTCLASS> restService;


        public LsPaysVrpIntClassDataStore(IRestService<LSPAYSVRPINTCLASS> service)
        {
            restService = service;
        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> GetElementsById(string item)
        {
            return restService.RefreshDataAsyncWithItem(item);
        }

        public Task<List<LSPAYSVRPINTCLASS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> GetElementsByIdAndNull(string item = null)
        {
            return restService.GetElementsByIdAndNull(item);
        }

        public Task<LSPAYSVRPINTCLASS> GetItemAsync(string item)
        {
            throw new NotImplementedException();
        }

        public Task<LSPAYSVRPINTCLASS> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> GetItemsAsyncById(string item, string itemsecond)
        {
            return restService.GetItemsAsyncById(item, itemsecond);
        }

        public Task<List<LSPAYSVRPINTCLASS>> GetTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<LSPAYSVRPINTCLASS>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(LSPAYSVRPINTCLASS item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }
    }
}
