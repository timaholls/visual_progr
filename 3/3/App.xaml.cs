using System;
using System.Windows;

namespace _3
{
    public partial class App : Application
    {
        public App()
        {
            // Добавляем обработчик необработанных исключений
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // Показываем сообщение об ошибке
            MessageBox.Show($"Произошла ошибка: {e.Exception.Message}\n\nStackTrace: {e.Exception.StackTrace}", 
                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            
            // Помечаем исключение как обработанное
            e.Handled = true;
        }
    }
} 