namespace Monopoly.Core.Extensions
{
    public static class IntExtensions
    {
        public static bool IsBetween(this int number, int lower, int upper, bool inclusive = true)
        {
            return inclusive
                ? lower <= number && number <= upper
                : lower < number && number < upper;
        }
    }
}