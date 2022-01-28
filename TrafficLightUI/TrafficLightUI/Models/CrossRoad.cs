using System;
using Avalonia.Threading;
using DynamicData;

namespace TrafficLightUI
{
    public class CrossRoad
    {
        private DispatcherTimer timer;
        
        // TrafficLights the Cross Road contains
        private TrafficLight[] trafficLights;
        
        // Order of Status that can be taken by an active Cross Road
        private CrossRoadStatus[] statusOrder;
        
        // Current active Cross Road Status
        private CrossRoadStatus currentStatus;

        public bool isAutomatic
        {
            get { return this.timer.IsEnabled; }
            set { }
        }

        public CrossRoad(TrafficLight[] trafficLights, CrossRoadStatus[] statusOrder)
        {
            this.trafficLights = trafficLights;
            this.statusOrder = statusOrder;

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
                // Start all Traffic Lights
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
                // Stop all Traffic Lights
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
            CrossRoadStatus nextStatus = null;
            
            // Handle initial Cross Road Status
            if (this.currentStatus == null)
            {
                nextStatus = this.statusOrder[0];
            }
            else
            // Handle next Cross Road Status based on the 'statusOrder'
            {
                int currentStatusIndex = this.statusOrder.IndexOf(this.currentStatus);
                if (currentStatusIndex == this.statusOrder.Length - 1)
                {
                    nextStatus = this.statusOrder[0];
                }
                else
                {
                    nextStatus = this.statusOrder[currentStatusIndex + 1];
                }
            }
            
            // Apply next Cross Road Status to the Traffic Lights
            nextStatus.status.ForEach((status) =>
            {
                foreach (var trafficLight in this.trafficLights)
                {
                    if (trafficLight.id == status.Key || trafficLight.switchRowId == status.Key)
                    {
                        trafficLight.switchToStatus(status.Value);
                    }
                }
            });
            
            this.currentStatus = nextStatus;
        }
    }
}