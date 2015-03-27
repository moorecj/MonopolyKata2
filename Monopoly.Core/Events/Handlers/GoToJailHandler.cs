using Monopoly.Core.Board.Spaces;
using Monopoly.Core.Players;

namespace Monopoly.Core.Events.Handlers
{
    public class GoToJailHandler : SpaceHandler<GoToJail>
    {
        private readonly IJailer jailer;

        public GoToJailHandler(GoToJail goToJail, IJailer jailer)
        {
            this.jailer = jailer;
            goToJail.LandedOn += (sender, eventArgs) => { this.jailer.LockUp(eventArgs.Player); };
        }
    }
}