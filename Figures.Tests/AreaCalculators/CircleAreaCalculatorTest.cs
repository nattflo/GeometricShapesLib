using Figures.AreaCalculators;

namespace Figures.Tests.AreaCalculators;

public class CircleAreaCalculatorTest
{
    [Fact]
    public void GetArea_ReturnsExcpectedValue()
    {
        var areaCalculator = new CircleAreaCalculator();
        var circle = new Circle(1, areaCalculator);

        var area = areaCalculator.GetArea(circle);

        Assert.Equal(Math.PI * 1, area);
    }
}
