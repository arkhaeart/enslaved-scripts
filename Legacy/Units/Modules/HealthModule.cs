// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// namespace Units.Modules
// {
//     public class HealthModule : BehaviourModule
//     {
//         public float maxHealth=100;
//         float health;
//         public float Health
//         {
//             get => health;
//             set
//             {
//                 health += value;
//                 if (health > maxHealth)
//                     health = maxHealth;
//                 else if(health<=0)
//                 {
//
//                 }
//             }
//         }
//         public HealthModule(Agent _mono) : base(_mono)
//         {
//             health = maxHealth;
//         }
//         
//     }
// }