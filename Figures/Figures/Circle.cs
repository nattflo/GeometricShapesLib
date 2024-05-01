using Figures.AreaCalculators;
using Figures.Interfaces;

namespace Figures;

public class Circle: IFigure
{
    public readonly double Radius;
    private readonly IAreaCalculator<Circle> _calculator;

    //Конструктор с значением по-умолчанию для удобной работы, если не хочется создавать фабрику
    public Circle(double radius, IAreaCalculator<Circle>? calculator = null)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius cannot be equal to or less than zero");

        _calculator = calculator ?? new CircleAreaCalculator();
        Radius = radius;
    }

    public double CalculateArea() => _calculator.GetArea(this);

    public bool Equals(Circle? obj)
    {
        if(obj == null) return false;

        return Radius == obj.Radius;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj is Circle)
            return false;

        return Equals(obj as Circle);
    }

    //Нужен, чтобы использовать в Dictionary в качестве ключа
    public override int GetHashCode()
    {
        return Radius.GetHashCode();
    }
}
