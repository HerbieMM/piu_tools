using System;
using System.IO;
using piu_tools.Models;

namespace piu_tools.Services
{
    public class JSONHandler
    {
        public JSONHandler()
        {
        }

        public static MusicInfo GetSongListFromJson()
        {

            using (StreamReader r = new StreamReader(@"/Resources/Json/unlock_songs.json"))
            {
                string json = r.ReadToEnd();

                var teste = Newtonsoft.Json.JsonConvert.DeserializeObject<UnlockableChartsList>(json);
            }


            return new MusicInfo();
        }
    }
}
