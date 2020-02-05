using System.Collections.Generic;
using piu_tools.Models;

namespace piu_tools.Services
{
    public interface IDataStore<T>
    {
        bool AddItemAsync(T item);
        bool UpdateItemAsync(T item);
        bool DeleteItemAsync(string id);
        T GetItemAsync(string id);
        List<T> GetAllItemsAsync(bool forceRefresh = false);
        List<Chart> GetChartsItem(string songId);
    }
}
