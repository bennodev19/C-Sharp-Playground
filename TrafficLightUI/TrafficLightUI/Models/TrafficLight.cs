using System;
using System.Threading.Tasks;

namespace TrafficLightUI
{
    public class TrafficLight
    {
        // Key/Name identifier of the TrafficLight
        public string id;
        
        // Key/Name identifier of the switch row the Traffic Light belongs to
        // (A switch row specifies Traffic Lights that should always have the same status)
        public string? switchRowId;
        
        // Current active TrafficLight Status
        private TrafficLightStatus _currentStatus;
        private TrafficLightStatus currentStatus
        {
            get { return _currentStatus; }
            set
            {
                this.trafficLightCallback(value);
                _currentStatus = value;
            }
        }

        // Order of Status that can be taken by an active Traffic Light
        private TrafficLightStatus[] statusOrder = new TrafficLightStatus[]
            {TrafficLightStatus.Stop, TrafficLightStatus.Prepare, TrafficLightStatus.Go, TrafficLightStatus.Warning};

        // Callback to apply changes to the UI
        private Action<TrafficLightStatus> trafficLightCallback;

        public TrafficLight(string id, Action<TrafficLightStatus> trafficLightCallback, string? switchRowId)
        {
            this.id = id;
            this.switchRowId = switchRowId;
            this.trafficLightCallback = trafficLightCallback;
            this.currentStatus = TrafficLightStatus.Off;
        }

        public string start()
        {
            if (this.currentStatus == TrafficLightStatus.Off)
            {
                this.switchToStatus(TrafficLightStatus.Standby);
            }
            else if (this.currentStatus == TrafficLightStatus.Standby)
            {
                this.switchToStatus(TrafficLightStatus.Stop);
            }
            else
            {
                Console.WriteLine("Traffic Light is already up and running!");
                return "Traffic Light is already up and running!";
            }

            return null;
        }

        public string stop()
        {
            if (this.currentStatus != TrafficLightStatus.Off && this.currentStatus != TrafficLightStatus.Standby)
            {
                this.switchToStatus(TrafficLightStatus.Standby);
            }
            else if (this.currentStatus == TrafficLightStatus.Standby)
            {
                this.switchToStatus(TrafficLightStatus.Off);
            }
            else
            {
                Console.WriteLine("Traffic Light is already offline!");
                return "Traffic Light is already offline!";
            }

            return null;
        }

        public TrafficLightStatus switchStatus()
        {
            TrafficLightStatus nextStatus;

            // Handle special case if Traffic Light is off or in standby
            if (currentStatus == TrafficLightStatus.Off || currentStatus == TrafficLightStatus.Standby)
            {
                nextStatus = this.statusOrder[0];
            }
            // Handle normal case and get next status based on the 'statusOrder'
            else
            {
                int currentStatusIndex =
                    Array.FindIndex(this.statusOrder, status => status == this.currentStatus);

                // Find next Status index
                int nextStatusIndex = 0;
                if ((currentStatusIndex + 1) < this.statusOrder.Length)
                {
                    nextStatusIndex = currentStatusIndex + 1;
                }

                nextStatus = this.statusOrder[nextStatusIndex];
            }

            // Switch Status
            this.switchToStatus(nextStatus);
            return nextStatus;
        }

        public async void switchToStatus(TrafficLightStatus status)
        {
            // Handle special Status 'Standby'
            if (status == TrafficLightStatus.Standby)
            {
                // Set Light to 'Stop' before switching to Standby
                // in order to not confuse driver
                if (this.currentStatus != TrafficLightStatus.Off && this.currentStatus != TrafficLightStatus.Standby)
                {
                    this.switchToStatus(TrafficLightStatus.Stop);
                    await Task.Delay(5000); // Sleep
                }

                this.currentStatus = TrafficLightStatus.Standby;
            }

            // Handle special Status 'Off'
            if (status == TrafficLightStatus.Off)
            {
                // Set Light to 'Standby' before turning the Traffic Light off
                // in order to not confuse driver
                if (this.currentStatus != TrafficLightStatus.Standby)
                {
                    this.switchToStatus(TrafficLightStatus.Standby);
                    await Task.Delay(5000); // Sleep
                }

                this.currentStatus = TrafficLightStatus.Off;
            }

            // Handle other Status
            if (Array.FindIndex(this.statusOrder, s => s == status) != -1)
            {
                this.currentStatus = status;
            }
        }

        public TrafficLightStatus getCurrentStatus()
        {
            return this.currentStatus;
        }

        public string getEnumName(TrafficLightStatus value)
        {
            return Enum.GetName(typeof(TrafficLightStatus), value);
        }
    }
}