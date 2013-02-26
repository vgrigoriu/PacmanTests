using System.Collections.Generic;
using Xunit;

namespace PacmanTests
{
    public class Class1
    {
        [Fact]
        public void PacmanIsMovingCorrectlyAfterFirstTick()
        {
            var gameState = new GameState();
            gameState.pacmanPosition = "a5";

            gameState.clockTick++;
            gameState.pacmanPosition = "a4";

            Assert.Equal("a4", gameState.pacmanPosition);
        }

        [Fact]
        public void GhostIsMovingCorrectlyAfterFirstPosition()
        {
            var gameState = new GameState();
            gameState.ghostPosition = "i1";

            gameState.clockTick++;
            gameState.ghostPosition = "i2";

            Assert.Equal("i2", gameState.ghostPosition);
        }

        [Fact]
        public void GhostMovesCorrectlyAfterSecondTick()
        {
            var gameState = new GameState();
            gameState.clockTick = 1;
            gameState.ghostPosition = "i2";

            gameState.clockTick++;
            gameState.ghostPosition = "i3";

            Assert.Equal("i3", gameState.ghostPosition);
        }

        private class GameState
        {
            public int clockTick = 0;

            public string pacmanPosition;
            public string ghostPosition;

            public List<string> ghostPath = new List<string> { "i1", "i2", "i3" };
        }
    }
}
