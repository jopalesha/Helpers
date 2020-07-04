using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Jopalesha.CheckWhenDoIt;

namespace Jopalesha.Helpers.Structures
{
    public class UniqueConcurrentQueue<T> : ConcurrentQueue<T>
    {
        private readonly IEqualityComparer<T> _comparer;

        public UniqueConcurrentQueue() : this(EqualityComparer<T>.Default)
        {
        }

        public UniqueConcurrentQueue(IEqualityComparer<T> comparer)
        {
            _comparer = Check.NotNull(comparer);
        }

        public new void Enqueue(T item)
        {
            if (!this.Contains(item, _comparer))
            {
                base.Enqueue(item);
            }
        }
    }
}
