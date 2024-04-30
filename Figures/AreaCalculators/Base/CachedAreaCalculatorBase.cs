using Figures;
using Figures.Interfaces;
using System.Collections.Concurrent;

namespace Figures.AreaCalculators;

public abstract class CachedAreaCalculatorBase<T> : IAreaCalculator<T> where T : IFigure
{
    private static readonly ConcurrentDictionary<T, double> _cache = new();
    public double GetArea(T entity)
    {
        return _cache.GetOrAdd(entity, CalculateArea);
    }

    protected abstract double CalculateArea(T entity);
}
