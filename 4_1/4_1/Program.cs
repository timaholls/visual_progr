using System;
using System.Windows;
using _4_1.View;

namespace _4_1
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new Application();
            app.StartupUri = new Uri("View/MainWindow.xaml", UriKind.Relative);
            app.Run();
        }
    }
}
