using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class JoinTablesClassDataStore : IDataStoreWEB<JOINTABLESCLASS>
    {
        IRestService<JOINTABLESCLASS> _restService;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="service"></param>
        public JoinTablesClassDataStore(IRestService<JOINTABLESCLASS> service)
        {
            _restService = service;
        }


        /// <summary>
        /// Supprimer un element dans la liste a partir de son identifiant
        /// </summary>
        /// <param name="service"></param>
        public Task DeleteTodoItemAsync(string id)
        {
            return _restService.DeleteTodoItemAsync(id);
        }


        /// <summary>
        /// Lister tous les elements de la liste
        /// </summary>
        /// <param name="service"></param>
        public Task<List<JOINTABLESCLASS>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }


        /// <summary>
        /// Lister tous les elements de la liste a partir d'un parametre
        /// </summary>
        /// <param name="service"></param>
        public Task<List<JOINTABLESCLASS>> RefreshDataAsyncWithItem(string item)
        {
            return _restService.RefreshDataAsyncWithItem(item);
        }


        /// <summary>
        /// raffraichir les elements de la liste apres le pull to refresh
        /// </summary>
        /// <param name="service"></param>
        public Task<List<JOINTABLESCLASS>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            return _restService.RefreshDatafreshAsync(forceRefresh);
        }

        /// <summary>
        ///enregsitrements ou mise a jour d'un element
        /// </summary>
        /// <param name="service"></param>
        public Task SaveTodoItemAsync(JOINTABLESCLASS item, bool isNewItem = false)
        {
            return _restService.SaveTodoItemAsync(item, isNewItem);
        }


        /// <summary>
        /// recuperer les infos d'un element par son ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<JOINTABLESCLASS> GetItemAsync(string id)
        {
            return _restService.GetDataAsyncWithItem(id);
        }

        public Task<JOINTABLESCLASS> GetItemsAsync(string item, string itemsecond)
        {
            return _restService.GetItemsAsync(item, itemsecond);
        }

        public Task<List<JOINTABLESCLASS>> GetItemsAsyncById(string item, string itemsecond)
        {
            return _restService.GetItemsAsyncById(item, itemsecond);
        }

        /// <summary>
        /// recuperer les infos d'un element par son ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<JOINTABLESCLASS>> GetElementsById(string item)
        {
            return _restService.GetElementsById(item);
        }

        public Task<List<JOINTABLESCLASS>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<JOINTABLESCLASS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}
