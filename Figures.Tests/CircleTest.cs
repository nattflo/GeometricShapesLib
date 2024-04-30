using Figures.Figures;

namespace Figures.Tests
{
    public class CircleTest
    {
        [Theory]
        [InlineData(-1, "Radius cannot be equal to or less than zero")]
        [InlineData(0, "Radius cannot be equal to or less than zero")]
        public void CircleCtor_RadiusIsZeroOrLess_ThrowsArgumentException(double radius, string expectedExceptionMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Circle(radius));

            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void CircleCtor_WhenRadiusIsPositive_CreatingCircleWithSpecifiedRadius()
        {
            var radius = 5;

            var circle = new Circle(radius);

            Assert.Equal(radius, circle.Radius);
        }


        [Fact]
        public void CalculateArea_5_Returns78_53981633974483()
        {
            var radius = 5;
            var circle = new Circle(radius);
            var expected = Math.PI * Math.Pow(radius, 2);

            var square = circle.CalculateArea();

            Assert.Equal(expected, square);
        }
    }
}