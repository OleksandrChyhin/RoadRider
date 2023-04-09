using System;
using System.Collections.Generic;

namespace RoadRiderClient.Shared.Extensions
{
    public static class ICollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                collection.Add(item);
            }
        }

        public static void Remove<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    collection.Remove(item);
                }
            }
        }
    }
}
