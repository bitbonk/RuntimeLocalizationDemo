namespace RuntimeLocalizationDemo
{
    using System;
    using System.Globalization;
    using System.Windows.Input;
    using System.Windows.Threading;

    public class MainViewModel : ViewModelBase
    {
        private string ctorText;
        private double width;
        private double height;
        private double top;
        private double left;
        private DateTime time;

        public MainViewModel()
        {
            this.CtorText = Resources.StaticTextInViewModelCtor;
            this.Width = 400;
            this.Height = 400;
            this.Top = 100;
            this.Left = 100;
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += this.TimerOnTick;
            timer.Start();
        }

        public DateTime Time
        {
            get => this.time;
            private set
            {
                if (value.Equals(this.time))
                {
                    return;
                }

                this.time = value;
                this.OnPropertyChanged();
            }
        }

        public double Top
        {
            get => this.top;
            set
            {
                if (value.Equals(this.top))
                {
                    return;
                }

                this.top = value;
                this.OnPropertyChanged();
            }
        }

        public string GetterText => Resources.StaticViewModelTextGetter;

        public double Left
        {
            get => this.left;
            set
            {
                if (value.Equals(this.left))
                {
                    return;
                }

                this.left = value;
                this.OnPropertyChanged();
            }
        }

        public double Width
        {
            get => this.width;
            set
            {
                if (value.Equals(this.width))
                {
                    return;
                }

                this.width = value;
                this.OnPropertyChanged();
            }
        }

        public double Height
        {
            get => this.height;
            set
            {
                if (value.Equals(this.height))
                {
                    return;
                }

                this.height = value;
                this.OnPropertyChanged();
            }
        }

        public string CtorText
        {
            get => this.ctorText;
            set
            {
                if (value == this.ctorText)
                {
                    return;
                }

                this.ctorText = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand SwitchLanguageToDe
        {
            get
            {
                return new RelayCommand(_ => LocaleSwitcher.Instance.Switch(new CultureInfo("de-DE")));
            }
        }

        public ICommand SwitchLanguageToEn
        {
            get
            {
                return new RelayCommand(_ => LocaleSwitcher.Instance.Switch(new CultureInfo("en-US")));
            }
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            this.Time = DateTime.Now;
        }
    }
}