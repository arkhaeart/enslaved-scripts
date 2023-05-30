using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
using Units.Modules;
using System.Linq;
using UI;
namespace Items {
    public class WorkShop : Soft
    {
        
        public string ID;

        //public EquipmentModule eModule;
        public List<WorkShopReaction> reactions;



        // private void Awake()
        // {
        //     eModule = new EquipmentModule(this, EquipmentModule.Type.WORKSHOP);
        // }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.tag=="Player")
        //    {
        //        TriggerEntered(GameSystems.UseAction.WORK);
        //    }
        //}
        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    if (collision.tag == "Player")
        //    {
        //        TriggerExited();
        //    }
        //}
        void TryPerformReaction()
        {

        }
        bool ReactionEligible(InventoryModule module,out List<int> indices)
        {
            List<int>newIndices = new List<int>();
            foreach (var neededItem in reactions[0].requiredItems)
            {
                if (module.inventory.Any((n) =>
                {
                    if (n.name == neededItem)
                    {
                        //newIndices.Add();
                        return true;
                    }
                    else return false;
                }))
                {

                }
                else
                {
                    indices = null;
                    return false;
                }
            }
            indices = newIndices;
            return true;
        }
    }
}