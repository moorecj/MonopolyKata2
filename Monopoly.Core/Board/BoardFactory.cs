using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Bank;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Events.Handlers;

namespace Monopoly.Core.Board
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IBanker banker;
        private Dictionary<int, Space> spaces;

        public BoardFactory(IBanker banker)
        {
            this.banker = banker;
            InitializeSpaces();
            InitializeHandlers();
        }

        public IBoard Create()
        {
            return new Board(spaces);
        }

        private void InitializeSpaces()
        {
            spaces = new Dictionary<int, Space> {{0, new Go()}};

            for (int i = 1; i < 40; i++)
                spaces.Add(i, new EmptySpace());
        }

        private void InitializeHandlers()
        {
            // TODO figure how to use reflection to do this
            // Maybe use custom attribute on handler classes?
            var goHandler = new GoHandler(banker, spaces[0] as Go);
        }
    }
}