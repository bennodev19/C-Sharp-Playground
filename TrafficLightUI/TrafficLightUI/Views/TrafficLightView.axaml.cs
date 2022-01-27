using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TrafficLightUI.Views
{
    public class TrafficLightView : UserControl
    {
        public TrafficLightView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}