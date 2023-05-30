using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Units.Modules
{
    public class AutoCombatModule : CombatModule
    {
        public CustomCour following, hitting,scanning;
        public AutoCombatModule(Agent _mono) : base(_mono)
        {
            following = new CustomCour(mono, new System.Func<IEnumerator>(FollowTarget));
            hitting = new CustomCour(mono, new System.Func<IEnumerator>(HittingTarget));
            scanning = new CustomCour(mono, new System.Func<IEnumerator>(ScanningTargets));
            scanning.Run();
            mono = _mono;
        }
        IEnumerator ScanningTargets()
        {
            while(target==null)
            {
                yield return wait;
            }
            following.Run();
        }
        IEnumerator FollowTarget()
        {
            
            while (!InAttackRange)
            {
                if (!Mono.mModule.Moving)
                {
                    Vector3 goal = target.transform.localPosition.RandomPointNearby(0.15f);
                    Mono.mModule.RequestPath(goal);
                }
                yield return null;
            }
            hitting.Run();
        }
        IEnumerator HittingTarget()
        {
            while(target.gameObject.activeSelf&&InAttackRange)
            {
                RenderHit(target.transform.position - transform.position);
                yield return wait;
            }
            if(target.enabled)
            {
                following.Run();
            }
        }
        bool InAttackRange
        {
            get => (Vector3.SqrMagnitude(transform.position - target.transform.position) <= (attackRange.GetSqr));
        }
    }
}