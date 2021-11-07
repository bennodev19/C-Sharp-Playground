using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.MusicStore.ViewModels;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace Avalonia.MusicStore.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            // Cleans up any subscriptions when this View is not on the screen
            this.WhenActivated(d => d(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync)));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        // Show 'MusicStoreWindow' modal
        // https://docs.avaloniaui.net/tutorials/music-store-app/opening-a-dialog
        private async Task DoShowDialogAsync(InteractionContext<MusicStoreViewModel, AlbumViewModel?> interaction)
        {
            var dialog = new MusicStoreWindow();
            dialog.DataContext = interaction.Input;
            var result = await dialog.ShowDialog<AlbumViewModel?>(this);
            interaction.SetOutput(result);
        }
    }
}