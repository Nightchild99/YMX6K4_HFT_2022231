using ConsoleTools;
using System;
using YMX6K4_HFT_2022231.Models.Models;
using System.Linq;
using System.Collections.Generic;
using MovieDbApp.Client;
using Microsoft.VisualBasic.FileIO;

namespace YMX6K4_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;

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
                rest.Post(newPlayer, "palyer");
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

        static void List(string entity)
        {
            if (entity == "Player")
            {
                List<Player> players = rest.Get<Player>("player");
                foreach (var item in players)
                {
                    Console.WriteLine(item.Name + " is playing " + item.CharacterName 
                        + ", a level " + item.Level + " " + item.Race.Name + " " + item.Class.Name + ".");
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
        }

        static void Update(string entity)
        {
            if (entity == "Player")
            {

            }
            else if (entity == "Race")
            {

            }
            else if (entity == "Class")
            {

            }
        }

        static void Delete(string entity)
        {
            if (entity == "Player")
            {

            }
            else if (entity == "Race")
            {

            }
            else if (entity == "Class")
            {

            }
        }

        static void Main(string[] args)
        {
            

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
