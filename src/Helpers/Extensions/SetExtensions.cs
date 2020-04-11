using System.Collections.Generic;
using Jopalesha.CheckWhenDoIt;

namespace Jopalesha.Helpers.Extensions
{
    public static class SetExtensions
    {
        public static void AddRange<T>(this ISet<T> set, IEnumerable<T> items)
        {
            foreach (var item in Check.NotEmpty(items))
            {
                set.Add(item);
            }
        }
    }
}
