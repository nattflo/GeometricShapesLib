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
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(_calculator, a, b, c));

            Assert.Equal(exception.Message, expectedExceptionMessage);
        }

        [Fact]
        public void Ctor_3and4and5_TriangleIsRight()
        {

            var triangle = new Triangle(_calculator, 3, 4, 5);

            Assert.True(triangle.IsTriangleRight);
        }

        [Fact]
        public void Ctor_3and4and4_TriangleIsNotRight()
        {
            var triangle = new Triangle(_calculator, 3, 4, 4);

            Assert.False(triangle.IsTriangleRight);
        }

        [Fact]
        public void Equals_TrianglesWithSameSidesButDifferentOrder_ReturnTrue()
        {
            var triangle1 = new Triangle(_calculator, 3, 4, 5);
            var triangle2 = new Triangle(_calculator, 5, 4, 3);

            Assert.True(triangle1.Equals(triangle2));
        }

        [Fact]
        public void Equals_DifferentTriangles_ReturnFalse()
        {
            var triangle1 = new Triangle(_calculator, 3, 4, 5);
            var triangle2 = new Triangle(_calculator, 3, 4, 4);

            Assert.False(triangle1.Equals(triangle2));
        }
    }
}