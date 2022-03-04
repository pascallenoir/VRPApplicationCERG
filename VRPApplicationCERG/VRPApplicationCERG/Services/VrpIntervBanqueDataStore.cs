using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class VrpIntervBanqueDataStore : IDataStoreWEB<VRPINTERV_BANQUE>
    {
        IRestService<VRPINTERV_BANQUE> _restService;


        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="service"></param>
        public VrpIntervBanqueDataStore(IRestService<VRPINTERV_BANQUE> service)
        {
            _restService = service;
        }


        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> GetElementsById(string item)
        {
            return _restService.GetElementsById(item);
        }

        public Task<List<VRPINTERV_BANQUE>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<VRPINTERV_BANQUE> GetItemAsync(string item)
        {
            throw new NotImplementedException();
        }

        public Task<VRPINTERV_BANQUE> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> GetTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRPINTERV_BANQUE>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(VRPINTERV_BANQUE item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }
    }
}
