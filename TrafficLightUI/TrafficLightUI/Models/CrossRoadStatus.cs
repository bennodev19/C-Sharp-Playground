using System.Collections.Generic;

namespace TrafficLightUI
{
    public class CrossRoadStatus
    {
        // key = TrafficLightId or SwitchRowId | value = TrafficLightStatus
        public List<KeyValuePair<string, TrafficLightStatus>> status = new List<KeyValuePair<string, TrafficLightStatus>>();

        public CrossRoadStatus(List<KeyValuePair<string, TrafficLightStatus>> status)
        {
            this.status = status;
        }
    }
}