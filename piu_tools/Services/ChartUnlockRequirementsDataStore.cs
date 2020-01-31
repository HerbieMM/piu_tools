using System;
using System.Collections.Generic;
using System.IO;
using piu_tools.Models;
using SQLite;
using static System.Environment;

namespace piu_tools.Services
{
    public class ChartUnlockRequirementsDataStore : IDataStore<ChartUnlockRequirements>
    {

        public SQLiteConnection SQLiteConnection { get; set; }
        private readonly string ConnectionString = Path.Combine(GetFolderPath(SpecialFolder.Personal), @"piutools.db3");


        public ChartUnlockRequirementsDataStore()
        {
            if (!File.Exists(ConnectionString))
                File.Create(ConnectionString);

            SQLiteConnection = new SQLiteConnection(ConnectionString);
            SQLiteConnection.CreateTable<ChartUnlockRequirements>();
        }

        public bool AddItemAsync(ChartUnlockRequirements item)
        {
            return SQLiteConnection.Insert(item) > 0;
        }

        public bool DeleteItemAsync(string id)
        {
            return SQLiteConnection.Delete(id) > 0;
        }

        public ChartUnlockRequirements GetItemAsync(string id)
        {
            return SQLiteConnection.Find<ChartUnlockRequirements>(id);
        }

        public IEnumerable<ChartUnlockRequirements> GetItemsAsync(bool forceRefresh = false)
        {
            return SQLiteConnection.Table<ChartUnlockRequirements>().ToList();
        }

        public bool UpdateItemAsync(ChartUnlockRequirements item)
        {
            return SQLiteConnection.Update(item) > 0;
        }
    }
}
