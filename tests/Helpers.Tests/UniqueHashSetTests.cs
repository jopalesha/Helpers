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
            Assert.Throws<ArgumentException>(() => new UniqueHashSet<int> { 1 }.Add(1));
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
    }
}
