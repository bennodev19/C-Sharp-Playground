using System;
using System.Collections.ObjectModel;
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
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _itemName, value);
        }

        private string? _uiNote;

        public string? uiNote
        {
            get => _uiNote;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _uiNote, value);
        }

        private IntStack stack;

        public ObservableCollection<StackItemViewModel> Items { get; } = new();

        public MainWindowViewModel()
        {
            stack = new IntStack(10);

            // Fill Stack with Items
            foreach (var i in stack.toArray())
            {
                Items.Add(new StackItemViewModel(null));
            }

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
                
                this.updateUIStack();
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
                this.setUINote("Sucessfully added " + parsedTextInput + "!");
                
                this.updateUIStack();
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

        private void updateUIStack()
        {
            int stackFillCount = this.stack.count();

            // Fill Elements
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].value = this.stack.toArray()[i];
            }
        }
    }
}