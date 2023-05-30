using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
using GameSystems;

namespace Containment
{
    public class Zone : MonoBehaviour
    {
        Crime Crime;
        public bool access;
        public List<Agent> agents = new List<Agent>();
        public string crime;
        //event System.Action<Agent, Zone> OnIntrusion;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out Agent agent))
            {
                if((agent is ISlave slave))
                {
                    slave.SModule.CrimeCommitted(Crime);
                }
            }
        }
        //private void Start()
        //{
        //    Crime = SettingsManager.Instance.crimeCodex.crimeDict[crime];
        //    //OnIntrusion += GameSystems.GameEvent.TestEventManager.Instance.CriminalFound;
        //}
    }
}