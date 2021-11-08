using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Stack.Views
{
    public class StackItemView : UserControl
    {
        public StackItemView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}