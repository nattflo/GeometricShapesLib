using Figures.Interfaces;

namespace Test.AdditionalFigures;

public class Square : IFigure
{
    public readonly double Side;

    public Square(double side)
    {
        if (side <= 0)
            throw new ArgumentException("The side cannot be equal to or less than zero");

        Side = side;
    }

    public double CalculateArea()
    {
        return Side * Side;
    }
}
