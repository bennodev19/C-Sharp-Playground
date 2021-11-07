using System;
using System.Windows.Input;
using ReactiveUI;
using Stack.Models;

namespace Stack.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Button callbacks
        public ICommand onPushItem { get; }
        public ICommand onPopItem { get; }

        private string? _itemName;

        public string? itemName
        {
            get => _itemName;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            set => this.RaiseAndSetIfChanged(ref _itemName, value);
        }

        private string? _uiNote;

        public string? uiNote
        {
            get => _uiNote;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            set => this.RaiseAndSetIfChanged(ref _uiNote, value);
        }

        private IntStack stack;

        public MainWindowViewModel()
        {
            stack = new IntStack(10);

            // onPushItem() Button callback
            onPushItem = ReactiveCommand.Create(async () => { this.onPush(); });

            // onPopItem() Button callback
            onPopItem = ReactiveCommand.Create(async () => { this.onPop(); });
        }

        private void onPop()
        {
            try
            {
                // Pop value from Stack
                int poppedValue = this.stack.pop();

                this.setUINote("Sucessfully popped " + poppedValue + "!");
            }
            catch (Exception error)
            {
                this.setUINote(error.Message);
            }
        }

        private void onPush()
        {
            int parsedTextInput;

            // Parse text input
            bool success = int.TryParse(this.itemName, out parsedTextInput);

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
        }

        private void setUINote(string note)
        {
            this.uiNote = "Hinweis: " + note;
        }
    }
}