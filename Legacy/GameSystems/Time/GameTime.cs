using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameSystems.GameTime
{
    public class GameTime 
    {
        MonoSettings mSettings;
        ScrSettings sSettings;
        public DayTime Current { get; set; }
        public GameTime(MonoSettings mSettings, ScrSettings sSettings)
        {
            this.mSettings = mSettings;
            this.sSettings = sSettings;
        }
        [System.Serializable]
        public class DayTime
        {
            public string name;
            public float lenght;
            public Color lightColor;
        }
        [System.Serializable]
        public class MonoSettings
        {
            public Light directionLight;
            public GameObject watches;
        }
        [System.Serializable]
        public class ScrSettings
        {
            public DayTime[] periods;
        }
    }
}