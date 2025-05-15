using System;
using System.Windows;

namespace _3
{
    public partial class Task2_1 : Window
    {
        public Task2_1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получение значений из текстовых полей
                double x = Convert.ToDouble(TextBoxX.Text);
                double y = Convert.ToDouble(TextBoxY.Text);
                int n = Convert.ToInt32(TextBoxN.Text);
                int k = Convert.ToInt32(TextBoxK.Text);

                // Выполнение расчёта
                double result = CalculateFormula(x, y, n, k);
                
                // Вывод результата
                ResultTextBlock.Text = $"Ответ: {result:F4}";
            }
            catch (FormatException)
            {
                ResultTextBlock.Text = "Ошибка: Неверный формат ввода. Проверьте введенные данные.";
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
            }
        }

        // Метод для расчета формулы Z = ∑∑(sin(x)·x^i + cos(y)·y^j)/(i·j)
        private double CalculateFormula(double x, double y, int n, int k)
        {
            double result = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    // sin(x)·x^i + cos(y)·y^j
                    double numerator = Math.Sin(x) * Math.Pow(x, i) + Math.Cos(y) * Math.Pow(y, j);
                    
                    // i·j
                    double denominator = i * j;
                    
                    result += numerator / denominator;
                }
            }

            return result;
        }
    }
}