using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gameengine;
using System.Net;
using System.Collections.Generic;

namespace GameengineTests
{
    [TestClass]
    public class UnitTest1

    {
        [TestMethod]
        public void CreateGameTest()
        {
            //Arrange
            User TestUser = new User
            {
                Name = "test",
                PlayerID = "test",
                Side = "O",
                Email = "test@test.se"
            };
            //Act
            Lobby.CreateGame(1, TestUser);
            var gameSession = Lobby.PendingGame[0].Players[0];
            //Assert
            Assert.AreEqual(gameSession.Name, TestUser.Name);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            Lobby.PendingGame.Clear();
        }

        [TestMethod]
        public void FindGameTest()
        {
            //Arrange            
            User TestUser = new User
            {
                Name = "test",
                PlayerID = "test",
                Side = "O",
                Email = "test@test.se"
            };
            Lobby.CreateGame(2, TestUser);
            //Act
            Lobby.FindGame(TestUser);
            int gameID = ActiveGame.Game[0].GameID;
            //Assert
            Assert.AreEqual(2, gameID);
        }

        [TestMethod]
        public void GetSessionTest()
        {
            //Arrange            
            User TestUser = new User
            {
                Name = "test",
                PlayerID = "test",
                Side = "O",
                Email = "test@test.se"
            };
            Lobby.CreateGame(2, TestUser);
            Lobby.FindGame(TestUser);
            //Act
            GameSession gameSession1 = ActiveGame.Game[0];
            GameSession gameSession2 = ActiveGame.GetSession("test");
            //Assert
            Assert.AreSame(gameSession1, gameSession2);
        }        
    }
}

