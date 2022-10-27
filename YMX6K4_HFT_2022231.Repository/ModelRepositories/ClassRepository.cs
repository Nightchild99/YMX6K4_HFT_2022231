using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMX6K4_HFT_2022231.Models;
using YMX6K4_HFT_2022231.Models.Models;
using YMX6K4_HFT_2022231.Repository.Database;
using YMX6K4_HFT_2022231.Repository.Interface;
using YMX6K4_HFT_2022231.Repository.Repository;

namespace YMX6K4_HFT_2022231.Repository.ModelRepositories
{
    public class ClassRepository : Repository<Class>, IRepository<Class>
    {
        public ClassRepository(DnDDbContext ctx)
            : base(ctx)
        {

        }

        public override Class Read(int id)
        {
            return ctx.Classes.FirstOrDefault(c => c.ID == id);
        }

        public override void Update(Class item)
        {
            var old = Read(item.ID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
