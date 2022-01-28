using System;
using Avalonia.Threading;

namespace TrafficLightUI
{
    public class CrossRoad
    {
        private DispatcherTimer timer;
        private TrafficLight[] trafficLights;

        public bool isAutomatic
        {
            get { return this.timer.IsEnabled; }
            set { }
        }

        public CrossRoad(TrafficLight[] trafficLights)
        {
            this.trafficLights = trafficLights;

            // Instantiate Timer
            this.timer = new DispatcherTimer();
            this.timer.Tick += new EventHandler(onTick);
            this.timer.Interval = new TimeSpan(0, 0, 1); // TODO update speed
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
            this.switchStatus();
        }

        public string start()
        {
            string error = null;

            if (!isAutomatic)
            {
                foreach (var trafficLight in this.trafficLights)
                {
                    trafficLight.start();
                    if (error != null) break;
                }
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
                foreach (var trafficLight in this.trafficLights)
                {
                    error = trafficLight.stop();
                    if(error != null) break;
                }
            }
            else
            {
                error = "Crossing road can only be stopped if automatic is disabled!";
            }

            return error;
        }

        public void switchStatus()
        {
            // TODO
        }
    }
}