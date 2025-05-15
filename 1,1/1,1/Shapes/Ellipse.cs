using System;

namespace Shapes
{
    // Класс для эллипса
    public class Ellipse : Shape
    {
        // Большая и малая полуоси эллипса
        private double majorAxis;
        private double minorAxis;

        // Конструктор с вызовом базового конструктора
        public Ellipse(double majorAxis, double minorAxis) : base("Эллипс")
        {
            this.majorAxis = majorAxis;
            this.minorAxis = minorAxis;
        }

        // Переопределение метода вычисления площади
        public override double CalculateArea()
        {
            // Площадь эллипса = π * a * b
            return Math.PI * majorAxis * minorAxis;
        }

        // Переопределение метода вычисления периметра
        public override double CalculatePerimeter()
        {
            // Приближённая формула для периметра эллипса
            // P ≈ 2π * √((a² + b²)/2)
            return 2 * Math.PI * Math.Sqrt((majorAxis * majorAxis + minorAxis * minorAxis) / 2);
        }

        // Переопределение метода вывода информации
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Большая полуось: {majorAxis:F2}");
            Console.WriteLine($"Малая полуось: {minorAxis:F2}");
        }
    }
} 