using Figures.Figures;

namespace Figures.Tests
{
    public class TriangleTest
    {

        [Theory]
        [InlineData(0, 0, 0, "Invalid triangle sides")]
        [InlineData(1, 1, 5, "Invalid triangle sides")]
        [InlineData(-1, 1, 5, "Invalid triangle sides")]
        public void TriangleCtor_InvalidSides_ThrowsArgumentException(double a, double b, double c, string expectedExceptionMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));

            Assert.Equal(exception.Message, expectedExceptionMessage);
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
        public void CalculateArea_3and4and5_Returns6()
        {

            var a = 3;
            var b = 4;
            var c = 5;
            var expected = 6d;
            var triangle = new Triangle(a, b, c);

            var square = triangle?.CalculateArea();

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