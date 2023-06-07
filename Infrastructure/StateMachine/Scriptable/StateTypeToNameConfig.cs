using System.Collections.Generic;
using System.Linq;
using Develop.Utilities;
using UnityEngine;

namespace Infrastructure.StateMachine.Scriptable
{
    [CreateAssetMenu(menuName = "Scriptable/Config/StateTypeToName")]
    public class StateTypeToNameConfig:ScriptableObject
    {
        public Entry[] entries;
        public Dictionary<string, string> typeDict;

        public void Initialize()
        {
            typeDict = entries.ToDictionary(a => a.name, a => a.type);
        }
        public IEnumerable<string> GetTypeNames()
        {
            return entries.Select(entry => entry.name);
        }
        [System.Serializable]
        public class Entry
        {
            public string name;
            [Sirenix.OdinInspector.ValueDropdown("GetTypes")]
            public string type;

            public List<string> GetTypes()
            {
                var types = new List<string>() { "" };
                 types.AddRange(NamespaceClassesUtility.GetTypesStringByInterface<IState>());
                 return types;
            }
        } 
    }
    
}