using Figures;
using Figures.AreaCalculators;
using Figures.Factories;
using Figures.Interfaces;
using Test.AdditionalFigures;
using Test.AdditionalFigures.FactoryMethod.AreaCalculators;
using Test.AdditionalFigures.FactoryMethod.Factories;

//В библиотеке представлено два способа её использования:

//ПРОСТОЕ
//Мы просто создаём фигуру через конструктор, но здесь теряется вся гибкость системы
var triangle = new Triangle(3,4,5);

Console.WriteLine("---Creating Triangle---");
Console.WriteLine($"Triangle is right = {triangle.IsTriangleRight}");

//ПРАВИЛЬНОЕ
//В этом варианте больше гибкости, но и сложность кода немного возрастает
//В своём примере я просто создаю фабрику и калькулятор, лучше использовать DI
var factory = new TriangleFactory(new TriangleAreaCalculator());
var trianleFromFactory = factory.Create(3, 4, 4);

Console.WriteLine("---Creating Triangle In Factory Method---");
Console.WriteLine($"Triangle is right = {trianleFromFactory.IsTriangleRight}");



//Пример ЛЁГКОГО, но негибкого добавления новых фигур
var square = new Square(5);

Console.WriteLine("---Creating Square---");
Console.WriteLine($"Area of the square = {square.CalculateArea()}");

//Пример ПРАВИЛЬНОГО добавления новых фигур
// Для этого нужно создать фабрику и её интерфейс
// калькулятор площади квадрата
// и сам квадрат, который получает в ctor калькулятор
// В этом примере я тоже не буду использовать DI
var squareFactory = new FactorySquareFactory(new FactorySquareAreaCalculator());
var factorySquare = squareFactory.Create(3);

Console.WriteLine("---Creating Square In Factory Method---");
Console.WriteLine($"Area of the square = {factorySquare.CalculateArea()}");



//Создание фигуры и сохранение с инкапсупляцией
IFigure figure = new Circle(5);
//Благодаря наличию функции CalculateArea в IFigure, мы может узнать площадь фигуры
//даже несмотря на сокрытие от нас реализации данного метода при помощи инкапсуляции

Console.WriteLine("---Creating Circle---");
Console.WriteLine($"Area of the figure = {figure.CalculateArea()}");
Console.ReadLine();