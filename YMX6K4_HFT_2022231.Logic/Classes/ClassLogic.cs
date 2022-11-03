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
    public class ClassLogic : IClassLogic
    {
        IRepository<Class> repo;

        public ClassLogic(IRepository<Class> repo)
        {
            this.repo = repo;
        }

        public void Create(Class item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Class Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Class> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Class item)
        {
            this.repo.Update(item);
        }
    }
}
