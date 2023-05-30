using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Develop.Behaviour.Modules
{
    public class HealthModule :BehaviourModuleBase<HealthInteractionPayload>
    {
        private int maxHP;
        private int currentHP;
        public HealthModule(int maxHP)
        {
            this.maxHP = maxHP;
            currentHP = maxHP;
        }
        private bool WithdrawHealth(int deltaHealth)
        {
            currentHP -= deltaHealth;
            return currentHP > 0;
        }
        public int GetHP => currentHP;
        public override void Interact(HealthInteractionPayload payload)
        {
            WithdrawHealth(payload.deltaHealth);
        }
    }
    // public class InventoryModule : IBehaviourModule
    // {
    //
    // }
    
}