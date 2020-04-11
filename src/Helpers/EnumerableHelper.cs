using System.Collections.Generic;
using System.Linq;
using Jopalesha.CheckWhenDoIt;

namespace Jopalesha.Helpers
{
    public static class EnumerableHelper
    {
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<IEnumerable<T>> value)
        {
            var collections = Check.NotNull(value).ToList();
            if (collections.Count == 1)
            {
                foreach (var item in collections.Single())
                    yield return new List<T> {item};
            }
            else if (collections.Count > 1)
            {
                foreach (var item in collections.First())
                foreach (var tail in GetCombinations(collections.Skip(1)))
                    yield return new[] {item}.Concat(tail);
            }
        }
    }
}
