using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems.GameTime;
using Units;


namespace GameSystems.GameEvent
{
    public class EventStorage
    {
        public List<EventInfo> events = new List<EventInfo>();
        public string CreateJson()
        {
            string[] jsons = new string[events.Count];
            for (int i = 0; i < events.Count; i++)
            {
                EventInfoJson eventInfo = new EventInfoJson(events[i]);
                string json = JsonUtility.ToJson(eventInfo);
                jsons[i] = json;
            }
            return string.Join("_", jsons);
        }
    }
    [System.Serializable]
    public class Event
    {
        public string name;
        

    }
    [System.Serializable]
    public class EventInfo
    {
        public string name;
        public DateTime time;
        public Agent agent;
    }
    [System.Serializable]
    public class EventInfoJson
    {
        public string name;
        public string time;
        public string agent;
        public EventInfoJson(EventInfo info)
        {
            name = info.name;
            agent = info.agent.name;
        }
    }

}