using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TrafficLightUI.Views
{
    public partial class MainWindow : Window // ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        // TODO open separate window/dialog with a TrafficLight in it
        // https://docs.avaloniaui.net/tutorials/music-store-app/opening-a-dialog
        // private async Task DoShowDialogAsync()
        // {
        //     var dialog = new TrafficLightWindow();
        //     await dialog.ShowDialog(this);
        // }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}