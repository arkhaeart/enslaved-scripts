using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;
namespace Units
{
    public abstract class Unit : MonoBehaviour
    {
        //public static event System.Action<Unit, UseAction> TriggerEnter;
        //public static event System.Action<Unit> TriggerExit;
        //protected void TriggerEntered(UseAction action)
        //{
        //    TriggerEnter?.Invoke(this, action);
        //}
        //protected void TriggerExited()
        //{
        //    TriggerExit?.Invoke(this);
        //}
        //public abstract void GetHit(Agent agent);
        //public abstract void Death();
    }
    public interface IDestroyable
    {
        void GetHit(Agent agent);
        void Death();
    }
}