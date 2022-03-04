using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Data;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Services
{
    public class VrpRelationEtsDataStore : IDataStoreWEB<VRP_RELATION_ETS>
    {
        IRestService<VRP_RELATION_ETS> _restService;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="service"></param>
        public VrpRelationEtsDataStore(IRestService<VRP_RELATION_ETS> service)
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
        public Task<List<VRP_RELATION_ETS>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }


        /// <summary>
        /// Lister tous les elements de la liste a partir d'un parametre
        /// </summary>
        /// <param name="service"></param>
        public Task<List<VRP_RELATION_ETS>> RefreshDataAsyncWithItem(string item)
        {
            return _restService.RefreshDataAsyncWithItem(item);
        }


        /// <summary>
        /// raffraichir les elements de la liste apres le pull to refresh
        /// </summary>
        /// <param name="service"></param>
        public Task<List<VRP_RELATION_ETS>> RefreshDatafreshAsync(bool forceRefresh = false)
        {
            return _restService.RefreshDatafreshAsync(forceRefresh);
        }

        /// <summary>
        ///enregsitrements ou mise a jour d'un element
        /// </summary>
        /// <param name="service"></param>
        public Task SaveTodoItemAsync(VRP_RELATION_ETS item, bool isNewItem = false)
        {
            return _restService.SaveTodoItemAsync(item, isNewItem);
        }


        /// <summary>
        /// recuperer les infos d'un element par son ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<VRP_RELATION_ETS> GetItemAsync(string id)
        {
            return _restService.GetDataAsyncWithItem(id);
        }

        public Task<VRP_RELATION_ETS> GetItemsAsync(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetItemsAsyncById(string item, string itemsecond)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetElementsById(string item)
        {
           
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetElementsByIdAndNull(string item = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<VRP_RELATION_ETS>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null)
        {
            throw new NotImplementedException();
        }
    }
}

