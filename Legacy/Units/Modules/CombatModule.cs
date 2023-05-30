using UnityEngine;
using System.Collections;

namespace Units.Modules
{
    public class CombatModule : BehaviourModule
    {
        public ModifiableParameter attackRange;
        public ModifiableParameter attackCooldown;
        public CustomCour isBlocking;
        protected WaitForSeconds wait;
        public Agent target;
        public CombatModule(Agent _mono) : base(_mono)
        {
            isBlocking = new CustomCour(mono, new System.Func<IEnumerator>(IsBlocking));
            attackRange = new ModifiableParameter(0.32f);
            attackCooldown = new ModifiableParameter(1);
            wait = new WaitForSeconds(attackCooldown.Get);
            mono = _mono;
        }
        public void RenderHit(Vector2 direction)
        {
            Direction dir = Direction.Get(direction);
            Debug.Log(dir);
            RaycastHit2D hit=Physics2D.Raycast(transform.position, direction, 0.4f, LayerMask.GetMask("Units"));
            Mono.aModule.PlayAttack(dir);
            if(hit.transform!=null)
            {
                if (hit.transform.TryGetComponent(out IDestroyable agent))
                {
                    Debug.Log($"Rendered attack from{mono.name} to {hit.transform.name}");
                    agent.GetHit(Mono);
                }
            }

            //RaycastHit2D[] hits=Physics2D.CircleCastAll(transform.position, attackRange.Get, (Vector2)transform.position+direction,attackRange.Get, LayerMask.GetMask("Units"));
            //Debug.Log($"Units in hit area: {hits.Length}");
            //foreach(var h in hits)
            //{
            //    Debug.Log(h.transform.name);
            //}
        }
        IEnumerator RenderingHit()
        {
            yield return null;
        }
        public void RegisterHit(Agent agent)
        {
            Debug.Log($"{ mono.name} was attacked by {agent.name}");
        }
        public void RenderBlock()
        {
            
            Debug.Log($"{mono.name} started blocking");
            isBlocking.Run();
        }
        public void StopBlock()
        {
            isBlocking.Stop();
            Debug.Log($"{ mono.name} finished blocking");
        }
        IEnumerator IsBlocking()
        {
            yield return null;
        }
    }
}