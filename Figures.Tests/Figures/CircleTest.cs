using Figures;
using Figures.AreaCalculators;

namespace Figures.Tests
{
    public class CircleTest
    {
        private readonly CircleAreaCalculator _calculator = new();

        [Theory]
        [InlineData(-1, "Radius cannot be equal to or less than zero")]
        [InlineData(0, "Radius cannot be equal to or less than zero")]
        public void Ctor_RadiusIsZeroOrLess_ThrowsArgumentException(double radius, string expectedExceptionMessage)
        { 
            var exception = Assert.Throws<ArgumentException>(() => new Circle(radius, _calculator));

            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void Equals_CircleWithSameRadius_ReturnTrue()
        {
            var circle1 = new Circle(1, _calculator);
            var circle2 = new Circle(1, _calculator);

            Assert.True(circle1.Equals(circle2));
        }

        [Fact]
        public void Equals_CircleWithDifferentRadius_ReturnFalse()
        {
            var circle1 = new Circle(1, _calculator);
            var circle2 = new Circle(2, _calculator);

            Assert.False(circle1.Equals(circle2));
        }

    }
}