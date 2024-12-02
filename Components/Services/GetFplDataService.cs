using System.Text.Json;
using FplStatsSsr.Components.Models;

namespace FplStatsSsr.Components.Services
{
    public class GetFplDataService
    {
        private IEnumerable<Player>? PlayerList { get; set; }
        private readonly HttpClient _httpClient;
        private readonly ILogger<GetFplDataService> _logger;
        
        public GetFplDataService(IHttpClientFactory httpClientFactory,
                                ILogger<GetFplDataService> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            if (PlayerList != null)
                return PlayerList;
            else
                return await GetPlayersDataFromServer();
            
            async Task<IEnumerable<Player>> GetPlayersDataFromServer()
            {
                const string url = "https://fantasy.premierleague.com/api/bootstrap-static/";
            
                var topLevel = await _httpClient.GetFromJsonAsync<Dictionary<string, JsonElement>>(url);

                if( topLevel != null)
                {
                    var players = JsonSerializer.Deserialize<IEnumerable<Player>>(topLevel["elements"]);

                    if(players != null)
                    {
                        PlayerList = players;

                        _logger.LogInformation("Found players");
                        return PlayerList;
                    }
                }

                _logger.LogWarning("Some sort of error has occurred returning empty list");
                        
                return new List<Player>();
            }
        }
    }
}