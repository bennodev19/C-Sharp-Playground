using System.Threading;

namespace TrafficLight
{
    public class TrafficLight
    {
        private TrafficLightStatus status;

        private TrafficLightStatus[] statusOrder = new[]
            {TrafficLightStatus.Stop, TrafficLightStatus.Prepare, TrafficLightStatus.Go, TrafficLightStatus.Warning};

        public TrafficLight()
        {
            this.status = TrafficLightStatus.Off;
        }

        public void start()
        {
            this.switchToStatus(TrafficLightStatus.Standby);
        }

        public void stop()
        {
           this.switchToStatus(TrafficLightStatus.Off);
        }

        public void switchStatus()
        {
            // TODO find current status
            // TODO switch to following status
            TrafficLightStatus nextStats = TrafficLightStatus.Go;
            
            this.switchToStatus(nextStats);
        }

        public void switchToStatus(TrafficLightStatus status)
        {
            if (status == TrafficLightStatus.Standby)
            {
                this.switchToStatus(TrafficLightStatus.Stop);
                // TODO sleep 10s
                this.status = TrafficLightStatus.Standby;
            }

            if (status == TrafficLightStatus.Off)
            {
                this.switchToStatus(TrafficLightStatus.Standby);
                // TODO sleep 10s
                this.status = TrafficLightStatus.Off;
            }
            
            // TODO 
        }
    }
}