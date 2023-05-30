using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Configs/AgentTypes")]
public class AgentTypeConfig : ScriptableObject,IDropDownFiller
{
    public string[] types;

    public string[] GetEntries()
    {
        return types;
    }
}
