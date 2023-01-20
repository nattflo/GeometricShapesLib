using Figures.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Figures
{
    public class Circle: IFigure
    {
        public double Radius { get; private set; }
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius cannot be equal to or less than zero");


            Radius = radius;
        }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
