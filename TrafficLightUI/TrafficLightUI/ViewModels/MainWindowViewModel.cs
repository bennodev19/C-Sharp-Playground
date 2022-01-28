using System.Collections.Generic;
using System.Windows.Input;
using Avalonia;
using ReactiveUI;
using TrafficLightUI.Views;

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
            int padding = 5;

            // Create Traffic Lights
            TrafficLight[] trafficLights =
            {
                createTrafficLight("t_N", "r_1", new PixelPoint(0, 190 + padding)),
                createTrafficLight("t_O", "r_2", new PixelPoint(140 + padding, 0)),
                createTrafficLight("t_S", "r_1", new PixelPoint(0, -190 - padding)),
                createTrafficLight("t_W", "r_2", new PixelPoint(-140 - padding, 0))
            };

            // Cross Road switch order
            var switchOrder = new[]
            {
                new CrossRoadStatus(new List<KeyValuePair<string, TrafficLightStatus>>() {
                    new("r_1", TrafficLightStatus.Stop),
                    new("r_2", TrafficLightStatus.Stop),
                }),
                new CrossRoadStatus(new List<KeyValuePair<string, TrafficLightStatus>>()
                {
                    new("r_1", TrafficLightStatus.Prepare),
                    new("r_2", TrafficLightStatus.Stop),
                }),
                new CrossRoadStatus(new List<KeyValuePair<string, TrafficLightStatus>>()
                {
                    new("r_1", TrafficLightStatus.Go),
                    new("r_2", TrafficLightStatus.Stop),
                }),
                new CrossRoadStatus(new List<KeyValuePair<string, TrafficLightStatus>>()
                {
                    new("r_1", TrafficLightStatus.Warning),
                    new("r_2", TrafficLightStatus.Stop),
                }),
                new CrossRoadStatus(new List<KeyValuePair<string, TrafficLightStatus>>()
                {
                    new("r_1", TrafficLightStatus.Stop),
                    new("r_2", TrafficLightStatus.Stop),
                }),
                new CrossRoadStatus(new List<KeyValuePair<string, TrafficLightStatus>>()
                {
                    new("r_1", TrafficLightStatus.Stop),
                    new("r_2", TrafficLightStatus.Prepare),
                }),
                new CrossRoadStatus(new List<KeyValuePair<string, TrafficLightStatus>>()
                {
                    new("r_1", TrafficLightStatus.Stop),
                    new("r_2", TrafficLightStatus.Go),
                }),
                new CrossRoadStatus(new List<KeyValuePair<string, TrafficLightStatus>>()
                {
                    new("r_1", TrafficLightStatus.Stop),
                    new("r_2", TrafficLightStatus.Warning),
                }),
            };
            
            // Create Cross Road
            crossRoad = new CrossRoad(trafficLights, switchOrder);

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

        private TrafficLight createTrafficLight(string id, string trafficLightRowId, PixelPoint position)
        {
            // Create TrafficLight ViewModel
            TrafficLightViewModel trafficLightViewModel = new TrafficLightViewModel(id, trafficLightRowId);

            // Create TrafficLight Window
            TrafficLightWindow trafficLightWindow = new TrafficLightWindow();
            trafficLightWindow.Show();
            trafficLightWindow.DataContext = trafficLightViewModel;
            trafficLightWindow.Position = new PixelPoint(trafficLightWindow.Position.X + position.X,
                trafficLightWindow.Position.Y + position.Y);

            return trafficLightViewModel.trafficLight;
        }

        // ===============================================================
        // UI-Callbacks
        // ===============================================================

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

            this.crossRoad.switchStatus();
        }

        private void _onAutomatic()
        {
            resetUINote();

            crossRoad.toggleAutomatic();
        }
    }
}