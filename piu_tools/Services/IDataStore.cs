using System.Collections.Generic;

namespace piu_tools.Services
{
    public interface IDataStore<T>
    {
        bool AddItemAsync(T item);
        bool UpdateItemAsync(T item);
        bool DeleteItemAsync(string id);
        T GetItemAsync(string id);
        IEnumerable<T> GetItemsAsync(bool forceRefresh = false);
    }
}
