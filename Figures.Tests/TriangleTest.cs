using Figures.Figures;

namespace Figures.Tests
{
    public class TriangleTest
    {
        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 1, -1)]
        [InlineData(0, 0, 0)]
        public void TriangleCtor_BadData_ThrowsArgumentException(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
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
        public void TriangleCtor_1and1and4_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(1, 1, 4));
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