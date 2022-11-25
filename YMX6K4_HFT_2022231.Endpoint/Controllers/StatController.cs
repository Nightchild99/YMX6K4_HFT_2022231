using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YMX6K4_HFT_2022231.Logic.Interfaces;
using YMX6K4_HFT_2022231.Models.Models;

namespace YMX6K4_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : Controller
    {
        IPlayerLogic logic;

        public StatController(IPlayerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Player> PlayersUsingCoreRules()
        {
            return this.logic.PlayersUsingCoreRules();
        }

        [HttpGet]
        public IEnumerable<Player> PlayersPlayingCaster()
        {
            return this.logic.PlayersPlayingCaster();
        }

        [HttpGet]
        public IEnumerable<Class> MostPlayedClass()
        {
            return this.logic.MostPlayedClass();
        }

        [HttpGet]
        public IEnumerable<Player> SupportPlayersUsingCoreRules()
        {
            return this.logic.SupportPlayersUsingCoreRules();
        }

        [HttpGet]
        public IEnumerable<Player> PlayersWithNotAllowedCharacters()
        {
            return this.logic.PlayersWithNotAllowedCharacters();
        }
    }
}
