using Figures;

namespace Figures.AreaCalculators;

public class CircleAreaCalculator : CachedAreaCalculatorBase<Circle>
{
    protected override double CalculateArea(Circle entity) => Math.PI * Math.Pow(entity.Radius, 2);
}
