using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using Jopalesha.CheckWhenDoIt;

namespace Jopalesha.Helpers.Structures
{
    /// <summary>
    /// HashSet, which throws exception on existed item
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    [Serializable]
    public class UniqueHashSet<T> : ISet<T>, ISerializable, IDeserializationCallback
    {
        private readonly HashSet<T> _hashSet = new HashSet<T>();

        public UniqueHashSet()
        {
        }

        public UniqueHashSet(IEqualityComparer<T> comparer) : this(Enumerable.Empty<T>(), comparer)
        {
        }

        public UniqueHashSet(IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default)
        {
        }

        public UniqueHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        {
            _hashSet = new HashSet<T>(Check.NotNull(comparer, nameof(comparer)));

            foreach (var item in Check.NotNull(collection, nameof(collection)))
            {
                Add(item);
            }
        }

        protected UniqueHashSet(SerializationInfo info, StreamingContext context)
        {
            _hashSet = new HashSet<T>();

            var iSerializable = (ISerializable)_hashSet;
            iSerializable.GetObjectData(info, context);
        }


        public IEnumerator<T> GetEnumerator() => _hashSet.GetEnumerator();

        public void OnDeserialization(object sender) => _hashSet.OnDeserialization(sender);

        public void GetObjectData(SerializationInfo info, StreamingContext context) => _hashSet.GetObjectData(info, context);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T item)
        {
            if (!_hashSet.Add(item))
            {
                throw new ArgumentException("The item already exists");
            }
        }

        public void UnionWith(IEnumerable<T> other)
        {
            _hashSet.UnionWith(other);
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            _hashSet.IntersectWith(other);
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            _hashSet.ExceptWith(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            _hashSet.SymmetricExceptWith(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return _hashSet.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return _hashSet.IsSupersetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return _hashSet.IsProperSupersetOf(other);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return _hashSet.IsProperSubsetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return _hashSet.Overlaps(other);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return _hashSet.SetEquals(other);
        }

        bool ISet<T>.Add(T item)
        {
            Add(item);
            return true;
        }

        public void Clear()
        {
            _hashSet.Clear();
        }

        public bool Contains(T item)
        {
            return _hashSet.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _hashSet.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _hashSet.Remove(item);
        }

        public int Count => _hashSet.Count;

        public bool IsReadOnly => false;
    }
}
