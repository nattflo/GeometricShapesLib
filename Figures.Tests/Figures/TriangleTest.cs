using Figures;
using Figures.AreaCalculators;

namespace Figures.Tests
{
    public class TriangleTest
    {
        private readonly TriangleAreaCalculator _calculator = new();

        [Theory]
        [InlineData(0, 0, 0, "Invalid triangle sides")]
        [InlineData(1, 1, 5, "Invalid triangle sides")]
        [InlineData(-1, 1, 5, "Invalid triangle sides")]
        public void Ctor_InvalidSides_ThrowsArgumentException(double a, double b, double c, string expectedExceptionMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(a, b, c, _calculator));

            Assert.Equal(exception.Message, expectedExceptionMessage);
        }

        [Fact]
        public void Ctor_3and4and5_TriangleIsRight()
        {

            var triangle = new Triangle(3, 4, 5, _calculator);

            Assert.True(triangle.IsTriangleRight);
        }

        [Fact]
        public void Ctor_3and4and4_TriangleIsNotRight()
        {
            var triangle = new Triangle(3, 4, 4, _calculator);

            Assert.False(triangle.IsTriangleRight);
        }

        [Fact]
        public void Equals_TrianglesWithSameSidesButDifferentOrder_ReturnTrue()
        {
            var triangle1 = new Triangle(3, 4, 5, _calculator);
            var triangle2 = new Triangle(5, 4, 3, _calculator);

            Assert.True(triangle1.Equals(triangle2));
        }

        [Fact]
        public void Equals_DifferentTriangles_ReturnFalse()
        {
            var triangle1 = new Triangle(3, 4, 5, _calculator);
            var triangle2 = new Triangle(3, 4, 4, _calculator);

            Assert.False(triangle1.Equals(triangle2));
        }
    }
}