using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Develop
{
    [CreateAssetMenu(menuName = "Configs/AgentComposition")]
    public class AgentCompositionConfig : ScriptableObject
    {
        public List<AgentCompositionSet> agentCompositionSets = new List<AgentCompositionSet>();

    }
}