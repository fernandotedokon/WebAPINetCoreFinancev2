using Newtonsoft.Json;

namespace Questao2
{
    public class Futebol
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("per_page")]
        public long PerPage { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("data")]
        public Jogos[] data { get; set; }
    }

    public class Jogos
    {

        [JsonProperty("year")]
        public long Year { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }

        [JsonProperty("team1")]
        public string Team1 { get; set; }

        [JsonProperty("team2")]
        public string Team2 { get; set; }

        [JsonProperty("team1goals")]
        public long Team1Goals { get; set; }

        [JsonProperty("team2goals")]
        public long Team2Goals { get; set; }
    }


}
