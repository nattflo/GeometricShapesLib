using Figures.Interfaces;

namespace Test.AdditionalFigures
{
    public class Square : IFigure
    {
        public double Side { get; private set; }
        public Square(double side)
        {
            if (side <= 0)
                throw new ArgumentException("The side cannot be equal to or less than zero");
            Side = side;
        }

        public double GetSquare()
        {
            return Side * Side;
        }
    }
}
