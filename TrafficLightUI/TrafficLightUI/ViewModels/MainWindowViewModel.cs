using System.Windows.Input;
using ReactiveUI;

namespace TrafficLightUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Button callbacks
        public ICommand onStart { get; }
        public ICommand onStop { get; }
        public ICommand onSwitch { get; }
        public ICommand onAutomatic { get; }

        // UI
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

        // Traffic Light
        private CrossRoad crossRoad;
        private bool isStandby = false;

        public MainWindowViewModel()
        {
            // TODO show traffic window in separate window (https://docs.avaloniaui.net/tutorials/music-store-app/opening-a-dialog)
            TrafficLightWindowViewModel trafficLight = new TrafficLightWindowViewModel();
            crossRoad = new CrossRoad(trafficLight);

            // Setup Button callbacks
            this.onStart = ReactiveCommand.Create(async () => { this._onStart(); });
            this.onStop = ReactiveCommand.Create(async () => { this._onStop(); });
            this.onSwitch = ReactiveCommand.Create(async () => { this._onSwitch(); });
            this.onAutomatic = ReactiveCommand.Create(async () => { this._onAutomatic(); });
        }

        private void setUINote(string note, string? type)
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

        private void resetUINote()
        {
            this._uiNote = "";
        }

        private void _onStart()
        {
            resetUINote();

            string error = this.crossRoad.start();
            if (error != null) this.setUINote(error, "error");
        }

        private void _onStop()
        {
            resetUINote();

            string error = this.crossRoad.stop();
            if (error != null) this.setUINote(error, "error");
        }

        private void _onSwitch()
        {
            resetUINote();

            this.crossRoad.manualSwitch();
        }

        private void _onAutomatic()
        {
            resetUINote();

            crossRoad.toggleAutomatic();
        }
    }
}