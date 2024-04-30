using Figures.AreaCalculators;
using Figures.Interfaces;

namespace Figures;

public class Circle: IFigure
{
    public readonly double Radius;
    private readonly IAreaCalculator<Circle> _calculator;

    //Конструктор для фабрики
    public Circle(IAreaCalculator<Circle> calculator, double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius cannot be equal to or less than zero");

        _calculator = calculator;
        Radius = radius;
    }

    //Конструктор для простого использования класса
    public Circle(double radius) : this(new CircleAreaCalculator(), radius) { }

    public double CalculateArea() => _calculator.GetArea(this);

    //Нужен, чтобы убрать unbox при обращении к переопределённому методу Equals
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
