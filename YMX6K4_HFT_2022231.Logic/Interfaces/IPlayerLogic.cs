using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMX6K4_HFT_2022231.Models.Models;

namespace YMX6K4_HFT_2022231.Logic.Interfaces
{
    public interface IPlayerLogic
    {
        void Create(Player item);
        Player Read(int id);
        IQueryable<Player> ReadAll();
        void Update(Player item);
        void Delete(int id);
    }
}
