using System.Collections.Generic;
using System.Linq;

using Monopoly.Core.Bank;
using Monopoly.Core.Bank.Properties;
using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Events.Handlers;
using Monopoly.Core.Players;

namespace Monopoly.Core.Board
{
    public class BoardFactory : IBoardFactory
    {
        private readonly IBanker banker;
        private readonly IJailer jailer;
        private readonly ITaxCollector taxCollector;
        private readonly IRealtor realtor;
        private Dictionary<int, Space> spaces;

        public BoardFactory(IBanker banker, IJailer jailer, ITaxCollector taxCollector, IRealtor realtor)
        {
            this.banker = banker;
            this.jailer = jailer;
            this.taxCollector = taxCollector;
            this.realtor = realtor;
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
                { 1,  new PropertySpace { BaseRent = 2, Price = 60, Group = "Dark Purple", Name = "Mediterranean Ave." } },
                { 2,  new EmptySpace()   },
                { 3,  new PropertySpace { BaseRent = 2, Price = 60, Group = "Dark Purple", Name = "Baltic Ave." }    },
                { 4,  new IncomeTax()   },
                { 5,  new PropertySpace { BaseRent = 25, Price = 200, Group = "Railroad", Name = "Reading Railroad" }},
                { 6,  new PropertySpace { BaseRent = 6, Price = 100, Group = "Cyan", Name = "Oriental Ave." } },
                { 7,  new EmptySpace()   },
                { 8,  new PropertySpace { BaseRent = 6, Price = 100, Group = "Cyan", Name = "Vermont Ave." }   },
                { 9,  new PropertySpace { BaseRent = 8, Price = 120, Group = "Cyan", Name = "Connecticut Ave." } },
                { 10, new JustVisiting()   },
                { 11, new PropertySpace { BaseRent = 10, Price = 140, Group = "Violet", Name = "St. Charles Place" }}, 
                { 12, new PropertySpace { BaseRent = 10, Price = 150, Group = "Utility", Name = "Electric Co" }},
                { 13, new PropertySpace { BaseRent = 10, Price = 140, Group = "Violet", Name = "States Ave." }},
                { 14, new PropertySpace { BaseRent = 12, Price = 160, Group = "Violet", Name = "Virginy Ave." }},
                { 15, new PropertySpace { BaseRent = 25, Price = 200, Group = "Railroad", Name = "Pennsylvania Railroad" }},
                { 16, new PropertySpace { BaseRent = 14, Price = 180, Group = "Orange", Name = "St. James Place" }},
                { 17, new EmptySpace()   },
                { 18, new PropertySpace { BaseRent = 14, Price = 180, Group = "Orange", Name = "Tennessee Place" }   },
                { 19, new PropertySpace { BaseRent = 16, Price = 200, Group = "Orange", Name = "New York Ave." }},
                { 20, new EmptySpace()   },
                { 21, new PropertySpace { BaseRent = 18, Price = 220, Group = "Red", Name = "Kentucky Ave." }},
                { 22, new EmptySpace()   },
                { 23, new PropertySpace { BaseRent = 18, Price = 220, Group = "Red", Name = "Indiana Ave." }},
                { 24, new PropertySpace { BaseRent = 20, Price = 240, Group = "Red", Name = "Illinois Ave." }},
                { 25, new PropertySpace { BaseRent = 25, Price = 200, Group = "Railroad", Name = "B & O Railroad" }   },
                { 26, new PropertySpace { BaseRent = 22, Price = 260, Group = "Yellow", Name = "Atlantic Ave." }},
                { 27, new PropertySpace { BaseRent = 10, Price = 150, Group = "Utility", Name = "Water Works" }},
                { 28, new PropertySpace { BaseRent = 22, Price = 260, Group = "Yellow", Name = "Ventnor Ave." }},
                { 29, new PropertySpace { BaseRent = 24, Price = 280, Group = "Yellow", Name = "Marvin Gardens" }},
                { 30, new GoToJail()   },
                { 31, new PropertySpace { BaseRent = 26, Price = 300, Group = "Green", Name = "Pacific Ave." }},
                { 32, new EmptySpace()   },
                { 33, new PropertySpace { BaseRent = 26, Price = 300, Group = "Green", Name = "North Carolina Ave." }},
                { 34, new PropertySpace { BaseRent = 28, Price = 320, Group = "Green", Name = "Pennsylvania Ave." }},
                { 35, new PropertySpace { BaseRent = 25, Price = 200, Group = "Railroad", Name = "Short Line Railroad" }},
                { 36, new EmptySpace()   },
                { 37, new PropertySpace { BaseRent = 35, Price = 350, Group = "Blue", Name = "Park Place" }},
                { 38, new LuxuryTax()    },
                { 39, new PropertySpace { BaseRent = 50, Price = 400, Group = "Blue", Name = "boardwalk" }}
            };
        }

        private void InitializeHandlers()
        {
            foreach (var space in spaces.Values.Where(s => s.GetType() == typeof (PropertySpace)))
                new PropertySpaceHandler(realtor, space as PropertySpace);

            // TODO figure how to use reflection to do this
            // Maybe use custom attribute on handler classes?
            var goHandler = new GoHandler(banker, spaces[0] as Go);
            var goToJailHandler = new GoToJailHandler(spaces[29] as GoToJail, jailer);
            var incomeTaxHandler = new IncomeTaxHandler(taxCollector, spaces[4] as IncomeTax);
            var luxuryTaxHandler = new LuxuryTaxHandler(taxCollector, spaces[39] as LuxuryTax);
        }
    }
}