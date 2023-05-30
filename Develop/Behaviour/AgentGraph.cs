using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Develop
{
    public interface IAgentGraph
    {
        void AddAgent(Collider collider, IAgent agent);
        void RemoveAgent(Collider collider, IAgent agent);
        bool TryGetAgent(Collider collider, out IAgent agent);
    }

    public class sAgentGraph : IAgentGraph
    {
        private Dictionary<Collider, IAgent> agentsDict;
        private HashSet<IAgent> agents;

        public void AddAgent(Collider collider, IAgent agent)
        {
            agentsDict.TryAdd(collider, agent);
        }

        public void RemoveAgent(Collider collider, IAgent agent)
        {
            agentsDict.Remove(collider);
        }

        public bool TryGetAgent(Collider collider, out IAgent agent) => agentsDict.TryGetValue(collider, out agent);
    }
}