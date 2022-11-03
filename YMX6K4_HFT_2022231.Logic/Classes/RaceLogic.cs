using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMX6K4_HFT_2022231.Logic.Interfaces;
using YMX6K4_HFT_2022231.Models.Models;
using YMX6K4_HFT_2022231.Repository.Interface;

namespace YMX6K4_HFT_2022231.Logic.Classes
{
    public class RaceLogic : IRaceLogic
    {
        IRepository<Race> repo;

        public RaceLogic(IRepository<Race> repo)
        {
            this.repo = repo;
        }

        public void Create(Race item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Race Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Race> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Race item)
        {
            this.repo.Update(item);
        }
    }
}
