using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units.Modules;
namespace Items
{
    public class Container : Soft,IInventoryUser
    {
        InventoryModule iModule;
        public InventoryModule IModule => iModule;
        private void Awake()
        {
            iModule = new InventoryModule( InventoryModule.Type.CONTAINER);
        }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if(collision.tag=="Player")
        //        TriggerEntered(GameSystems.UseAction.LOOT);
        //}
        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    if (collision.tag == "Player")
        //        TriggerExited();
        //}
    }
}
