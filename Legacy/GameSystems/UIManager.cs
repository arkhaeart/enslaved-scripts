using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;
using Zenject;

namespace GameSystems
{
    public class UIManager : MonoBehaviour
    {
        public Transform HUD;
        public InventoryGridHolder playerInventory,otherInventory,chestInventory,barterInventory;
        public DnDPlatform platform;
        [Inject]
        public void Initialize(InputManager inputManager)
        {

            inputManager.DragResponse += platform.Init;
            inputManager.DropResponse += platform.Drop;
            inputManager.DropStopResponse += platform.Stop;
            //InventoryDrawer.InventoryHolderToggle += OtherInventoryResponse;
        }

    
        void ToggleWindowActive(GameObject window)
        {
            window.SetActive(!window.activeSelf);
        }
        void OtherInventoryResponse(InventoryGridHolder holder)
        {
            ToggleWindowActive(holder.gameObject);
        }


    }
}