using Figures.Figures;

namespace Figures.Tests
{
    public class CircleTest
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void CircleCtor_BadData_ThrowsArgumentException(double radius)
        {
            Assert.Throws<ArgumentException>(() => new Circle(radius));
        }


        [Fact]
        public void GetSquare_5_Returns78_53981633974483()
        {
            var radius = 5;
            var circle = new Circle(radius);
            var expected = Math.PI * Math.Pow(radius, 2);

            var square = circle.GetSquare();

            Assert.Equal(expected, square);
        }
    }
}