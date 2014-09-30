using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PortableLeagueAPI;
using PortableLeagueApi.Interfaces.Enums;
using PortableLeagueApi.Static.Extensions;

namespace RiotPlease.Controllers
{
    public class ChampionController : ApiController
    {
        [Route("api/champion/getChampionImageUrl/{championId}")]
        public async Task<string> GetChampionImageUrl(int championId)
        {
            var leagueAPI = new LeagueApi("d7ac8e0b-d8a9-4743-9374-24d5dae197e7", RegionEnum.Euw, true);
            var champion = await leagueAPI.Static.GetChampionAsync(championId, dataDragonVersion: "4.2.6");
            return await champion.GetChampionImageUrlAsync();
        }
    }
}
