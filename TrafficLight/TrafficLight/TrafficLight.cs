using System;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class TrafficLight
    {
        private TrafficLightStatus currentStatus;

        // Order of Statuses that can actually be displayed by a Traffic Light that is active
        private TrafficLightStatus[] statusOrder = new TrafficLightStatus[] 
            {TrafficLightStatus.Stop, TrafficLightStatus.Prepare, TrafficLightStatus.Go, TrafficLightStatus.Warning};

        public TrafficLight()
        {
            this.currentStatus = TrafficLightStatus.Off;
        }

        public void start()
        {
            this.switchToStatus(TrafficLightStatus.Standby);
        }

        public void stop()
        {
           this.switchToStatus(TrafficLightStatus.Off);
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
                this.switchToStatus(TrafficLightStatus.Stop);
                await Task.Delay(2000); // Sleep
                this.currentStatus = TrafficLightStatus.Standby;
            }

            // Handle special Status 'Off'
            if (status == TrafficLightStatus.Off)
            {
                this.switchToStatus(TrafficLightStatus.Standby);
                await Task.Delay(2000); // Sleep
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