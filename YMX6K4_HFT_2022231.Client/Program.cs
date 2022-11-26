using ConsoleTools;
using System;
using YMX6K4_HFT_2022231.Models.Models;
using System.Linq;
using System.Collections.Generic;

namespace YMX6K4_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;

        #region Create
        static void Create(string entity)
        {
            if (entity == "Player")
            {
                Console.WriteLine("Enter player name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter character name: ");
                string charname = Console.ReadLine();
                Console.WriteLine("Enter race ID: ");
                int raceid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter class ID: ");
                int classid = int.Parse(Console.ReadLine());

                Player newPlayer = new Player { Name = name, CharacterName = charname, RaceID = raceid, ClassID = classid };
                rest.Post(newPlayer, "player");
            }
            else if (entity == "Race")
            {
                Console.WriteLine("Enter race name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter race source: ");
                string source = Console.ReadLine();
                Console.WriteLine("Is race allowed by DM? (0/1): ");
                int allowed = int.Parse(Console.ReadLine());
                Race newRace;

                if (allowed == 1)
                {
                    newRace = new Race { Name = name, Source = source, Allowed = true };
                }
                else
                {
                    newRace = new Race { Name = name, Source = source, Allowed = false };
                }

                rest.Post(newRace, "race");

            }
            else if (entity == "Class")
            {
                Console.WriteLine("Enter class name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter class type: ");
                string type = Console.ReadLine();
                Console.WriteLine("Is this class allowed by DM? (0/1): ");
                int allowed = int.Parse(Console.ReadLine());

                bool isAllowed;

                if (allowed == 0)
                {
                    isAllowed = false;
                }
                else
                {
                    isAllowed = true;
                }

                Class newClass;

                switch (type)
                {
                    case "tank":
                        newClass = new Class { Name = name, Type = Models.Models.Type.tank, Allowed = isAllowed };
                        rest.Post(newClass, "class");
                        break;
                    case "melee":
                        newClass = new Class { Name = name, Type = Models.Models.Type.melee, Allowed = isAllowed };
                        rest.Post(newClass, "class");
                        break;
                    case "ranged":
                        newClass = new Class { Name = name, Type = Models.Models.Type.ranged, Allowed = isAllowed };
                        rest.Post(newClass, "class");
                        break;
                    case "caster":
                        newClass = new Class { Name = name, Type = Models.Models.Type.caster, Allowed = isAllowed };
                        rest.Post(newClass, "class");
                        break;
                    case "support":
                        newClass = new Class { Name = name, Type = Models.Models.Type.support, Allowed = isAllowed };
                        rest.Post(newClass, "class");
                        break;
                    case "healer":
                        newClass = new Class { Name = name, Type = Models.Models.Type.healer, Allowed = isAllowed };
                        rest.Post(newClass, "class");
                        break;
                    case "various":
                        newClass = new Class { Name = name, Type = Models.Models.Type.various, Allowed = isAllowed };
                        rest.Post(newClass, "class");
                        break;
                }
            }
        }
        #endregion

        #region List
        static void List(string entity)
        {
            if (entity == "Player")
            {
                List<Player> players = rest.Get<Player>("player");
                foreach (var item in players)
                {
                    Console.WriteLine(item.ID + "\t" + item.Name + "\t" 
                        + item.CharacterName + "\t" + item.RaceID + "\t" + item.ClassID);
                }
            }
            else if (entity == "Race")
            {
                List<Race> races = rest.Get<Race>("race");
                foreach (var item in races)
                {
                    if (item.Allowed == true)
                    {
                        Console.WriteLine(item.ID + "\t" + item.Name + "\t" + item.Source + "\t" + "allowed");
                    }
                    else
                    {
                        Console.WriteLine(item.ID + "\t" + item.Name + "\t" + item.Source + "\t" + "not allowed");
                    }
                }
            }
            else if (entity == "Class")
            {
                List<Class> classes = rest.Get<Class>("class");
                foreach (var item in classes)
                {
                    if (item.Allowed == true)
                    {
                        Console.WriteLine(item.ID + "\t" + item.Name + "\t" + item.Type + "\t" + "allowed");
                    }
                    else
                    {
                        Console.WriteLine(item.ID + "\t" + item.Name + "\t" + item.Type + "\t" + "not allowed");
                    }
                }
            }
            Console.ReadLine();
        }
        #endregion

        #region Update
        static void Update(string entity)
        {
            if (entity == "Player")
            {
                Console.WriteLine("Enter player's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Player old = rest.Get<Player>(id, "player");
                Console.WriteLine($"New name [old: {old.Name}]: ");
                string name = Console.ReadLine();
                Console.WriteLine($"New character name [old: {old.CharacterName}]: ");
                string charName = Console.ReadLine();
                Console.WriteLine($"New race ID [old: {old.RaceID}]: ");
                int raceId = int.Parse(Console.ReadLine());
                Console.WriteLine($"New class ID [old: {old.ClassID}]: ");
                int classId = int.Parse(Console.ReadLine());

                old.Name = name;
                old.CharacterName = charName;
                old.RaceID = raceId;
                old.ClassID = classId;
                rest.Put(old, "player");
            }
            else if (entity == "Race")
            {
                Console.WriteLine("Enter race's ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Race old = rest.Get<Race>(id, "race");
                Console.WriteLine($"New name [old: {old.Name}]: ");
                string name = Console.ReadLine();
                Console.WriteLine($"New source [old: {old.Source}]");
                string source = Console.ReadLine();
                Console.WriteLine($"Is this allowed? [{old.Allowed}] (0/1)");
                int allowed = int.Parse(Console.ReadLine());

                if (allowed == 1)
                {
                    old.Name = name;
                    old.Source = source;
                    old.Allowed = true;
                    rest.Put(old, "race");
                }
                else
                {
                    old.Name = name;
                    old.Source = source;
                    old.Allowed = false;
                    rest.Put(old, "race");
                }
            }
            else if (entity == "Class")
            {
                Console.WriteLine("Enter class ID to update: ");
                int id = int.Parse(Console.ReadLine());
                Class old = rest.Get<Class>(id, "class");
                Console.WriteLine($"New name [old: {old.Name}]: ");
                string name = Console.ReadLine();
                Console.WriteLine($"New source [old: {old.Type}]");
                string type = Console.ReadLine();
                Console.WriteLine($"Is this allowed? [{old.Allowed}] (0/1)");
                int allowed = int.Parse(Console.ReadLine());

                bool isAllowed;
                if (allowed == 1)
                {
                    isAllowed = true;
                }
                else
                {
                    isAllowed = false;
                }

                switch (type)
                {
                    case "tank":
                        old.Name = name;
                        old.Type = Models.Models.Type.tank;
                        old.Allowed = isAllowed;
                        rest.Put(old, "class");
                        break;
                    case "melee":
                        old.Name = name;
                        old.Type = Models.Models.Type.melee;
                        old.Allowed = isAllowed;
                        rest.Put(old, "class");
                        break;
                    case "ranged":
                        old.Name = name;
                        old.Type = Models.Models.Type.ranged;
                        old.Allowed = isAllowed;
                        rest.Put(old, "class");
                        break;
                    case "caster":
                        old.Name = name;
                        old.Type = Models.Models.Type.caster;
                        old.Allowed = isAllowed;
                        rest.Put(old, "class");
                        break;
                    case "support":
                        old.Name = name;
                        old.Type = Models.Models.Type.support;
                        old.Allowed = isAllowed;
                        rest.Put(old, "class");
                        break;
                    case "healer":
                        old.Name = name;
                        old.Type = Models.Models.Type.healer;
                        old.Allowed = isAllowed;
                        rest.Put(old, "class");
                        break;
                    case "various":
                        old.Name = name;
                        old.Type = Models.Models.Type.various;
                        old.Allowed = isAllowed;
                        rest.Put(old, "class");
                        break;
                }
            }
        }
        #endregion

        #region Delete
        static void Delete(string entity)
        {
            if (entity == "Player")
            {
                Console.WriteLine("Enter player's ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "player");
            }
            else if (entity == "Race")
            {
                Console.WriteLine("Enter race's ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "race");
            }
            else if (entity == "Class")
            {
                Console.WriteLine("Enter class ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "class");
            }
        }
        #endregion

        #region Non Crud Methods

        static void PlayersUsingCoreRules()
        {
            Console.WriteLine("Players using core rules: ");
            List<Player> items = rest.Get<Player>("Stat/PlayersUsingCoreRules");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }

        static void PlayersPlayingCaster()
        {
            Console.WriteLine("Players playing caster class: ");
            List<Player> items = rest.Get<Player>("Stat/PlayersPlayingCaster");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }

        static void MostPlayedClass()
        {
            Console.WriteLine("The most played class in party:");
            List<string> items = rest.Get<string>("Stat/MostPlayedClass");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static void SupportPlayersUsingCoreRules()
        {
            Console.WriteLine("Players playing support class and using core rules:");
            List<Player> items = rest.Get<Player>("Stat/SupportPlayersUsingCoreRules");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }

        static void PlayersWithNotAllowedCharacters()
        {
            Console.WriteLine("Players playing a characted with a race or class not allowed by the DM: ");
            List<Player> items = rest.Get<Player>("Stat/PlayersWithNotAllowedCharacters");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }

        #endregion

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:2272/", "player");

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

            var statSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Players Using Core Rules", () => PlayersUsingCoreRules())
                .Add("Players Playing Caster", () => PlayersPlayingCaster())
                .Add("Most Played Class", () => MostPlayedClass())
                .Add("Support Players Using Core Rules", () => SupportPlayersUsingCoreRules())
                .Add("Players With Not Allowed Characters", () => PlayersWithNotAllowedCharacters())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Players", () => playerSubMenu.Show())
                .Add("Races", () => raceSubMenu.Show())
                .Add("Classes", () => classSubMenu.Show())
                .Add("Stat", () => statSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
