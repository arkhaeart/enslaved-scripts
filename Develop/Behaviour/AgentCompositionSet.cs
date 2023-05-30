using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Develop
{
    [System.Serializable]
    public class AgentCompositionSet
    {
        [StringDropDown(path = "Configs/AgentTypesConfig")]
        public string name;

        public ModuleType[] moduleTypes;
        [System.Serializable]
        public class ModuleType
        {
            [TypeStringDropDown(namespaceName ="Develop.Behaviour.Modules")]
            public string type;
        }
    }
}