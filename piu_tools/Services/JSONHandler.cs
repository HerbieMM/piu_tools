
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using piu_tools.Models;


namespace piu_tools.Services
{
    public class JSONHandler
    {
        private static readonly string apiKey = "$2b$10$BDy6UCj6YUwD3YdLkDJzROZ0CnbMsJAbYLEj96jWkipWaTkRpW83C";
        private static readonly string urlJson = "https://api.jsonbin.io/b/5e42f579d18e40166176d0a8";

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


        public static async Task<UnlockableChartsList> GetJsonFromWeb()
        {

            UnlockableChartsList retorno = new UnlockableChartsList();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Secret-key", apiKey);

                    var response = await client.GetStringAsync(urlJson);

                    retorno = JsonConvert.DeserializeObject<UnlockableChartsList>(response);
                }
            }
            catch (Exception ex)
            {

            }
            return retorno;

        }
    }
}
