namespace RuntimeLocalizationDemo
{
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Windows;
    using System.Windows.Markup;

    public class LocaleSwitcher
    {
        private MainWindow currentMainWindow;

        public static LocaleSwitcher Instance { get; } = new LocaleSwitcher();

        public void ShowMainWindow()
        {
            this.currentMainWindow = new MainWindow { DataContext = new MainViewModel() };
            this.currentMainWindow.Show();
            Application.Current.Windows.OfType<SplashScreenWindow>().Single().WindowState = WindowState.Minimized;
        }

        public void Switch(CultureInfo locale)
        {
            var dataContext = this.currentMainWindow.DataContext;
            this.currentMainWindow.Close();
            Thread.CurrentThread.CurrentCulture = locale;
            Thread.CurrentThread.CurrentUICulture = locale;
            var newMainWindow = new MainWindow
            {
                DataContext = dataContext,
                Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)
            };

            this.currentMainWindow = newMainWindow;
            this.currentMainWindow.Show();
        }
    }
}