using System;

using Monopoly.Core.Bank;
using Monopoly.Core.Board.Spaces;

namespace Monopoly.Core.Events.Handlers
{
    public class IncomeTaxHandler : SpaceHandler<IncomeTax>
    {
        private readonly ITaxCollector taxCollector;

        public IncomeTaxHandler(ITaxCollector taxCollector, IncomeTax incomeTax)
        {
            this.taxCollector = taxCollector;

            incomeTax.LandedOn += IncomeTaxOnLandedOn;
        }

        private void IncomeTaxOnLandedOn(object sender, NotifyLandedOnEventArgs eventArgs)
        {
            taxCollector.CollectIncomeTax(eventArgs.Player);
        }
    }
}