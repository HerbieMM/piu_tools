using System.Collections.Generic;
using System.IO;
using piu_tools.Models;
using SQLite;
using static System.Environment;

namespace piu_tools.Services
{
    public class MusicDataStore : IDataStore<MusicInfo>
    {
        public SQLiteConnection SQLiteConnection { get; set; }
        private readonly string ConnectionString = Path.Combine(GetFolderPath(SpecialFolder.Personal), @"piutools.db3");

        public MusicDataStore()
        {
            if (!File.Exists(ConnectionString))
                File.Create(ConnectionString);

            SQLiteConnection = new SQLiteConnection(ConnectionString);
            SQLiteConnection.CreateTable<MusicInfo>();
            
            //PopulateTable();            
        }

        public bool AddItemAsync(MusicInfo item)
        {
            return SQLiteConnection.Insert(item) > 0;
        }

        public bool DeleteItemAsync(string id)
        {
            return SQLiteConnection.Delete<MusicInfo>(id) > 0;
        }

        public MusicInfo GetItemAsync(string id)
        {
            return SQLiteConnection.Find<MusicInfo>(id);
        }

        public IEnumerable<MusicInfo> GetItemsAsync(bool forceRefresh = false)
        {
            return SQLiteConnection.Table<MusicInfo>().ToList();
        }

        public bool UpdateItemAsync(MusicInfo item)
        {
            return SQLiteConnection.Update(item) > 0;
        }

        private void PopulateTable()
        {
            //TODO consertar o método
            //var musics = GetItemsAsync();

            //if (musics. == 0)
            //{
            //    var musics = JSONHandler.GetSongListFromJson();
            //    foreach (var item in musics)
            //    {
            //        AddItemAsync(item);
            //    }
            //}

        }

    }
}
