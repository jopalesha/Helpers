using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Jopalesha.Helpers.Extensions
{
    public static class ConcurrentDictionaryExtensions
    {
        public static void AddRange<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary,
            IEnumerable<(TKey, TValue)> values)
        {
            foreach (var (key, value) in values)
            {
                dictionary.TryAdd(key, value);
            }
        }
    }
}