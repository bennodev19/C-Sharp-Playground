using System.Threading.Tasks;
using ReactiveUI;

namespace TrafficLightUI.ViewModels
{
    public class TrafficLightViewModel : ViewModelBase
    {
        // Traffic Lights (Note: Lights of the Traffic Light)
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

        // Traffic Light
        public TrafficLight trafficLight;
        private bool isStandby = false;

        public TrafficLightViewModel()
        {
            this.trafficLight = new TrafficLight(this.handleTrafficLightStatus);
        }

        private async void handleTrafficLightStatus(TrafficLightStatus status)
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
    }
}