using Figures.Interfaces;

namespace Test.AdditionalFigures.FactoryMethod.Factories;

public class FactorySquareFactory : IFactorySquareFactory
{
    private readonly IAreaCalculator<FactorySquare> _calculator;

    public FactorySquareFactory(IAreaCalculator<FactorySquare> calculator)
    {
        _calculator = calculator;
    }

    public FactorySquare Create(double side) => new(side, _calculator);
}
