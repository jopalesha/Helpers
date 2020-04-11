using Xunit;

namespace Jopalesha.Helpers.Tests
{
    public class EnumerableHelperTests
    {
        [Fact]
        public void GetCombinations_ReturnsExpected()
        {
            var list1 = new[] {1, 2, 3};
            var list2 = new[] {4, 5, 6};

            var actual = EnumerableHelper.GetCombinations(new[] {list1, list2});
            var expected = new[]
            {
                new[] {1, 4}, new[] {1, 5}, new[] {1, 6},
                new[] {2, 4}, new[] {2, 5}, new[] {2, 6},
                new[] {3, 4}, new[] {3, 5}, new[] {3, 6}
            };

            Assert.Equal(expected, actual);
        }
    }
}
