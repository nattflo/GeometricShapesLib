using Figures.AreaCalculators;

namespace Figures.Tests.AreaCalculators;

public class TriangleAreaCalculatorTest
{
    [Fact]
    public void GetArea_ReturnsExcpectedValue()
    {
        var areaCalculator = new TriangleAreaCalculator();
        var circle = new Triangle(3, 4, 5, areaCalculator);

        var area = areaCalculator.GetArea(circle);

        Assert.Equal(6, area);
    }
}
