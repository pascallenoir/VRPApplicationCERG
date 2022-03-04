using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.Models;

namespace VRPApplicationCERG.Data
{
	public interface IRestService<T>
	{
		Task<List<T>> RefreshDataAsync();
		Task<List<T>> RefreshDataAsyncWithItem(string item);
		Task<T> GetDataAsyncWithItem(string item);
		Task<List<T>> RefreshDatafreshAsync(bool isNewItem = false);
		Task SaveTodoItemAsync(T item, bool isNewItem = false);
		Task DeleteTodoItemAsync(string id);
		Task<T> GetItemsAsync(string item, string itemsecond);
		Task<List<T>> GetItemsAsyncById(string item, string itemsecond);
		Task<List<T>> GetElementsById(string item);
		Task<List<T>> GetElementsByIdAndNull(string item = null);
		Task<List<T>> GetElementsByIdAndIdAndNull(string item = null, string itemsecond = null);
	}
}
