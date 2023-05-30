using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
using Containment;

namespace GameSystems.GameEvent
{
    public enum ConflictLevel
    {
        PEACE,
        SUPPRESS,
        FATAL
    }
    public class TestEventManager : MonoBehaviour
    {
        public static event System.Action<Agent> OnCriminal;
        public ConflictLevel globalConflictLevel;
        public ManualAgent player;
        public void Criminal()
        {
            OnCriminal?.Invoke(player);
        }
        public void CriminalFound(Agent agent,Zone zone)
        {
            OnCriminal?.Invoke(agent);
        }
    }
}
