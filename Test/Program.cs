﻿using Figures.Figures;
using Figures.Interfaces;
using Test.AdditionalFigures;

//Простое создание фигуры и сохранение в переменную без инкапсуляции
var triangle = new Triangle(3,4,5);
Console.WriteLine("---Creating Triangle---");
Console.WriteLine($"Triangle is right = {triangle.IsTriangleRight}");

//Создание фигуры и сохранение с инкапсупляцией
IFigure figure = new Circle(5);
//Благодаря наличию функции CalculateArea в IFigure, мы может узнать площадь фигуры
//даже несмотря на сокрытие от нас реализации данного метода при помощи инкапсуляции
Console.WriteLine("---Creating Circle---");
Console.WriteLine($"Area of the figure = {figure.CalculateArea()}");

//Пример лёгкого добавления новых фигур
var square = new Square(5);

Console.WriteLine("---Creating Square---");
Console.WriteLine($"Area of the square = {square.CalculateArea()}");
Console.ReadLine();