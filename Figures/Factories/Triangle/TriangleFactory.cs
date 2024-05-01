using Figures.AreaCalculators;
using Figures;
using Figures.Interfaces;

namespace Figures.Factories;

public class TriangleFactory : ITriangleFactory
{
    private readonly TriangleAreaCalculator _areaCalculator;

    public TriangleFactory(TriangleAreaCalculator areaCalculator)
    {
        _areaCalculator = areaCalculator;
    }

    public Triangle Create(double a, double b, double c) => new(a, b, c, _areaCalculator);
}
