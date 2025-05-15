using System;

namespace Shapes
{
    // Класс для ромба
    public class Rhombus : Shape
    {
        // Длина стороны ромба
        private double side;
        // Острый угол ромба в градусах
        private double angle;

        // Конструктор с вызовом базового конструктора
        public Rhombus(double side, double angle) : base("Ромб")
        {
            this.side = side;
            this.angle = angle;
        }

        // Переопределение метода вычисления площади
        public override double CalculateArea()
        {
            // Площадь ромба = a² * sin(α)
            return side * side * Math.Sin(angle * Math.PI / 180);
        }

        // Переопределение метода вычисления периметра
        public override double CalculatePerimeter()
        {
            // Периметр ромба = 4a
            return 4 * side;
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Сторона: {side:F2}");
            Console.WriteLine($"Угол: {angle:F2}°");
        }
    }
} 