using Figures.Figures;

namespace Figures.Tests
{
    public class TriangleTest
    {

        [Theory]
        [InlineData(0, 0, 0, "Sides of the triangle cannot be equal to or less than zero")]
        [InlineData(0, 0, 1, "Sides of the triangle cannot be equal to or less than zero")]
        [InlineData(0, 1, 0, "Sides of the triangle cannot be equal to or less than zero")]
        [InlineData(0, 1, 1, "Sides of the triangle cannot be equal to or less than zero")]
        [InlineData(1, 0, 0, "Sides of the triangle cannot be equal to or less than zero")]
        [InlineData(1, 0, 1, "Sides of the triangle cannot be equal to or less than zero")]
        [InlineData(1, 1, 0, "Sides of the triangle cannot be equal to or less than zero")]
        public void TriangleCtor_OneOrMoreSidesAreZero_ThrowsArgumentException(double a, double b, double c, string expectedExceptionMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));

            Assert.Equal(exception.Message, expectedExceptionMessage);
        }

        [Theory]
        [InlineData(1, 1, 5, "The longest side of the triangle must be less than the sum of the other sides")]
        [InlineData(1, 5, 1, "The longest side of the triangle must be less than the sum of the other sides")]
        [InlineData(5, 1, 1, "The longest side of the triangle must be less than the sum of the other sides")]
        public void TriangleCtor_LongestSideLessIsGreaterThanTheSumOfOtherTwo_ThrowsArgumentException(double a, double b, double c, string expectedExceptionMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));

            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void TriangleCtor_CheckSides()
        {
            var a = 3;
            var b = 4;
            var c = 5;

            var triangle = new Triangle(a, b, c);

            Assert.NotNull(triangle);
            Assert.Equal(a,triangle.SideA);
            Assert.Equal(b,triangle.SideB);
            Assert.Equal(c,triangle.SideC);
        }

        [Fact]
        public void GetSquare_3and4and5_Returns6()
        {

            var a = 3;
            var b = 4;
            var c = 5;
            var expected = 6d;
            var triangle = new Triangle(a, b, c);

            var square = triangle?.GetSquare();

            Assert.NotNull(square);
            Assert.Equal(expected, square);
        }

        [Fact]
        public void TriangleCtor_3and4and5_TriangleIsRight()
        {

            var a = 3;
            var b = 4;
            var c = 5;
            var triangle = new Triangle(a, b, c);

            Assert.True(triangle.IsTriangleRight);
        }

        [Fact]
        public void TriangleCtor_3and4and4_TriangleIsNotRight()
        {

            var a = 3;
            var b = 4;
            var c = 4;
            var triangle = new Triangle(a, b, c);

            Assert.False(triangle.IsTriangleRight);
        }
    }
}