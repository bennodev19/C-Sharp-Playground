using System.Threading.Tasks;
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
        private bool isStandby = false;

        public MainWindowViewModel()
        {
            trafficLight = new TrafficLight(this.handleTrafficLightLight);
                
            // Setup Button callbacks
            this.onStart = ReactiveCommand.Create(async () => { this._onStart(); });
            this.onStop = ReactiveCommand.Create(async () => { this._onStop(); });
            this.onSwitch = ReactiveCommand.Create(async () => { this._onSwitch(); });
            this.onAutomatic = ReactiveCommand.Create(async () => { this._onAutomatic(); });
        }

        private async void handleTrafficLightLight(TrafficLightStatus status)
        {
            if (status == TrafficLightStatus.Off)
            {
                this.topLightColor = "gray";
                this.centerLightColor = "gray";
                this.bottomLightColor = "gray";
            }
            
            if (status == TrafficLightStatus.Standby)
            {
                this.isStandby = true;
                this.handleStandby();
            }
            else
            {
                this.isStandby = false;
            }
            
            if (status == TrafficLightStatus.Stop)
            {
                this.topLightColor = "red";
                this.centerLightColor = "gray";
                this.bottomLightColor = "gray";
            }
            
            if (status == TrafficLightStatus.Prepare)
            {
                this.topLightColor = "red";
                this.centerLightColor = "yellow";
                this.bottomLightColor = "gray";
            }
            
            if (status == TrafficLightStatus.Go)
            {
                this.topLightColor = "gray";
                this.centerLightColor = "gray";
                this.bottomLightColor = "green";
            }
            
            if (status == TrafficLightStatus.Warning)
            {
                this.topLightColor = "gray";
                this.centerLightColor = "yellow";
                this.bottomLightColor = "gray";
            }
        }

        private async void handleStandby()
        {
            this.topLightColor = "gray";
            this.centerLightColor = "yellow"; 
            this.bottomLightColor = "gray";
            
            // Blink yellow
            bool light = true;
            while (this.isStandby)
            {
                if (light)
                {
                    this.centerLightColor = "yellow"; 
                }
                else
                {
                    this.centerLightColor = "gray";
                }
                await Task.Delay(1000); // Sleep
                light = !light;
            }
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

        private void _onAutomatic()
        {
            // TODO
        }
    }
}