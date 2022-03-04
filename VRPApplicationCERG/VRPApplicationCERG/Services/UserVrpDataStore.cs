using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class UserVrpDataStore : IDataStoreWEB<VRP_RELATION_ETS>
    {
        public UserVrpDataStore(RestServiceVrpUtilisateur restServiceVrpUtilisateur)
        {
        }

        public Task DeleteTodoItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<VRP_RELATION_ETS> GetItemAsync(string item)
        {
            throw new NotImplementedException();
        }

        public Task<VRP_RELATION_ETS> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> RefreshDataAsyncWithItem(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task SaveTodoItemAsync(VRP_RELATION_ETS item, bool isNewItem = false)
        {
            throw new NotImplementedException();
        }
    }
}
