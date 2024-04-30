using Figures;

namespace Figures.AreaCalculators;

public class TriangleAreaCalculator : CachedAreaCalculatorBase<Triangle>
{
    protected override double CalculateArea(Triangle entity)
    {
        var halfPerimeter = (entity.SideA + entity.SideB + entity.SideC) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - entity.SideA) * (halfPerimeter - entity.SideB) * (halfPerimeter - entity.SideC));
    }
}
