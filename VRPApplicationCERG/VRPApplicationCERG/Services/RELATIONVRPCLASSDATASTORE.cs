using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class RELATIONVRPCLASSDATASTORE : IDataStoreWEB<RELATIONVRPCLASS>
    {
        IRestService<RELATIONVRPCLASS> _restService;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="service"></param>
        public RELATIONVRPCLASSDATASTORE(IRestService<RELATIONVRPCLASS> service)
        {
            _restService = service;
        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<RELATIONVRPCLASS> GetItemAsync(string item)
        {
            throw new NotImplementedException();
        }

        public Task<RELATIONVRPCLASS> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> GetItemsAsyncById(string item, string itemsecond)
        {
            return _restService.GetItemsAsyncById(item, itemsecond);
        }

        public Task<List<RELATIONVRPCLASS>> GetTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<RELATIONVRPCLASS>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(RELATIONVRPCLASS item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }
    }
}