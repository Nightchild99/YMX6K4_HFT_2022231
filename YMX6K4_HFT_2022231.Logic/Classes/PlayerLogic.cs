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
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> repo;

        public PlayerLogic(IRepository<Player> repo)
        {
            this.repo = repo;
        }

        public void Create(Player item)
        {
            if (item.Name == null)
            {
                throw new NullReferenceException();
            }
            else if (item.Name.Length < 3)
            {
                throw new ArgumentException();
            }
            
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Player Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Player> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Player item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<Player> PlayersUsingCoreRules()
        {
            return this.repo.ReadAll().Where(p => p.Race.Source == "phb");
        }

        public IEnumerable<Player> PlayersPlayingCaster()
        {
            return this.repo.ReadAll().Where(p => p.Class.Type == Models.Models.Type.caster);
        }

        public IEnumerable<Player> PlayersByClassType()
        {
            return from x in repo.ReadAll()
                   group x by x.Class.Type into g
                   select new Player();
        }

        public IEnumerable<Class> MostPlayedClass()
        {
            return this.repo.ReadAll().GroupBy(p => p.Class)
                                .OrderByDescending(g => g.Count())
                                .FirstOrDefault()
                                .Select(p => p.Class);
        }

        public IEnumerable<Player> SupportPlayersUsingCoreRules()
        {
            return this.repo.ReadAll().Where(p => p.Race.Source == "phb"
                            && (p.Class.Type == Models.Models.Type.support
                            || p.Class.Type == Models.Models.Type.healer));
        }
    }
}
