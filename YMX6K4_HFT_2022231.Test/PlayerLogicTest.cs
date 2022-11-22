using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using YMX6K4_HFT_2022231.Logic.Classes;
using YMX6K4_HFT_2022231.Models.Models;
using YMX6K4_HFT_2022231.Repository.Interface;

namespace YMX6K4_HFT_2022231.Test
{
    [TestFixture]
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
            ratfolk.Players = new HashSet<Player>();
            var dragonborn = new Race("6#Dragonborn#phb#1");
            dragonborn.Players = new HashSet<Player>();
            var elf = new Race("8#Elf#phb#1");
            elf.Players = new HashSet<Player>();
            var fairy = new Race("9#Fairy#wbtw#1");
            fairy.Players = new HashSet<Player>();
            var changeling = new Race("5#Changeling#erlw#0");
            changeling.Players = new HashSet<Player>();

            var barbarian = new Class("2#Barbarian#tank#1");
            barbarian.Players = new HashSet<Player>();
            var cleric = new Class("5#Cleric#healer#1");
            cleric.Players = new HashSet<Player>();
            var ranger = new Class("12#Ranger#ranged#1");
            ranger.Players = new HashSet<Player>();
            var rogue = new Class("13#Rogue#melee#1");
            rogue.Players = new HashSet<Player>();

            bogi.Race = ratfolk;
            bogi.Class = ranger;
            gyula.Race = dragonborn;
            gyula.Class = barbarian;
            anita.Race = elf;
            anita.Class = cleric;
            tamara.Race = fairy;
            tamara.Class = rogue;
            dora.Race = changeling;
            dora.Class = rogue;

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

        [Test]
        public void PlayerReadTest()
        {
            var expected = new Player("1#Bogi#Mr. Pöpi#31#12");
            mockPlayerRepository.Setup(p => p.Read(1)).Returns(expected);
            var actual = logic.Read(1);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void PlayerCreateTest()
        {
            var player = new Player("2#Gyula#Skeltaas#6#2");
            logic.Create(player);
            mockPlayerRepository.Verify(m => m.Create(player), Times.Once);
        }
    }
}