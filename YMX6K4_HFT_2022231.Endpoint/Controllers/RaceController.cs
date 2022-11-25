using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using YMX6K4_HFT_2022231.Logic.Interfaces;
using YMX6K4_HFT_2022231.Models.Models;

namespace YMX6K4_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RaceController : Controller
    {
        IRaceLogic logic;

        public RaceController(IRaceLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Race> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Race Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create(Race race)
        {
            this.logic.Create(race);
        }

        [HttpPut]
        public void Update(Race race)
        {
            this.logic.Update(race);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
