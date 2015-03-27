using Monopoly.Core.Bank;
using Monopoly.Core.Board.Spaces;

namespace Monopoly.Core.Events.Handlers
{
    public class LuxuryTaxHandler : SpaceHandler<LuxuryTax>
    {
        private readonly ITaxCollector taxCollector;

        public LuxuryTaxHandler(ITaxCollector taxCollector, LuxuryTax luxuryTax)
        {
            this.taxCollector = taxCollector;
            luxuryTax.LandedOn += LuxuryTaxOnLandedOn;
        }

        private void LuxuryTaxOnLandedOn(object sender, NotifyLandedOnEventArgs eventArgs)
        {
            taxCollector.CollectLuxuryTax(eventArgs.Player);
        }
    }
}