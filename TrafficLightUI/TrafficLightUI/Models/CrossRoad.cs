using System;
using Avalonia.Threading;

namespace TrafficLightUI
{
    public class CrossRoad
    {
        private DispatcherTimer timer;
        private TrafficLight trafficLight;

        public bool isAutomatic
        {
            get { return this.timer.IsEnabled; }
            set { }
        }

        public CrossRoad(TrafficLight trafficLight)
        {
            this.trafficLight = trafficLight;

            // Instantiate Timer
            this.timer = new DispatcherTimer();
            this.timer.Tick += new EventHandler(onTick);
            this.timer.Interval = new TimeSpan(0, 0, 1);
        }

        public void toggleAutomatic()
        {
            if (this.timer.IsEnabled)
            {
                this.timer.Stop();
            }
            else
            {
                this.timer.Start();
            }
        }

        private void onTick(object sender, EventArgs e)
        {
            this.trafficLight.switchStatus();
        }

        public string start()
        {
            string error = null;

            if (!isAutomatic)
            {
                error = this.trafficLight.start();
            }
            else
            {
                error = "Crossing is already up and running!";
            }
            
            return error;
        }

        public string stop()
        {
            string error = null;

            if (!isAutomatic)
            {
                error = this.trafficLight.stop(); 
            }
            else
            {
                error = "Crossing road can only be stopped if automatic is disabled!";
            }

            return error;
        }

        public void manualSwitch()
        {
            this.trafficLight.switchStatus();
        }
    }
}