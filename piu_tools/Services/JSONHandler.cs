
using System.Collections.ObjectModel;
using System.IO;

using System.Reflection;
using Newtonsoft.Json;
using piu_tools.Models;


namespace piu_tools.Services
{
    public class JSONHandler
    {
        public static ObservableCollection<MusicInfo> GetSongListFromJson()
        {
            UnlockableChartsList charts;

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(JSONHandler)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("piu_tools.unlock_songs.json");

            using (StreamReader sr = new StreamReader(stream))
            {
                var json = sr.ReadToEnd();

                JsonSerializer serializer = new JsonSerializer();
                charts = JsonConvert.DeserializeObject<UnlockableChartsList>(json);
            }

            return new ObservableCollection<MusicInfo>(charts.Musics);
        }
    }
}
