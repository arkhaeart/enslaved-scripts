using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Units.Modules
{
    public class AnimationModule : BehaviourModule
    {
        protected AnimationSkeleton skeleton;
        public AnimationModule(Agent mono,AnimationSkeleton _skeleton):base(mono)
        {
            skeleton = _skeleton;
        }
        public void PlayAttack(Direction dir)
        {
            skeleton.weapon.Play();
        }
    }
}