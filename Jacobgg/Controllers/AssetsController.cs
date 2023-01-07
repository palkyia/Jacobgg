using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Jacobgg.Models;
using System.Text.Json;
using System.Numerics;
using System.Linq;
using System.Collections.Immutable;
using System.Security.Cryptography.X509Certificates;

namespace Jacobgg.Controllers
{
    
    [ApiController]
    public class AssetsController : ControllerBase
    {
        public List<RuneTree> runesReforged; 
        private Dictionary<int, string> runeImgPaths = new Dictionary<int, string>();
        private string ddragonURI;
        private string riotAPIKey;
        
        public AssetsController() {

            runesReforged = JsonSerializer.Deserialize<List<RuneTree>>(System.IO.File.ReadAllText("../runesReforged.json"));


            ddragonURI = Program.Configuration.GetValue<string>("DdragonURI");
            riotAPIKey = Program.Configuration.GetValue<string>("RiotAPIKey");
            // maps the id and icon field into runeImgPaths for each rune Tree and then each rune in each slot of the tree
            runesReforged.ForEach(rt =>
            {
                runeImgPaths.Add(rt.id, rt.icon);
                rt.slots.ForEach(s =>
                {
                    s.runes.ForEach(r =>
                    {
                        runeImgPaths.Add(r.id, r.icon);
                    });
                });
            });

            //var topLevelRunes = runesReforged.RuneTrees.Select(rt => new KeyValuePair<int, string>(rt.id, rt.icon));    //Top-level id-icon pairs.
            //var nestedRunes = runesReforged.RuneTrees.SelectMany(rt => rt.slots.SelectMany(s => s.runes.Select(r => new KeyValuePair<int, string>(r.id, r.icon))));
            //var combinedRuneCollection = topLevelRunes.Union(nestedRunes);
        } 

        [HttpGet]
        [Route("api/[controller]/runes/{id}")]
        public async Task<HttpResponseMessage> GetRunesImg([FromRoute] string id)
        {
            string imgPath = runeImgPaths[Int32.Parse(id)];
            HttpClient client = new HttpClient();
            var asset = await client.GetStreamAsync($"{ddragonURI}{imgPath}?api_key={riotAPIKey}");
            return asset;
        }
    }
}
