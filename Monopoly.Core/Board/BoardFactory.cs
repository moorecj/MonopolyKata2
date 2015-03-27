using System.Collections.Generic;
using System.Runtime.InteropServices;

using Monopoly.Core.Bank;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Events.Handlers;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IBanker banker;
        private readonly IJailer jailer;
        private Dictionary<int, Space> spaces;

        public BoardFactory(IBanker banker, IJailer jailer)
        {
            this.banker = banker;
            this.jailer = jailer;
            InitializeSpaces();
            InitializeHandlers();
        }

        public IBoard Create()
        {
            return new Board(spaces);
        }

        private void InitializeSpaces()
        {
            spaces = new Dictionary<int, Space>
            {
                { 0,  new Go()           },
                { 1,  new EmptySpace()   },
                { 2,  new EmptySpace()   },
                { 3,  new EmptySpace()   },
                { 4,  new EmptySpace()   },
                { 5,  new EmptySpace()   },
                { 6,  new EmptySpace()   },
                { 7,  new EmptySpace()   },
                { 8,  new EmptySpace()   },
                { 9,  new JustVisiting() },
                { 10, new EmptySpace()   },
                { 11, new EmptySpace()   }, 
                { 12, new EmptySpace()   },
                { 13, new EmptySpace()   },
                { 14, new EmptySpace()   },
                { 15, new EmptySpace()   },
                { 16, new EmptySpace()   },
                { 17, new EmptySpace()   },
                { 18, new EmptySpace()   },
                { 19, new EmptySpace()   },
                { 20, new EmptySpace()   },
                { 21, new EmptySpace()   },
                { 22, new EmptySpace()   },
                { 23, new EmptySpace()   },
                { 24, new EmptySpace()   },
                { 25, new EmptySpace()   },
                { 26, new EmptySpace()   },
                { 27, new EmptySpace()   },
                { 28, new EmptySpace()   },
                { 29, new GoToJail()     },
                { 30, new EmptySpace()   },
                { 31, new EmptySpace()   },
                { 32, new EmptySpace()   },
                { 33, new EmptySpace()   },
                { 34, new EmptySpace()   },
                { 35, new EmptySpace()   },
                { 36, new EmptySpace()   },
                { 37, new EmptySpace()   },
                { 38, new EmptySpace()   },
                { 39, new EmptySpace()   }
            };
        }

        private void InitializeHandlers()
        {
            // TODO figure how to use reflection to do this
            // Maybe use custom attribute on handler classes?
            var goHandler = new GoHandler(banker, spaces[0] as Go);
            var goToJailHandler = new GoToJailHandler(spaces[29] as GoToJail, jailer);
        }
    }
}