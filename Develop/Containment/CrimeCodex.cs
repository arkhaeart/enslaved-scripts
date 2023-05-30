using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Containment {
    [System.Serializable]
    public class CrimeCodex 
    {

        Settings settings;
        public CrimeCodex(Settings settings)
        {
            this.settings = settings;
        }
        List<LawStatus> statuses;
        public Dictionary<string, Crime> crimeDict = new Dictionary<string, Crime>();
        public string[] crimeStrings;
        public void Init()
        {
            foreach(var crime in settings.crimes)
            {
                if(!crimeDict.ContainsValue(crime))
                {
                    crimeDict.Add(crime.name, crime);
                }
            }
            Debug.Log(crimeDict.Count);
            crimeStrings = GetCrimes();
            InitLawStatuses();
        }
        string[] GetCrimes()
        {
            return crimeDict.Keys.ToArray();
        }
        public LawStatus GetLawStatus(int severity)
        {
            for (int i = 0; i < settings.statuses.Length; i++)
            {
                if (settings.statuses[i].severityCap <= severity)
                    continue;
                else
                    return settings.statuses[i];
            }
            return settings.statuses.Last();
        }
        void InitLawStatuses()
        {
            for (int i = 0; i < statuses.Count; i++)
            {
                if (i - 1 >= 0)
                    statuses[i].Previous = statuses[i - 1];
                if (i + 1 < statuses.Count)
                    statuses[i].Next = statuses[i + 1];
            }
        }
        [System.Serializable]
    public class Settings
    {
        public LawStatus[] statuses;
        public Crime[] crimes;
    }
    }

    [System.Serializable]
    public class LawStatus
    {
        public string name;
        public int severityCap;
        public LawStatus Previous, Next;
    }

}