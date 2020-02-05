using System;
using System.Collections.Generic;
using System.IO;
using piu_tools.Models;
using SQLite;
using static System.Environment;

namespace piu_tools.Services
{
    public class ChartDataStore : IDataStore<Chart>
    {
        public SQLiteConnection SQLiteConnection { get; set; }
        private readonly string ConnectionString = Path.Combine(GetFolderPath(SpecialFolder.Personal), @"piutools.db3");


        public ChartDataStore()
        {
            SQLiteConnection = new SQLiteConnection(ConnectionString);            
        }        

        public bool AddItemAsync(Chart item)
        {
            return SQLiteConnection.Insert(item) > 0;
        }

        public bool DeleteItemAsync(string id)
        {
            return SQLiteConnection.Delete(id) > 0;
        }

        public Chart GetItemAsync(string id)
        {
            return SQLiteConnection.Find<Chart>(id);
        }

        public List<Chart> GetAllItemsAsync(bool forceRefresh = false)
        {
            return SQLiteConnection.Table<Chart>().ToList();
        }

        public bool UpdateItemAsync(Chart item)
        {
            return SQLiteConnection.Update(item) > 0;
        }

        public List<Chart> GetChartsItem(string songId)
        {
            throw new NotImplementedException();
        }
    }
}
