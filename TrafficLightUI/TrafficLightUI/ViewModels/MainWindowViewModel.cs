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
        
        // Traffic Lights
        private string? _topLightColor = "gray";
        public string? topLightColor
        {
            get => _topLightColor;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _topLightColor, value);
        }
        
        private string? _centerLightColor = "gray";
        public string? centerLightColor
        {
            get => _centerLightColor;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _centerLightColor, value);
        }
        
        private string? _bottomLightColor = "gray";
        public string? bottomLightColor
        {
            get => _bottomLightColor;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _bottomLightColor, value);
        }
        
        private TrafficLight trafficLight;

        public MainWindowViewModel()
        {
            trafficLight = new TrafficLight();
                
            // Setup Button callbacks
            this.onStart = ReactiveCommand.Create(async () => { this._onStart(); });
            this.onStop = ReactiveCommand.Create(async () => { this._onStop(); });
            this.onSwitch = ReactiveCommand.Create(async () => { this._onSwitch(); });
        }

        private void _onStart()
        {
            trafficLight.start();
        }
        
        private void _onStop()
        {
            trafficLight.stop();
        }
        
        private void _onSwitch()
        {
            trafficLight.switchStatus();
        }
    }
}