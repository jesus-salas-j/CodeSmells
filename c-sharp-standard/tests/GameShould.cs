using System;
using c_sharp_standard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tests;

namespace TicTacToeTests
{
    [TestClass]
    public class GameShould
    {
        private Game game;

        public GameShould()
        {
            game = new Game();
        }

        [TestMethod]
        [TicTacToeExpectedException(typeof(Exception), "Invalid first player")]
        public void NotAllowPlayerOToPlayFirst()
        {
            game.Play('O', 0, 0);
        }

        [TestMethod]
        [TicTacToeExpectedException(typeof(Exception), "Invalid next player")]
        public void NotAllowPlayerXToPlayTwiceInARow()
        {
            game.Play('X', 0, 0);
            game.Play('X', 1, 0);
        }

        [TestMethod]
        [TicTacToeExpectedException(typeof(Exception), "Invalid position")]
        public void NotAllowPlayerToPlayInLastPlayedPosition()
        {
            game.Play('X', 0, 0);
            game.Play('O', 0, 0);
        }

        [TestMethod]
        [TicTacToeExpectedException(typeof(Exception), "Invalid position")]
        public void NotAllowPlayerToPlayInAnyPlayedPosition()
        {
            game.Play('X', 0, 0);
            game.Play('O', 1, 0);
            game.Play('X', 0, 0);
        }

        [TestMethod]
        public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
        {
            game.Play('X', 0, 0);
            game.Play('O', 1, 0);
            game.Play('X', 0, 1);
            game.Play('O', 1, 1);
            game.Play('X', 0, 2);

            var winner = game.Winner();

            Assert.AreEqual('X', winner);
        }

        [TestMethod]
        public void DeclarePlayerOAsAWinnerIfThreeInTopRow()
        {
            game.Play('X', 2, 2);
            game.Play('O', 0, 0);
            game.Play('X', 1, 0);
            game.Play('O', 0, 1);
            game.Play('X', 1, 1);
            game.Play('O', 0, 2);

            var winner = game.Winner();

            Assert.AreEqual('O', winner);
        }

        [TestMethod]
        public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
        {
            game.Play('X', 1, 0);
            game.Play('O', 0, 0);
            game.Play('X', 1, 1);
            game.Play('O', 0, 1);
            game.Play('X', 1, 2);

            var winner = game.Winner();

            Assert.AreEqual('X', winner);
        }

        [TestMethod]
        public void DeclarePlayerOAsAWinnerIfThreeInMiddleRow()
        {
            game.Play('X', 0, 0);
            game.Play('O', 1, 0);
            game.Play('X', 2, 0);
            game.Play('O', 1, 1);
            game.Play('X', 2, 1);
            game.Play('O', 1, 2);

            var winner = game.Winner();

            Assert.AreEqual('O', winner);
        }

        [TestMethod]
        public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
        {
            game.Play('X', 2, 0);
            game.Play('O', 0, 0);
            game.Play('X', 2, 1);
            game.Play('O', 0, 1);
            game.Play('X', 2, 2);

            var winner = game.Winner();

            Assert.AreEqual('X', winner);
        }

        [TestMethod]
        public void DeclarePlayerOAsAWinnerIfThreeInBottomRow()
        {
            game.Play('X', 0, 0);
            game.Play('O', 2, 0);
            game.Play('X', 1, 0);
            game.Play('O', 2, 1);
            game.Play('X', 1, 1);
            game.Play('O', 2, 2);

            var winner = game.Winner();

            Assert.AreEqual('O', winner);
        }
    }
}
