using System.Collections;

namespace Jopalesha.Helpers.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty(this IEnumerable items) =>
            items == null ||
            (items as ICollection)?.Count == 0 ||
            !items.GetEnumerator().MoveNext();
    }
}
