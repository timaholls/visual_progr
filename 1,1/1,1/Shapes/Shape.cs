using System;

namespace Shapes
{
    // Базовый абстрактный класс для геометрических фигур
    public abstract class Shape : IShape
    {
        // Название фигуры
        protected string Name { get; set; }

        // Конструктор базового класса
        protected Shape(string name)
        {
            Name = name;
        }

        // Виртуальный метод для вывода информации о фигуре
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"\nФигура: {Name}");
            Console.WriteLine($"Площадь: {CalculateArea():F2}");
            Console.WriteLine($"Периметр: {CalculatePerimeter():F2}");
        }

        // Абстрактные методы, которые должны быть реализованы в наследниках
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
} 