
using System.Collections.Generic;

namespace PacmanTests
{
    public class Pacman
    {
        #region Dictionaries
        public static Dictionary<string, string> pacmanForwardMoves = new Dictionary<string, string>()
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

        public static Dictionary<string, string> pacmanBackwardMoves = new Dictionary<string, string>()
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
        #endregion

        public Pacman(string pacmanPosition, bool isMovingForward)
        {
            PacmanIsMovingForward = isMovingForward;
            PacmanPosition = pacmanPosition;
        }

        public string PacmanPosition { get; private set; }
        public bool PacmanIsMovingForward { get; private set; }

        public void MovePacman()
        {
            var pacmanMoves = PacmanMoves();
            if (!pacmanMoves.ContainsKey(PacmanPosition))
            {
                PacmanIsMovingForward = !PacmanIsMovingForward;
                pacmanMoves = PacmanMoves();
            }

            PacmanPosition = pacmanMoves[PacmanPosition];
        }

        private Dictionary<string, string> PacmanMoves()
        {
            return PacmanIsMovingForward
                       ? pacmanForwardMoves
                       : pacmanBackwardMoves;
        }
    }
}
