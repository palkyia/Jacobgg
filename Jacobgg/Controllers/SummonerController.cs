using Jacobgg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.Json;

namespace Jacobgg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        public static HttpClient client = new();
        
        // GET: api/Summoner
        [HttpGet("{name}")]
        public async Task<ActionResult<Summoner>> Get(string name)
        {
            
            var summoner = await client.GetFromJsonAsync<Summoner>($"https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{name}?api_key={Config.values["apiKey"]}");
            
            return summoner;
        }



        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
