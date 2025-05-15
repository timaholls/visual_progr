using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FormulaCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Title = "Расчет формулы";
            Width = 500;
            Height = 400;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Основная панель
            Grid grid = new Grid();

            // Создаем RadioButton для выбора формулы (в данном случае только одна формула)
            RadioButton radioButton = new RadioButton
            {
                Content = "Z = ∑∑(sin(x)·x^i + cos(y)·y^j)/(i·j)",
                Margin = new Thickness(5),
                IsChecked = true
            };

            // StackPanel для параметров
            StackPanel parametersPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(10)
            };

            // Создаем элементы для ввода параметров x и y
            Label labelX = new Label { Content = "x:" };
            TextBox textBoxX = new TextBox { Width = 70, Text = "0,00" };
            
            Label labelY = new Label { Content = "y:" };
            TextBox textBoxY = new TextBox { Width = 70, Text = "0,00" };
            
            Label labelN = new Label { Content = "N:" };
            TextBox textBoxN = new TextBox { Width = 70, Text = "5" };
            
            Label labelK = new Label { Content = "K:" };
            TextBox textBoxK = new TextBox { Width = 70, Text = "5" };

            // Добавляем элементы в панель параметров
            parametersPanel.Children.Add(labelX);
            parametersPanel.Children.Add(textBoxX);
            parametersPanel.Children.Add(labelY);
            parametersPanel.Children.Add(textBoxY);
            parametersPanel.Children.Add(labelN);
            parametersPanel.Children.Add(textBoxN);
            parametersPanel.Children.Add(labelK);
            parametersPanel.Children.Add(textBoxK);

            // Создаем кнопку для расчета
            Button calculateButton = new Button
            {
                Content = "Считать",
                Width = 100,
                Height = 30,
                Margin = new Thickness(10)
            };

            // Создаем текстовое поле для отображения результата
            TextBlock resultTextBlock = new TextBlock
            {
                Margin = new Thickness(10),
                TextWrapping = TextWrapping.Wrap
            };

            // Создаем StackPanel для организации элементов интерфейса
            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(radioButton);
            mainPanel.Children.Add(new TextBlock { Text = "Формула: Z = ∑∑(sin(x)·x^i + cos(y)·y^j)/(i·j)", Margin = new Thickness(10, 5, 10, 5) });
            mainPanel.Children.Add(parametersPanel);
            mainPanel.Children.Add(calculateButton);
            mainPanel.Children.Add(resultTextBlock);

            // Добавляем обработчик нажатия кнопки
            calculateButton.Click += (sender, e) =>
            {
                try
                {
                    double x = Convert.ToDouble(textBoxX.Text);
                    double y = Convert.ToDouble(textBoxY.Text);
                    int n = Convert.ToInt32(textBoxN.Text);
                    int k = Convert.ToInt32(textBoxK.Text);

                    double result = CalculateFormula(x, y, n, k);
                    resultTextBlock.Text = $"Ответ: {result:F4}";
                }
                catch (Exception ex)
                {
                    resultTextBlock.Text = $"Ошибка: {ex.Message}";
                }
            };

            grid.Children.Add(mainPanel);
            Content = grid;
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

    public class App : Application
    {
        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.Run(new MainWindow());
        }
    }
}
