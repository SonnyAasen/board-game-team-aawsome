﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gameengine;
using System.Net;
using System.Collections.Generic;

namespace GameengineTests
{
    [TestClass]
    public class UnitTest1

    {
        public const string Localhost = "http://localhost:64599/"; //Ändra till eran lokala hostadress!!
        //public static List<GameSession> PendingGames = new List<GameSession>();
        GameSession gameSession = new GameSession();

        [TestMethod]
        public void CheckIfNewGameHasPlayerOne()
        {
            //Arrange 

            int x = 123123;
            Lobby startGame = new Lobby();


            User player = new User { Name = "agge", Email = "asdfasdf", PlayerID = "asdf12312adfs", Side = "O" };


            //Act
            Lobby.CreateGame(x, player);
            GameSession gameSession = new GameSession
            {
                GameID = x,
                Players = new User[2]

            };
            gameSession.Players[0] = player;
            var actualResult = gameSession.Players[0].Side;
            var expectedResult = gameSession.Players[0].Side == "O";


            //Assert
            Assert.IsTrue(expectedResult, actualResult);

        }

        [TestMethod]
        public void CheckIfCookieIsSet()
        {

            WebRequest request = WebRequest.Create(Localhost + "Home/StartPage/");


            var response = (HttpWebResponse)request.GetResponse();


            Assert.IsFalse(response.Headers[HttpResponseHeader.SetCookie].EndsWith("ä"));
        }

        [TestMethod]
        public void CheckIfAwatingGameHasPlayerTwo()  // Får kanske ta bort denna. det är bara under en sek som pendinggames har två spelare innan den flyttas
        {
            List<GameSession> PendingGames = new List<GameSession>();
            //Arrange 
            var expectedResult = PendingGames[0].Players[1];
            Lobby lobby = new Lobby();

            User player = new User { Name = "sonny", Email = "asdf", PlayerID = "312adfs", Side = "X" };

            //Act
            Lobby.FindGame(player);

            bool actualResult = PendingGames.Contains(PendingGames[0]);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void CheckWinConditions()
        {
            //Arrange 
            Gameengine.User[] player =
                {
                new User {Name = "sonny", Email = "asdf", PlayerID = "312adfs", Side = "X" },
                new User {Name = "donny", Email = "dsdf", PlayerID = "3fff2adfs", Side = "O" }
            };

            User[] board = new User[9];
            {
                board[1] = player[1];
                board[2] = player[1];
                board[3] = player[1];
                board[4] = player[2];
                board[5] = player[1];
                board[6] = player[2];
                board[7] = player[2];
                board[8] = player[2];
                board[9] = player[1];

            };
            var expectedResult = player[1].Name + " has won!";
            //Act
            var actualResult = gameSession.WinConditions(); //board, player[1]
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void CheckingWhoseTurn()
        {
            //Arrange 
            Gameengine.User[] player =
        {
                new User {Name = "sonny", Email = "asdf", PlayerID = "312adfs", Side = "X" },
                new User {Name = "donny", Email = "dsdf", PlayerID = "3fff2adfs", Side = "O" }
            };
            User[] board = new User[9];
            {
                board[1] = player[1];
                board[2] = player[1];
                board[3] = player[1];
                board[4] = player[2];
                board[5] = player[1];
                board[6] = player[2];
                board[7] = player[2];
                board[8] = player[2];
                board[9] = player[1];

            };
            bool FirstPlayerTurn = true;
            string cookieValue = "s1df23sd21fds21f2sd3f";
            string buttonClick = "5";
            var expectedResult = FirstPlayerTurn == false;
            //Act
            gameSession.Turn(cookieValue, buttonClick);
            var actualResult = FirstPlayerTurn;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}

