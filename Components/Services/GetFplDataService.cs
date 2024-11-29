using System.Text.Json;
using FplStatsSsr.Components.Models;

namespace FplStatsSsr.Components.Services
{
    public class GetFplDataService
    {
        private List<Player>? PlayerList { get; set; }
        private readonly HttpClient _httpClient;
        private readonly ILogger<GetFplDataService> _logger;

        
        public GetFplDataService(IHttpClientFactory httpClientFactory,
                                ILogger<GetFplDataService> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
        }

        public async Task<List<Player>> GetPlayers()
        {
            if (PlayerList != null)
                return PlayerList;
            else
                return await GetPlayersDataFromServer();
            
            async Task<List<Player>> GetPlayersDataFromServer()
            {
                const string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
            
                var topLevel = await _httpClient.GetFromJsonAsync<Dictionary<string, JsonElement>>(url);

                if( topLevel != null)
                {
                    List<Player>? players = JsonSerializer.Deserialize<List<Player>>(topLevel["elements"]);

                    if(players != null)
                    {
                        PlayerList = players;

                        _logger.LogInformation($"Found {players.Count} players");
                    }
                }

                return new List<Player>();
            }
        }
    }
}