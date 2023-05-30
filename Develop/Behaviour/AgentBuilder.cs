using System.Collections;
using System.Collections.Generic;
using Develop;
using UnityEngine;
using Zenject;

public class AgentBuilder 
{

    public IAgent Build(AgentCompositionSet set)
    {
        var agent = new Agent();
        
        return agent;
    }
}
