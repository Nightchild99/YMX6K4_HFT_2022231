using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMX6K4_HFT_2022231.Models.Models;

namespace YMX6K4_HFT_2022231.Logic.Interfaces
{
    public interface IRaceLogic
    {
        void Create(Race item);
        Race Read(int id);
        IQueryable<Race> ReadAll();
        void Update(Race item);
        void Delete(int id);
    }
}
