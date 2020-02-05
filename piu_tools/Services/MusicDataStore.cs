using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            {
                File.Create(ConnectionString);
                SQLiteConnection = new SQLiteConnection(ConnectionString, SQLiteOpenFlags.ReadWrite);

                try
                {
                    SQLiteConnection.CreateTables<MusicInfo, Chart, ChartUnlockRequirements>(CreateFlags.None);
                    SQLiteConnection.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                PopulateTables();
            }
            else
            {
                SQLiteConnection = new SQLiteConnection(ConnectionString, SQLiteOpenFlags.ReadWrite);
            }
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

        public List<MusicInfo> GetAllItemsAsync(bool forceRefresh = false)
        {
            return SQLiteConnection.Table<MusicInfo>().ToList();
        }

        public bool UpdateItemAsync(MusicInfo music)
        {
            bool success = SQLiteConnection.Update(music) > 0;

            SQLiteConnection.UpdateAll(music.Charts);

            foreach (var chart in music.Charts)
            {
                SQLiteConnection.UpdateAll(chart.Require);
            }

            SQLiteConnection.Commit();          

            return success;
        }

        public List<Chart> GetChartsItem(string songId)
        {
            var charts = SQLiteConnection.Table<Chart>().Where(c => c.SongId == songId).ToList();

            foreach (var chart in charts)
            {
                var requirements = SQLiteConnection.Table<ChartUnlockRequirements>().Where(r => r.ChartId == chart.ChartId).ToList();
                chart.Require = new ObservableCollection<ChartUnlockRequirements>(requirements);
            }

            return charts;
        }

        #region [ Populating tables for the first access ]

        private void PopulateTables()
        {
            List<MusicInfo> musicsDb = GetAllItemsAsync();

            if (musicsDb.Count == 0)
            {
                var musics = JSONHandler.GetSongListFromJson();

                foreach (var item in musics)
                {
                    PopulateChartTable(item.Charts, item.SongId);

                    AddItemAsync(item);
                }
            }
        }

        private void PopulateChartTable(ObservableCollection<Chart> charts, string songId)
        {

            foreach (var chart in charts)
            {
                chart.SongId = songId;
                chart.ChartId = songId + chart.Level;
                PopulateRequirementTable(chart.Require, chart.ChartId);
            }

            SQLiteConnection.InsertAll(charts);
        }

        private void PopulateRequirementTable(ObservableCollection<ChartUnlockRequirements> require, string chartId)
        {
            for (int i = 0; i < require.Count; i++)
            {
                require[i].ChartId = chartId;
                require[i].RequirementId = chartId + i;
            }

            SQLiteConnection.InsertAll(require);
        }

        #endregion
    }
}
