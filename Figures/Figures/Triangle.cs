using Figures.Interfaces;

namespace Figures.Figures;

public sealed class Triangle : IFigure
{
    public readonly double SideA;
    public readonly double SideB;
    public readonly double SideC;
    public readonly bool IsTriangleRight;

    private readonly Lazy<double> _area;


    public Triangle(double sideA, double sideB, double sideC)
    {
        if (!IsValidTriangle(sideA, sideB, sideC))
            throw new ArgumentException("Invalid triangle sides");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        IsTriangleRight = CalculateIsRightTriangle();

        _area = new Lazy<double>(GetArea());
    }

    private static bool IsValidTriangle(double sideA, double sideB, double sideC)
    {
        return sideA > 0 && sideB > 0 && sideC > 0 &&
               sideA + sideB > sideC &&
               sideA + sideC > sideB &&
               sideB + sideC > sideA;
    }
    private double GetArea()
    {
        var halfPerimeter = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
    }
    private bool CalculateIsRightTriangle()
    {
        double[] sidesSquared = { SideA * SideA, SideB * SideB, SideC * SideC };
        Array.Sort(sidesSquared);
        return sidesSquared[2] == sidesSquared[0] + sidesSquared[1];
    }

    public double CalculateArea() => _area.Value;
}
