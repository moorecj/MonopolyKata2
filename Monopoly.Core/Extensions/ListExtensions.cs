using System.Collections.Generic;

namespace Monopoly.Core.Extensions
{
    public static class ListExtensions
    {
        public static void Replace<T>(this IList<T> list, T originalItem, T newItem)
        {
            if (list.Contains(originalItem) == false) return;

            list.Remove(originalItem);
            list.Add(newItem);
        }
    }
}