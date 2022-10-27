using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMX6K4_HFT_2022231.Models;

namespace YMX6K4_HFT_2022231.Repository
{
    public class RaceRepository : Repository<Race>, IRepository<Race>
    {
        public RaceRepository(DnDDbContext ctx) 
            : base(ctx)
        {

        }

        public override Race Read(int id)
        {
            return ctx.Races.FirstOrDefault(r => r.ID == id);
        }

        public override void Update(Race item)
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
