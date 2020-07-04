using System;
using Jopalesha.Helpers.Structures;
using Xunit;

namespace Jopalesha.Helpers.Tests
{
    public class UniqueConcurrentQueueTests
    {
        [Fact]
        public void Enqueue_DoesNotAddDuplicateItem()
        {
            var sut = new UniqueConcurrentQueue<int>();
            sut.Enqueue(1);
            sut.Enqueue(1);

            Assert.Single(sut);
        }

        [Fact]
        public void Enqueue_Class_DoesNotAddDuplicateItem()
        {
            var sut = new UniqueConcurrentQueue<TestClass>();
            sut.Enqueue(new TestClass("value"));
            sut.Enqueue(new TestClass("value"));

            Assert.Single(sut);
        }

        [Fact]
        public void Enqueue_WithComparer_DoesNotAddDuplicateItem()
        {
            var sut = new UniqueConcurrentQueue<string>(StringComparer.OrdinalIgnoreCase);
            sut.Enqueue("value");
            sut.Enqueue("Value");

            Assert.Single(sut);
        }

        private class TestClass : IEquatable<TestClass>
        {
            private readonly string _value;

            public TestClass(string value)
            {
                _value = value;
            }

            public bool Equals(TestClass other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return _value == other._value;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((TestClass) obj);
            }

            public override int GetHashCode()
            {
                return (_value != null ? _value.GetHashCode() : 0);
            }
        }
    }
}
