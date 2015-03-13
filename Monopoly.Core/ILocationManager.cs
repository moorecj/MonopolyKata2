using Monopoly.Core.Players;

namespace Monopoly.Core
{
    public interface ILocationManager
    {
        int GetLocation(Player player);

        void Move(Player player, int number);

        void MoveTo(Player player, int location);
    }
}