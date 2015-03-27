using Monopoly.Core.Bank;

namespace Monopoly.Core.Board.Spaces
{
    public abstract class TaxSpace : Space
    {
        protected readonly ITaxCollector TaxCollector;

        protected TaxSpace(ITaxCollector taxCollector)
        {
            TaxCollector = taxCollector;
        }
    }
}