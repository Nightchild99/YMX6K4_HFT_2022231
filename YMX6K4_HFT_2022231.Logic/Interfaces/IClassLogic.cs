using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMX6K4_HFT_2022231.Models.Models;

namespace YMX6K4_HFT_2022231.Logic.Interfaces
{
    public interface IClassLogic
    {
        void Create(Class item);
        Class Read(int id);
        IQueryable<Class> ReadAll();
        void Update(Class item);
        void Delete(int id);
    }
}
