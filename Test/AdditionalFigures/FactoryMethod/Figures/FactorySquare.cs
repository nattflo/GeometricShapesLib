using Figures.Interfaces;
using Test.AdditionalFigures.FactoryMethod.AreaCalculators;

namespace Test.AdditionalFigures.FactoryMethod;

public class FactorySquare : IFigure
{
    public readonly double Side;

    private readonly IAreaCalculator<FactorySquare> _calculator;

    public FactorySquare(double side, IAreaCalculator<FactorySquare> calculator)
    {
        if (side <= 0)
            throw new ArgumentException("The side cannot be equal to or less than zero");

        Side = side;
        _calculator = calculator;
    }
    public double CalculateArea() => _calculator.GetArea(this);

    public bool Equals(FactorySquare? obj)
    {
        if(obj == null) return false;

        return Side.Equals(obj.Side);
    }

    public override bool Equals(object? obj) => obj is FactorySquare square && Equals(square);

    public override int GetHashCode() => Side.GetHashCode();
}
