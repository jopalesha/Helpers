using System;
using Jopalesha.Helpers.Structures;
using Xunit;

namespace Jopalesha.Helpers.Tests
{
    public class UniqueHashSetTests
    {
        [Fact]
        public void Add_SameItem_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new UniqueHashSet<int> {1}.Add(1));
        }

        [Fact]
        public void Add_SameClassItem_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new UniqueHashSet<TestClass>() {new TestClass("value")}.Add(new TestClass("value")));
        }

        [Fact]
        public void Initialization_WithSameItems_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new UniqueHashSet<int> {1, 1});
        }

        [Fact]
        public void Constructor_WithSameItems_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new UniqueHashSet<int>(new[] {1, 1}));
        }

        [Fact]
        public void Constructor_WithComparer_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new UniqueHashSet<string>(StringComparer.OrdinalIgnoreCase) {"a", "A"}
            );
        }

        private class TestClass : IEquatable<TestClass>
        {
            public TestClass(string value)
            {
                Value = value;
            }

            public string Value { get; }


            public bool Equals(TestClass other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Value == other.Value;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((TestClass) obj);
            }

            public override int GetHashCode()
            {
                return (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}
