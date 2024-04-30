using Figures.AreaCalculators;

namespace Figures.Tests.AreaCalculators;

public class TriangleAreaCalculatorTest
{
    [Fact]
    public void GetArea_ReturnsExcpectedValue()
    {
        var areaCalculator = new TriangleAreaCalculator();
        var circle = new Triangle(areaCalculator, 3, 4, 5);

        var area = areaCalculator.GetArea(circle);

        Assert.Equal(6, area);
    }
}
