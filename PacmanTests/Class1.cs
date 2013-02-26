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
            gameState.pacman = new Pacman("a5", true);

            gameState.pacman.MovePacman();

            Assert.Equal("a4", gameState.pacman.PacmanPosition);
        }

        [Fact]
        public void GhostIsMovingCorrectly()
        {
            var gameState = new GameState();
            gameState.ghostPosition = "a3";

            MoveGhost(gameState);

            Assert.Equal(gameState.ghostMoves["a3"], gameState.ghostPosition);
        }

        [Fact]
        public void PacmanReversesDirectionAtEndOfForwardPath()
        {
            var gameState = new GameState();
            gameState.pacman = new Pacman("i1", true);

            gameState.pacman.MovePacman();
            Assert.False(gameState.pacman.PacmanIsMovingForward);
        }

        [Fact]
        public void WhenMovingBackwardsPacmanUsesBackwardPath()
        {
            var gameState = new GameState();
            gameState.pacman = new Pacman("f5", false);

            gameState.pacman.MovePacman();

            Assert.Equal(Pacman.pacmanBackwardMoves["f5"], gameState.pacman.PacmanPosition);
        }

        [Fact]
        public void GhostBecomesToxicAtTheCorrectTick()
        {
            var gameState = new GameState();
            gameState.toxicTickCount = 2;
            gameState.clockTick = 0;
            gameState.ghostPosition = "a1";

            MoveGhost(gameState);

            Assert.True(gameState.ghostIsToxic);
        }

        [Fact]
        public void GhostCeasesToBeToxicAfterOneTick()
        {
            var gameState = new GameState();
            gameState.toxicTickCount = 2;
            gameState.clockTick = 1;
            gameState.ghostPosition = "a2";
            gameState.ghostIsToxic = true;

            MoveGhost(gameState);

            Assert.False(gameState.ghostIsToxic);
        }

        private void MoveGhost(GameState gameState)
        {
            gameState.clockTick++;
            gameState.ghostPosition = gameState.ghostMoves[gameState.ghostPosition];
            gameState.ghostIsToxic = (gameState.clockTick + 1) % gameState.toxicTickCount == 0;
        }

        private class GameState
        {
            public int clockTick = 0;

            public string ghostPosition;
            public int toxicTickCount = 2;
            public bool ghostIsToxic;
            public Pacman pacman;

            public Dictionary<string, string> ghostMoves = new Dictionary<string, string>()
                                                               {
                                                                   {"i1", "i2"},
                                                                   {"i2", "i3"},
                                                                   {"i3", "i4"},
                                                                   {"i4", "i5"},
                                                                   {"i5", "h5"},
                                                                   {"h5", "g5"},
                                                                   {"g5", "f5"},
                                                                   {"f5", "e5"},
                                                                   {"e5", "d5"},
                                                                   {"d5", "c5"},
                                                                   {"c5", "b5"},
                                                                   {"b5", "a5"},
                                                                   {"a5", "a4"},
                                                                   {"a4", "a3"},
                                                                   {"a3", "a2"},
                                                                   {"a2", "a1"},
                                                                   {"a1", "b1"},
                                                                   {"b1", "c1"},
                                                                   {"c1", "d1"},
                                                                   {"d1", "e1"},
                                                                   {"e1", "f1"},
                                                                   {"f1", "g1"},
                                                                   {"g1", "h1"},
                                                                   {"h1", "i1"},
                                                               };


        }
    }
}
