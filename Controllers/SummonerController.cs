using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PortableLeagueAPI;
using PortableLeagueApi.Game.Extensions;
using PortableLeagueApi.Game.Models;
using PortableLeagueApi.Interfaces.Enums;
using PortableLeagueApi.Interfaces.Game;

namespace RiotPlease.Controllers
{
    public class SummonerController : ApiController
    {
        [Route("api/summoner/{name}/{region}")]
        public async Task<IEnumerable<IGame>> GetSummonerByName(string name, string region)
        {
            IEnumerable<IGame> result = null;
            RegionEnum regionEnum = RegionEnum.Euw;
            RegionEnum.TryParse(region, true, out regionEnum);
            var leagueAPI = new LeagueApi("d7ac8e0b-d8a9-4743-9374-24d5dae197e7", regionEnum, true);
            var summoner = await leagueAPI.Summoner.GetSummonerByNameAsync(name, regionEnum);
            try
            {
                result = await summoner.GetRecentGamesAsync();
            }
            catch (Exception excp)
            {
                
            }
            return result;
        }


    }
}
