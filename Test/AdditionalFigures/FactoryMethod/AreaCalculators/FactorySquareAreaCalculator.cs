using Figures.Interfaces;

namespace Test.AdditionalFigures.FactoryMethod.AreaCalculators;

internal class FactorySquareAreaCalculator : IAreaCalculator<FactorySquare>
{
    public double GetArea(FactorySquare entity)
    {
        return entity.Side * entity.Side;
    }
}
