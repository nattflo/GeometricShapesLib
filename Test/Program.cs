using Figures.Figures;
using Test.AdditionalFigures;

var triangle = new Triangle(3,4,5);
var square = new Square(5);
Console.WriteLine($"Square of the square = {square.GetSquare()}");
Console.WriteLine($"Triangle is right = {triangle.IsTriangleRight()}");
Console.ReadKey();