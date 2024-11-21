using System.Text.Json;
using FplStatsSsr.Components.Models;

namespace FplStatsSsr.Components.Services
{
    public class GetFplDataService
    {
        public List<Player> PlayerList { get; private set; } = new List<Player>();

        public readonly TaskCompletionSource<int> TaskCompletionSource = new TaskCompletionSource<int>();
    
        private readonly HttpClient _httpClient;
        
        public GetFplDataService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            GetData();
        }

        private async void GetData()
        {
            const string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
            
            var topLevel = await _httpClient.GetFromJsonAsync<Dictionary<string, JsonElement>>(url);

            if( topLevel != null)
            {
                List<Player>? players = JsonSerializer.Deserialize<List<Player>>(topLevel["elements"]);

                if(players != null)
                {
                    PlayerList = players;

                    TaskCompletionSource.SetResult(1);
                }
            }
        }
    }
}