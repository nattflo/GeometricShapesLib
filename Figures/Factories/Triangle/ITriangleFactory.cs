using Figures;

namespace Figures.Factories;

public interface ITriangleFactory
{
    Triangle Create(double a, double b, double c);
}
