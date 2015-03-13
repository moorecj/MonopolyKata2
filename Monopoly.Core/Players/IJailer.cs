namespace Monopoly.Core.Players
{
    public interface IJailer
    {
        void LockUp(Player player);
        void Release(Player player);
        bool HasPrisoner(Player player);
    }
}