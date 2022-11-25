using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YMX6K4_HFT_2022231.Logic.Interfaces;
using YMX6K4_HFT_2022231.Models.Models;

namespace YMX6K4_HFT_2022231.Endpoint.Controllers
{
    [Route("controller")]
    [ApiController]
    public class PlayerController : Controller
    {
        IPlayerLogic logic;

        public PlayerController(IPlayerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Player> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Player Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Player player)
        {
            this.logic.Create(player);
        }

        [HttpPut]
        public void Update([FromBody] Player player)
        {
            this.logic.Update(player);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
