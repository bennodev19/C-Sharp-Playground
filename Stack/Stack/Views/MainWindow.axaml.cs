using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Stack.Views
{
    public partial class MainWindow : Window
    {
        private string currentTextInput = "12";
        private IntStack stack;

        // UI
        private TextBlock NoteTxt;
        Rectangle[] uiStacks;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            
            // Read Reactangles from UI
            // this.uiStacks = new Rectangle[] { this.Find<Rectangle>(""), stackElement1, stackElement2, stackElement3, stackElement4, stackElement5 };

            this.NoteTxt = this.Find<TextBlock>("noteText");

            this.stack = new IntStack(10);

            this.updateUIStack();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        public void onPopBtnClicked(object sender, RoutedEventArgs args)
        {
            try
            {
                // Pop value from Stack
                int poppedValue = this.stack.pop();

                setUINote("Sucessfully popped " + poppedValue + "!");
            }
            catch (Exception error)
            {
                this.setUINote(error.Message);
            }

            this.updateUIStack();
        }

        public void onPushBtnClicked(object sender, RoutedEventArgs args)
        {
            int parsedTextInput;

            // Parse text input
            bool success = int.TryParse(currentTextInput, out parsedTextInput);

            if (success)
            {
                // Push value into Stack
                this.stack.push(parsedTextInput);
                this.setUINote("Sucessfully parsed " + parsedTextInput + "!");
            }
            else
            {
                this.setUINote("Invalid input provided");
            }

            this.updateUIStack();
        }
        
        private void setUINote(string note)
        {
            this.NoteTxt.Text = "Hinweis: " + note;
        }

        private void updateUIStack()
        {
            int stackFillCount = this.stack.count();

            // Fill Elements
            for (int i = 0; i < this.uiStacks.Length; i++)
            {
                this.uiStacks[i].Fill = i <= stackFillCount ? Brushes.Red : Brushes.Green;
            }
        }
    }
}
