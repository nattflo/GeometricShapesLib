# GeometricShapesLib
Это тестовое задание.
## Преимущества библиотеки
- Два вариант использования библиотеки: простой и сложный
- По умолчанию есть кэширование калькуляции у встроенных фигур, и возможность использования кэширования при наследовании от CachedAreaCalculatorBase
- Наличие unit тестов
- Соблюдение приципов SOLID, ООП
- Оптимизация калькуляции площади треугольника
- Возможность изменить калькуляцию площади встроенных фигур

## Способы использования
Библиотека представляет два разных подхода к использованию фигур из неё:

### Простой способ
Суть простого способа состоит в простом создании фигуры через конструтор. Добавления новых фигур для такого варианта производятся очень просто - нужно реализовать интерфейс IFigure в нужном классе.
Этот вариант не предоставляет возможности изменения калькуляции встроенных фигур из библиотеки.
```csharp
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
```

### Сложный способ
Но с другой стороны есть более правильный и гибкий вариант использования библиотеке. Для этого понадобиться DI, чтобы регистрировать фабрики для фигур и калькуляторы для калькуляции их площадей.
В этом варианте есть возможность полного изменения логики калькуляции площадей.
Чтобы добавить создать фигуру в этом варианте нужно:
- Унаследовать класс от IFigure, реализовать его и переопределить equals и GetHashCode.
```csharp
public class Square : IFigure
{
    public readonly double Side;

    private readonly IAreaCalculator<Square> _calculator;

    public Square(double side, IAreaCalculator<Square> calculator)
    {
        if (side <= 0)
            throw new ArgumentException("The side cannot be equal to or less than zero");

        Side = side;
        _calculator = calculator;
    }
    public double CalculateArea() => _calculator.GetArea(this);
}
```
- Калькуляции площади реализовать в классе, реализующем IAreaCalculator или использовать унаследоваться от CachedAreaCalculatorBase. Во втором случае будет нативное кэширование.
```csharp
public class SquareAreaCalculator : IAreaCalculator<Square>
{
    public double GetArea(Square entity)
    {
        return entity.Side * entity.Side;
    }
}
```
- Создать интерфейс фабрики и реализовать саму фабрику, которая будет получать через конструктор IAreaCalculator<T> определённого типа.
```csharp
public interface ISquareFactory
{
    FactorySquare Create(double side);
}

public class SquareFactory : ISquareFactory
{
    private readonly IAreaCalculator<Square> _calculator;

    public SquareFactory(IAreaCalculator<Square> calculator)
    {
        _calculator = calculator;
    }

    public Square Create(double side) => new(side, _calculator);
}
```
- Зарегистрировать в DI калькуляторы и фабрики
