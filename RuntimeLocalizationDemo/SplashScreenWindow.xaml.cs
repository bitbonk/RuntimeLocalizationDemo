namespace RuntimeLocalizationDemo
{
    using System;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow
    {
        public SplashScreenWindow()
        {
            this.InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            LocaleSwitcher.Instance.ShowMainWindow();
            
        }
    }
}