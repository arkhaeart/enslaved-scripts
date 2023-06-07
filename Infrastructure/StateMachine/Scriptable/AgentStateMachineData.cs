using System.Collections.Generic;
using Develop.Utilities;
using UnityEngine;

namespace Infrastructure.StateMachine.Scriptable
{
    [CreateAssetMenu(menuName = "Scriptable/Data/AgentStateMachine")]
    public class AgentStateMachineData:ScriptableObject
    {
        public string agentType;
        public LayerData[] layerDatas;
    }

    [System.Serializable]
    public class LayerData
    {
        public string name;
        public StateData[] stateDatas;
    }

    [System.Serializable]
    public class StateData
    {
        [Sirenix.OdinInspector.ValueDropdown("GetTypes")]
        public string type;
        public LinkData[] links;
        public bool overriding = false;

        public List<string> GetTypes()
        {
            return StringDropdownUtility.GetStateTypes();
        }
    }

    [System.Serializable]
    public class LinkData
    {
        [Sirenix.OdinInspector.ValueDropdown("GetTypes")]
        public string name;
        public List<string> GetTypes()
        {
            return StringDropdownUtility.GetStateTypes();
        }
    }
    
}