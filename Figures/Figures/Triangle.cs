using Figures.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Figures
{
    public class Triangle : IFigure
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }


        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Sides of the triangle cannot be equal to or less than zero");

            var longestSide = Math.Max(sideA, Math.Max(sideB, sideC));
            if(longestSide > (sideA + sideB + sideC - longestSide))
                throw new ArgumentException("The longest side of the triangle must be less than the sum of the other sides");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }
        public bool IsTriangleRight()
        {
            var longestSide = Math.Max(SideA, Math.Max(SideB, SideC));
            return Math.Pow(longestSide, 2) == Math.Pow(SideA, 2) + Math.Pow(SideB, 2) + Math.Pow(SideC, 2) - Math.Pow(longestSide, 2);
        }

        public double GetSquare()
        {
            var halfPerimeter = (SideA + SideB + SideC)/2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
        }
    }
}
