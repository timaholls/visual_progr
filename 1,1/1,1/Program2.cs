using System;
using Shapes;

class Program2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Демонстрация работы с геометрическими фигурами\n");

        // Создание объектов разных фигур
        var rhombus = new Rhombus(5, 60);
        var parallelepiped = new Parallelepiped(4, 3, 5);
        var ellipse = new Ellipse(6, 4);

        // Создание массива фигур для демонстрации полиморфизма
        IShape[] shapes = { rhombus, parallelepiped, ellipse };

        // Демонстрация работы методов для каждой фигуры
        foreach (var shape in shapes)
        {
            shape.DisplayInfo();
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
} 