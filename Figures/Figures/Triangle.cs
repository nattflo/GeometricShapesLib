using Figures.AreaCalculators;
using Figures.Interfaces;

namespace Figures;

public sealed class Triangle : IFigure
{
    public readonly double SideA;
    public readonly double SideB;
    public readonly double SideC;
    public readonly bool IsTriangleRight;

    private readonly IAreaCalculator<Triangle> _calculator;


    //Конструктор с значением по-умолчанию для удобной работы, если не хочется создавать фабрику
    public Triangle(double sideA, double sideB, double sideC, IAreaCalculator<Triangle>? calculator = null)
    {
        if (!IsValidTriangle(sideA, sideB, sideC))
            throw new ArgumentException("Invalid triangle sides");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        _calculator = calculator?? new TriangleAreaCalculator();

        IsTriangleRight = CalculateIsRightTriangle();
    }

    public double CalculateArea() => _calculator.GetArea(this);

    public bool Equals(Triangle? other)
    {
        if (other == null) return false;

        var otherHashSet = new HashSet<double>() { other.SideA, other.SideB, other.SideC };
        var thisHashSet = new HashSet<double>() { SideA, SideB, SideC };

        return otherHashSet.SetEquals(thisHashSet);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is Triangle)
            return false;

        return Equals(obj as Triangle);
    }

    //Нужен, чтобы использовать в Dictionary в качестве ключа
    public override int GetHashCode()
    {
        var hashSet = new HashSet<double>() { SideA, SideB, SideC };
        return hashSet.GetHashCode();
    }

    private static bool IsValidTriangle(double sideA, double sideB, double sideC)
    {
        return sideA > 0 && sideB > 0 && sideC > 0 &&
               sideA + sideB > sideC &&
               sideA + sideC > sideB &&
               sideB + sideC > sideA;
    }
    private bool CalculateIsRightTriangle()
    {
        double[] sidesSquared = { SideA * SideA, SideB * SideB, SideC * SideC };
        Array.Sort(sidesSquared);
        return sidesSquared[2] == sidesSquared[0] + sidesSquared[1];
    }
}
