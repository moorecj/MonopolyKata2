using Monopoly.Core.Bank.Properties;
using Monopoly.Core.Board.Spaces;

namespace Monopoly.Core.Events.Handlers
{
    public class PropertySpaceHandler : SpaceHandler<PropertySpace>
    {
        private readonly IRealtor realtor;

        public PropertySpaceHandler(IRealtor realtor, PropertySpace propertySpace)
        {
            this.realtor = realtor;
            propertySpace.LandedOn += PropertySpaceOnLandedOn;
        }

        private void PropertySpaceOnLandedOn(object sender, NotifyLandedOnEventArgs eventArgs)
        {
            realtor.Buy(eventArgs.Space as PropertySpace, eventArgs.Player);
        }
    }
}