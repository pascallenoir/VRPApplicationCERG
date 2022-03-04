using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class BankByCountDataStore : IDataStoreWEB<BANKBYCOUNTCLASS>
    {
        IRestService<BANKBYCOUNTCLASS> restService;


        public BankByCountDataStore(IRestService<BANKBYCOUNTCLASS> service)
        {

            restService = service;

        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANKBYCOUNTCLASS>> GetElementsById(string item)
        {
            return restService.RefreshDataAsyncWithItem(item);
        }

        public Task<List<BANKBYCOUNTCLASS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANKBYCOUNTCLASS>> GetElementsByIdAndNull(string item = null)
        {
            return restService.GetElementsByIdAndNull(item);
        }

        public Task<BANKBYCOUNTCLASS> GetItemAsync(string item)
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

        public Task<List<BANKBYCOUNTCLASS>> GetTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BANKBYCOUNTCLASS>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANKBYCOUNTCLASS>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(BANKBYCOUNTCLASS item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }
    }
}
