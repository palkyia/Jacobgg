using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jacobgg.Models;
namespace Jacobgg.Controllers
{
    
    [ApiController]
    public class MatchesController : ControllerBase
    {
        
        [HttpGet]
        [Route("api/[controller]/{puuid}")]
        public async Task<ActionResult<List<string>>> GetPlayerMatches(string puuid)
        {
            HttpClient client = new HttpClient();
            var matches = await client.GetFromJsonAsync<List<string>>($"https://americas.api.riotgames.com/lol/match/v5/matches/by-puuid/{puuid}/ids?api_key={Config.values["apiKey"]}");
            client.Dispose();
            return matches;
        }

        [HttpGet]
        [Route("api/[controller]/matchinfo/{matchId}")]
        public async Task<ActionResult<RiotMatchInfo>> GetMatchInfoById(string matchId)
        {
            HttpClient client = new HttpClient();
            var riotMatch = await client.GetFromJsonAsync<RiotMatchInfo>($"https://americas.api.riotgames.com/lol/match/v5/matches/{matchId}?api_key={Config.values["apiKey"]}");
            client.Dispose();
            return riotMatch;
        }
        
    }
}
