using Figures;
using Figures.Interfaces;

namespace Figures.Factories;

public class CircleFactory : ICircleFactory
{
    private readonly IAreaCalculator<Circle> _calculator;
    public CircleFactory(IAreaCalculator<Circle> calculator)
    {
        _calculator = calculator;
    }

    public Circle Create(double radius) => new(radius, _calculator);
}
