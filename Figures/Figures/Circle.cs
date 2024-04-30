using Figures.Interfaces;

namespace Figures.Figures;

public class Circle: IFigure
{
    public readonly double Radius;
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius cannot be equal to or less than zero");

        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}
