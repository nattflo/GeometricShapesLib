namespace Figures.Interfaces;

public interface IAreaCalculator<T> where T : IFigure
{
    double GetArea(T entity);
}
