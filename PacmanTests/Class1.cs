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

            MovePacman(gameState);

            Assert.Equal("a4", gameState.pacmanPosition);
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
            gameState.pacmanPosition = "i1";

            MovePacman(gameState);
            Assert.False(gameState.pacmanIsMovingForward);
        }

        [Fact]
        public void WhenMovingBackwardsPacmanUsesBackwardPath()
        {
            var gameState = new GameState();
            gameState.pacmanIsMovingForward = false;
            gameState.pacmanPosition = "f5";

            MovePacman(gameState);

            Assert.Equal(gameState.pacmanBackwardMoves["f5"], gameState.pacmanPosition);
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

        private void MovePacman(GameState gameState)
        {
            gameState.clockTick++;

            var pacmanMoves = PacmanMoves(gameState);
            if (!pacmanMoves.ContainsKey(gameState.pacmanPosition))
            {
                gameState.pacmanIsMovingForward = !gameState.pacmanIsMovingForward;
                pacmanMoves = PacmanMoves(gameState);
            }

            gameState.pacmanPosition = pacmanMoves[gameState.pacmanPosition];
        }

        private static Dictionary<string, string> PacmanMoves(GameState gameState)
        {
            return gameState.pacmanIsMovingForward
                       ? gameState.pacmanForwardMoves
                       : gameState.pacmanBackwardMoves;
        }

        private class GameState
        {
            public int clockTick = 0;

            public string pacmanPosition;
            public string ghostPosition;
            public int toxicTickCount = 2;
            public bool ghostIsToxic;
            public bool pacmanIsMovingForward = true;

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

            public Dictionary<string, string> pacmanForwardMoves = new Dictionary<string, string>()
                                                                {
                                                                    {"a5", "a4"},
                                                                    {"a4", "a3"},
                                                                    {"a3", "a2"},
                                                                    {"a2", "a1"},
                                                                    {"a1", "b1"},
                                                                    {"b1", "c1"},
                                                                    {"c1", "d1"},
                                                                    {"d1", "e1"},
                                                                    {"e1", "e2"},
                                                                    {"e2", "e3"},
                                                                    {"e3", "e4"},
                                                                    {"e4", "e5"},
                                                                    {"e5", "f5"},
                                                                    {"f5", "g5"},
                                                                    {"g5", "h5"},
                                                                    {"h5", "i5"},
                                                                    {"i5", "i4"},
                                                                    {"i4", "i3"},
                                                                    {"i3", "i2"},
                                                                    {"i2", "i1"},
                                                                };

            public Dictionary<string, string> pacmanBackwardMoves = new Dictionary<string, string>()
                                                                        {
                                                                            {"i1", "i2"},
                                                                            {"i2", "i3"},
                                                                            {"i3", "i4"},
                                                                            {"i4", "i5"},
                                                                            {"i5", "h5"},
                                                                            {"h5", "g5"},
                                                                            {"g5", "f5"},
                                                                            {"f5", "e5"},
                                                                            {"e5", "e4"},
                                                                            {"e4", "e3"},
                                                                            {"e3", "e2"},
                                                                            {"e2", "e1"},
                                                                            {"e1", "d1"},
                                                                            {"d1", "c1"},
                                                                            {"c1", "b1"},
                                                                            {"b1", "a1"},
                                                                            {"a1", "a2"},
                                                                            {"a2", "a3"},
                                                                            {"a3", "a4"},
                                                                            {"a4", "a5"},
                                                                        };
        }
    }
}
