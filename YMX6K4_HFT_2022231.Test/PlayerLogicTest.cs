using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using YMX6K4_HFT_2022231.Logic.Classes;
using YMX6K4_HFT_2022231.Models.Models;
using YMX6K4_HFT_2022231.Repository.Interface;

namespace YMX6K4_HFT_2022231.Test
{
    public class PlayerLogicTest
    {
        PlayerLogic logic;
        Mock<IRepository<Player>> mockPlayerRepository;

        [SetUp]
        public void Setup()
        {
            var bogi = new Player("1#Bogi#Mr. Pöpi#31#12");
            var gyula = new Player("2#Gyula#Skeltaas#6#2");
            var anita = new Player("3#Anita#Shalott#8#5");
            var tamara = new Player("4#Tamara#Lynari#9#13");
            var dora = new Player("5#Dóra#Echo#5#13");

            var ratfolk = new Race("31#Ratfolk#dndb#1");
            var dragonborn = new Race("6#Dragonborn#phb#1");
            var elf = new Race("8#Elf#phb#1");
            var fairy = new Race("9#Fairy#wbtw#1");
            var changeling = new Race("5#Changeling#erlw#0");

            var barbarian = new Class("2#Barbarian#tank#1");
            var cleric = new Class("5#Cleric#healer#1");
            var ranger = new Class("12#Ranger#ranged#1");
            var rogue = new Class("13#Rogue#melee#1");

            ratfolk.Players.Add(bogi);
            dragonborn.Players.Add(gyula);
            elf.Players.Add(anita);
            fairy.Players.Add(tamara);
            changeling.Players.Add(dora);
            barbarian.Players.Add(gyula);
            cleric.Players.Add(anita);
            ranger.Players.Add(bogi);
            rogue.Players.Add(tamara);
            rogue.Players.Add(dora);

            var players = new List<Player>()
            {
               bogi, gyula, anita, tamara, dora
            }.AsQueryable();

            mockPlayerRepository = new Mock<IRepository<Player>>();
            mockPlayerRepository.Setup(m => m.ReadAll()).Returns(players);
            logic = new PlayerLogic(mockPlayerRepository.Object);
        }
    }
}