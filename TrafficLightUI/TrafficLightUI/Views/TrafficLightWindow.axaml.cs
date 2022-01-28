using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TrafficLightUI.Views
{
    public class TrafficLightWindow : Window
    {
        public TrafficLightWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}