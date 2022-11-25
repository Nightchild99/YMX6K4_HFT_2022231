using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMX6K4_HFT_2022231.Models;
using YMX6K4_HFT_2022231.Models.Models;

namespace YMX6K4_HFT_2022231.Repository.Database
{
    public class DnDDbContext : DbContext
    {
        public DbSet<Player> Party { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Class> Classes { get; set; }

        public DnDDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies()
                       .UseInMemoryDatabase("dnd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Player>()
                .HasOne(p => p.Race)
                .WithMany(r => r.Players)
                .HasForeignKey(p => p.RaceID)
                .OnDelete(DeleteBehavior.Cascade);

            modelbuilder.Entity<Player>()
                .HasOne(p => p.Class)
                .WithMany(c => c.Players)
                .HasForeignKey(p => p.ClassID)
                .OnDelete(DeleteBehavior.Cascade);

            modelbuilder.Entity<Race>().HasData(new Race[]
            {
                new Race("1#Aarakocra#eepc#0"),
                new Race("2#Aasimar#motm#0"),
                new Race("3#Bugbear#vgtm#0"),
                new Race("4#Centaur#moot#0"),
                new Race("5#Changeling#erlw#0"),
                new Race("6#Dragonborn#phb#1"),
                new Race("7#Dwarf#phb#1"),
                new Race("8#Elf#phb#1"),
                new Race("9#Fairy#wbtw#1"),
                new Race("10#Firbolg#vgtm#0"),
                new Race("11#Genasi#eepc#0"),
                new Race("12#Gith#mtof#0"),
                new Race("13#Gnome#phb#1"),
                new Race("14#Goblin#vgtm#0"),
                new Race("15#Goliath#eepc#0"),
                new Race("16#Half-Elf#phb#1"),
                new Race("17#Half-Orc#phb#1"),
                new Race("18#Halfling#phb#1"),
                new Race("19#Harengon#wbtw#0"),
                new Race("20#Hobgoblin#vgtm#0"),
                new Race("21#Human#phb#1"),
                new Race("22#Kalashtar#erlw#0"),
                new Race("23#Kenku#vgtm#0"),
                new Race("24#Kobold#vgtm#0"),
                new Race("25#Leonin#moot#0"),
                new Race("26#Lineage#vrgt#0"),
                new Race("27#Lizardfolk#vgtm#0"),
                new Race("28#Loxodon#ggtr#0"),
                new Race("29#Minotaur#ggtr#0"),
                new Race("30#Orc#vgtm#0"),
                new Race("31#Ratfolk#dndb#1"),
                new Race("32#Satyr#moot#0"),
                new Race("33#Shifter#erlw#0"),
                new Race("34#Simic Hybrid#ggtr#0"),
                new Race("35#Tabaxi#vgtm#1"),
                new Race("36#Tiefling#phb#1"),
                new Race("37#Tortle#ttp#0"),
                new Race("38#Triton#vgtm#0"),
                new Race("39#Vedalken#ggtr#0"),
                new Race("40#Warforged#erlw#0"),
                new Race("41#Yuan-ti Pureblood#vgtm#0")
            });

            modelbuilder.Entity<Class>().HasData(new Class[]
            {
                new Class("1#Artificer#support#0"),
                new Class("2#Barbarian#tank#1"),
                new Class("3#Bard#support#1"),
                new Class("4#Blood Hunter#melee#0"),
                new Class("5#Cleric#healer#1"),
                new Class("6#Druid#various#1"),
                new Class("7#Fighter#melee#1"),
                new Class("8#Gunslinger#ranged#0"),
                new Class("9#Monk#melee#0"),
                new Class("10#Paladin#various#1"),
                new Class("11#Pirate#melee#1"),
                new Class("12#Ranger#ranged#1"),
                new Class("13#Rogue#melee#1"),
                new Class("14#Sorcerer#caster#1"),
                new Class("15#Warlock#caster#1"),
                new Class("16#Wizard#caster#1")
            });

            modelbuilder.Entity<Player>().HasData(new Player[]
            {
                new Player("1#Bogi#Mr. Pöpi#31#12"),
                new Player("2#Gyula#Skeltaas#6#2"),
                new Player("3#Anita#Shalott#8#5"),
                new Player("4#Bálint#Henry#21#10"),
                new Player("5#Viki#Mylora#35#7"),
                new Player("6#Döme#Blahzar#36#15"),
                new Player("7#Alex#Alvin#13#3"),
                new Player("8#Tamara#Lynari#9#13"),
                new Player("9#Attila#Peet#21#11"),
                new Player("10#Dóra#Echo#5#13")
            });
        }
    }
}
