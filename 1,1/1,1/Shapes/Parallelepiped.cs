using System;

namespace Shapes
{
    // Класс для параллелепипеда
    public class Parallelepiped : Shape
    {
        // Длина, ширина и высота параллелепипеда
        private double length;
        private double width;
        private double height;

        // Конструктор с вызовом базового конструктора
        public Parallelepiped(double length, double width, double height) : base("Параллелепипед")
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        // Переопределение метода вычисления площади
        public override double CalculateArea()
        {
            // Площадь поверхности параллелепипеда = 2(ab + bc + ac)
            return 2 * (length * width + width * height + length * height);
        }

        // Переопределение метода вычисления периметра
        public override double CalculatePerimeter()
        {
            // Сумма всех рёбер параллелепипеда = 4(a + b + c)
            return 4 * (length + width + height);
        }

        // Использование виртуального метода без переопределения
        // Используем базовую реализацию DisplayInfo
    }
} 