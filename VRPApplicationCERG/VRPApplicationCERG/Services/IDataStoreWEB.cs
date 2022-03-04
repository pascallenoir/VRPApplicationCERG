
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VRPApplicationCERG.Services
{
    public interface IDataStoreWEB<T>
    {
        Task<List<T>> GetTasksAsync();
        Task<List<T>> RefreshDataAsyncWithItem(string item);
        Task<T> GetItemAsync(string item);

        Task<List<T>> RefreshDatafreshAsync(bool forceRefresh = false);
        Task SaveTodoItemAsync(T item, bool isNewItem = false);
        Task DeleteTodoItemAsync(string id);
        Task<T> GetItemsAsync(string item, string itemsecond);
        Task<List<T>> GetItemsAsyncById(string item, string itemsecond);
        Task<List<T>> GetElementsById(string item);

        Task<List<T>> GetElementsByIdAndNull(string item = null);
        Task<List<T>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null);
    }
}
