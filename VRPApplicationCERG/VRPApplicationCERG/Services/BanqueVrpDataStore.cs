using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class BanqueVrpDataStore: IDataStoreWEB<BANQUE_VRP>
    {

        IRestService<BANQUE_VRP> restService;

        //readonly List<BANQUE_VRP> ListeBanqueVRP;

        public BanqueVrpDataStore(IRestService<BANQUE_VRP> service)
        {

            restService = service;
            
        }

        //FONction API
        public Task<List<BANQUE_VRP>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<List<BANQUE_VRP>> GetTasksAsync(string item)
        {
            return restService.RefreshDataAsyncWithItem(item);
        }

        public Task SaveTaskAsync(BANQUE_VRP item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }


        //public async Task<bool> AddItemAsync(BANQUE_VRP item)
        //{
        //    ListeBanqueVRP.Add(item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> UpdateItemAsync(BANQUE_VRP item)
        //{
        //    var oldItem = ListeBanqueVRP.Where((BANQUE_VRP arg) => arg.CODE_VRP == item.CODE_VRP).FirstOrDefault();
        //    ListeBanqueVRP.Remove(oldItem);
        //    ListeBanqueVRP.Add(item);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteItemAsync(string id)
        //{
        //    var oldItem = ListeBanqueVRP.Where((BANQUE_VRP arg) => arg.CODE_VRP == id).FirstOrDefault();
        //    ListeBanqueVRP.Remove(oldItem);

        //    return await Task.FromResult(true);
        //}

        public Task<BANQUE_VRP> GetItemAsync(string id)
        {
            return restService.GetDataAsyncWithItem(id);
        }

        public Task<List<BANQUE_VRP>> GetItemsAsync(bool forceRefresh = false)
        {
            //return await Task.FromResult(ListeBanqueVRP);
            return restService.RefreshDatafreshAsync(forceRefresh);
        }

        public Task<List<BANQUE_VRP>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BANQUE_VRP>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(BANQUE_VRP item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item,isNewItem);
        }

        public Task DeleteTodoItemAsync(string id)
        {
            return restService.DeleteTodoItemAsync(id);
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