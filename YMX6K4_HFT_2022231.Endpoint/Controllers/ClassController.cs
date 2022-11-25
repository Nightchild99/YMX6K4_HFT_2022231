using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using YMX6K4_HFT_2022231.Logic.Interfaces;
using YMX6K4_HFT_2022231.Models.Models;

namespace YMX6K4_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        IClassLogic logic;

        public ClassController(IClassLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Class> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Class Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Class classs)
        {
            this.logic.Create(classs);
        }

        [HttpPut]
        public void Update([FromBody] Class classs)
        {
            this.logic.Update(classs);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
