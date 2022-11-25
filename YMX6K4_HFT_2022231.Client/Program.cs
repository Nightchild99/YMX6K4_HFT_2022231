using ConsoleTools;
using System;
using YMX6K4_HFT_2022231.Logic.Classes;
using YMX6K4_HFT_2022231.Repository.Database;
using YMX6K4_HFT_2022231.Repository.ModelRepositories;

namespace YMX6K4_HFT_2022231.Client
{
    internal class Program
    {
        static PlayerLogic playerLogic;
        static RaceLogic raceLogic;
        static ClassLogic classLogic;

        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.WriteLine();
        }

        static void List(string entity)
        {
            if (entity == "Player")
            {
                var items = playerLogic.ReadAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.Name + " is playing " + item.CharacterName + ", a level " 
                                      + item.Level + " " + item.Race.Name + " " + item.Class.Name + ".");
                }
            }
            else if (entity == "Race")
            {
                var items = raceLogic.ReadAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.ID + "\t" + item.Name);
                }
            }
            else if (entity == "Class")
            {
                var items = classLogic.ReadAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.ID + "\t" + item.Name);
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            var ctx = new DnDDbContext();

            var playerRepo = new PlayerRepository(ctx);
            var raceRepo = new RaceRepository(ctx);
            var classRepo = new ClassRepository(ctx);

            playerLogic = new PlayerLogic(playerRepo);
            raceLogic = new RaceLogic(raceRepo);
            classLogic = new ClassLogic(classRepo);

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Exit", ConsoleMenu.Close);

            var raceSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Race"))
                .Add("Create", () => Create("Race"))
                .Add("Delete", () => Delete("Race"))
                .Add("Update", () => Update("Race"))
                .Add("Exit", ConsoleMenu.Close);

            var classSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Class"))
                .Add("Create", () => Create("Class"))
                .Add("Delete", () => Delete("Class"))
                .Add("Update", () => Update("Class"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Players", () => playerSubMenu.Show())
                .Add("Races", () => raceSubMenu.Show())
                .Add("Classes", () => classSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
