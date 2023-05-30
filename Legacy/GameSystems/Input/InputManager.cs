using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UI;
namespace GameSystems {
    public class InputManager :MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        public delegate void Vector2Response(Vector2 v2);
        public delegate void TriggerResponse();
        public delegate void InventoryGridResponse(InventoryGridItem item);
        public delegate void InventoryCellResponse(InventoryGridCell cell);

        public event System.Action<int> HotKeyFoldersResponse;
        public event TriggerResponse InventoryResponse;
        public event TriggerResponse UseStartResponse;
        public event TriggerResponse UseEndResponse;
        public event TriggerResponse InputBlocked;
        public Action<bool> BlockResponse;
        public event Vector2Response MovResponse;
        public event Vector2Response MouseResponse;
        public event Vector2Response AttackResponse;
        public event InventoryGridResponse DragResponse;
        public event InventoryCellResponse DropResponse;
        public event TriggerResponse DropStopResponse;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        GraphicRaycaster raycaster;
        Vector2 axisInput;
        private void Awake()
        {

            raycaster = GetComponent<GraphicRaycaster>();
        }

        private void LateUpdate()
        {

            axisInput.x = Input.GetAxisRaw("Horizontal");
            axisInput.y = Input.GetAxisRaw("Vertical");
            if(axisInput!=Vector2.zero)
            {
                MovResponse?.Invoke(axisInput);
            }
            if(Input.GetButtonDown("Inventory"))
            {
                HotKeyFoldersResponse?.Invoke(4);
            }
            if(Input.GetButtonDown("Character"))
            {
                HotKeyFoldersResponse?.Invoke(0);
                HotKeyFoldersResponse?.Invoke(1);
            }
            if(Input.GetButtonDown("Social"))
            {
                HotKeyFoldersResponse?.Invoke(2);
            }
            if (Input.GetButtonDown("Use"))
            {
                UseStartResponse?.Invoke();
                InputBlocked();
            }
            if (Input.GetButtonUp("Use"))
            {
                UseEndResponse?.Invoke();
                InputBlocked();
            }
            if (Input.GetButtonDown("Block"))
            {
                BlockResponse?.Invoke(true);
            }
            if(Input.GetButtonUp("Block"))
            {
                BlockResponse?.Invoke(false);
            }

        }
        /*
        #region GameInput
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            if (!movePressed.IsActive)
                movePressed.Run(context);
        }
        public void OnAttackInput(InputAction.CallbackContext context)
        {
            if (!emulateWait.IsActive)
            {
                emulateWait.Run();
                Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                AttackResponse(target);


            }
        }
        public void OnInventoryInput(InputAction.CallbackContext context)
        {
            if(!emulateWait.IsActive)
            {
                emulateWait.Run();
                InventoryResponse();
            }
        }
        public void OnBlockInput(InputAction.CallbackContext context)
        {
            if (!emulateWait.IsActive)
            {
                emulateWait.Run();
                blockPressed.Run(context);
            }

        }
        public void OnMouseInput(InputAction.CallbackContext context)
        {
            if (!emulateWait.IsActive&&!blockPressed.IsActive)
            {
                emulateWait.Run();
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                Debug.Log(pos);
                MouseResponse(pos);
                
            }
        }
        IEnumerator BlockPressed(InputAction.CallbackContext context)
        {
            if(context.action.phase==InputActionPhase.Started)
                BlockResponse(true);
            while(context.action.phase==InputActionPhase.Started)
            {
                yield return null;
            }
            BlockResponse(false);
        }
        IEnumerator EmulateWait()
        {
            yield return new WaitForSeconds(0.3f);
        }
        IEnumerator MovePressed(InputAction.CallbackContext context)
        {
            while(context.action.ReadValueAsObject()!=null)
            {
                var dir = (Vector2)context.ReadValueAsObject();
                MovResponse(dir);
                yield return null;
            }

        }
        #endregion
        #region UI Input
        public void OnClickAndDragInput(InputAction.CallbackContext context)
        {
            Debug.Log("Drag initiated");
            if(!emulateWait.IsActive)
            {
                emulateWait.Run();
                clickDragging.Run(context);
            }
        }
        IEnumerator ClickAndDrag(InputAction.CallbackContext context)
        {

                Debug.Log(context.phase);
                Debug.Log("dragging at ");
                yield return null;
            
        }
        */


        public void OnPointerDown(PointerEventData eventData)
        {

            raycastResults.Clear();

            raycaster.Raycast(eventData, raycastResults);
            if (raycastResults[0].gameObject.tag == "View")
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("View clicked");
                if (Input.GetMouseButtonDown(1))
                {
                    
                    pos.z = 0;
                    //pos.y -= 0.08f;
                    pos.x -= 0.08f;
                    Debug.Log(pos);
                    MouseResponse?.Invoke(pos);
                }
                else if(Input.GetMouseButtonDown(0))
                {
                    AttackResponse?.Invoke(pos);
                }
            }
            else
            {
                Debug.Log("UI clicked");
                raycastResults.Clear();
                raycaster.Raycast(eventData, raycastResults);
                Debug.Log(raycastResults[0].gameObject);
                if(raycastResults[0].gameObject.TryGetComponent(out UseActionItem item))
                {
                    item.Call();
                }
            }
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (Input.GetMouseButton(0))
            {

                if (GraphicRaycast(out InventoryGridItem item,eventData))
                {
                    Debug.Log("Drag has begun");
                    DragResponse?.Invoke(item);
                }
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("Drag has ended");
            if(GraphicRaycast(out InventoryGridCell cell,eventData))
                {
                    DropResponse?.Invoke(cell);
                }
            DropStopResponse();

            
        }
        bool GraphicRaycast<T>(out T item, PointerEventData eventData) where T : MonoBehaviour
        {
            raycastResults.Clear();
            raycaster.Raycast(eventData, raycastResults);
            if (raycastResults[0].gameObject.TryGetComponent(out T newItem))
            {
                item = newItem;
                return true;
            }
            else
            {
                item = null;
                return false;
            }
        }

    }
}