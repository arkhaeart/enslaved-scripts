using Develop.Behaviour.Modules.Entities;

namespace Develop.Behaviour
{
    public class HealthInteractionPayload:IBehaviourInteractionData
    {
        public int deltaHealth;
        public IAgent interactor;
        public HealthChangeSource source;
    }
}