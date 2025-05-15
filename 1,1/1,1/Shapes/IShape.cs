using System;

namespace Shapes
{
    // Интерфейс для геометрических фигур
    public interface IShape
    {
        double CalculateArea(); // Вычисление площади
        double CalculatePerimeter(); // Вычисление периметра
        void DisplayInfo(); // Вывод информации о фигуре
    }
} 