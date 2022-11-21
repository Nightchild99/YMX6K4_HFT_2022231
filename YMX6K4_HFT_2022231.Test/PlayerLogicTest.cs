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
            var inputdata = new List<Player>()
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
            }.AsQueryable();

            mockPlayerRepository = new Mock<IRepository<Player>>();
            mockPlayerRepository.Setup(m => m.ReadAll()).Returns(inputdata);
            logic = new PlayerLogic(mockPlayerRepository.Object);
        }
    }
}