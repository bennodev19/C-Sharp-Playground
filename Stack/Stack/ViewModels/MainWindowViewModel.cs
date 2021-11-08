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
        
        private string? _uiNoteColor;

        public string? uiNoteColor
        {
            get => _uiNoteColor;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _uiNoteColor, value);
        }
        

        private IntStack stack;

        public ObservableCollection<StackItemViewModel> Items { get; } = new();

        public MainWindowViewModel()
        {
            stack = new IntStack(10);

            // Fill UI-Stack with UI-Items
            foreach (var i in stack.toArray())
            {
                Items.Add(new StackItemViewModel(null));
            }

            // onPushItem() Button callback
            this.onPushItem = ReactiveCommand.Create(async () => { this.onPush(); });

            // onPopItem() Button callback
            this.onPopItem = ReactiveCommand.Create(async () => { this.onPop(); });
            
            // Initial render UI-Stack                
            this.updateUIStack();
        }

        private void onPop()
        {
            try
            {
                // Pop value from Stack
                int poppedValue = this.stack.pop();
                
                this.setUINote("Successfully popped " + poppedValue + "!", "success");
                this.updateUIStack();
            }
            catch (Exception error)
            {
                this.setUINote(error.Message, "error");
            }
        }

        private void onPush()
        {
            int parsedTextInput;

            // Parse text input
            bool success = int.TryParse(this.itemName, out parsedTextInput);
            
            // Clear text input
            this.itemName = String.Empty;

            if (success)
            {
                // Push value into Stack
                success = this.stack.push(parsedTextInput);

                if (success)
               {
                   this.setUINote("Successfully added " + parsedTextInput + "!", "success");
               } 
                else
                {
                    this.setUINote("Stack Overflow!", "warning");
                }
                this.updateUIStack();
            }
            else
            {
                this.setUINote("Invalid input provided", "error");
            }
        }

        private void setUINote(string note, string type)
        {
            this.uiNote = "Note: " + note;

            // Update uiNote color
            switch (type)
            {
               case "error":
                   uiNoteColor = "red";
                   break;
               case "success":
                   uiNoteColor = "green";
                   break;
               case "warning":
                   uiNoteColor = "yellow";
                   break;
               default:
                   uiNoteColor = "black";
                   break;
            }
        }

        private void updateUIStack()
        {
            var stackArray = this.stack.toArray();

            // Fill Elements
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].fillColor = i < this.stack.size ? "green" : "gray";
                this.Items[i].value = i < this.stack.size ? stackArray[i] : null;
            }
        }
    }
}