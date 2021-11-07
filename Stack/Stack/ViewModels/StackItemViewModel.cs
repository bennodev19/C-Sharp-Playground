using ReactiveUI;

namespace Stack.ViewModels
{
    public class StackItemViewModel : ViewModelBase
    {
        private int? _value;

        public int? value
        {
            get => _value;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set
            {
                this._fillColor = value != null ? "green" : "gray";
                this.RaiseAndSetIfChanged(ref _value, value);
            }
        }

        private string? _fillColor = "gray";

        public string? fillColor
        {
            get => _fillColor;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _fillColor, value);
        }

        public bool isFilled => this.value != null;

        public StackItemViewModel(int? value)
        {
            this.value = value;
        }
    }
}