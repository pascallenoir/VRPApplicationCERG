using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class TypeRelationVrpDataStore : IDataStoreWEB<TYPE_RELATION_VRP>
    {
        IRestService<TYPE_RELATION_VRP> _restService;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="service"></param>
        public TypeRelationVrpDataStore(IRestService<TYPE_RELATION_VRP> service)
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
        public Task<List<TYPE_RELATION_VRP>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }


        /// <summary>
        /// Lister tous les elements de la liste a partir d'un parametre
        /// </summary>
        /// <param name="service"></param>
        public Task<List<TYPE_RELATION_VRP>> RefreshDataAsyncWithItem(string item)
        {
            return _restService.RefreshDataAsyncWithItem(item);
        }


        /// <summary>
        /// raffraichir les elements de la liste apres le pull to refresh
        /// </summary>
        /// <param name="service"></param>
        public Task<List<TYPE_RELATION_VRP>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            return _restService.RefreshDatafreshAsync(forceRefresh);
        }

        /// <summary>
        ///enregsitrements ou mise a jour d'un element
        /// </summary>
        /// <param name="service"></param>
        public Task SaveTodoItemAsync(TYPE_RELATION_VRP item, bool isNewItem = false)
        {
            return _restService.SaveTodoItemAsync(item, isNewItem);
        }


        /// <summary>
        /// recuperer les infos d'un element par son ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TYPE_RELATION_VRP> GetItemAsync(string id)
        {
            return _restService.GetDataAsyncWithItem(id);
        }

        public Task<TYPE_RELATION_VRP> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<TYPE_RELATION_VRP>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<TYPE_RELATION_VRP>> GetElementsById(string item)
        {
            throw new NotImplementedException();
        }

        public Task<List<TYPE_RELATION_VRP>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TYPE_RELATION_VRP>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}
