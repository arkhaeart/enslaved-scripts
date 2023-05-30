using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UI {
    public class DnDPlatform : UIMono
    {
        CustomCour following;
        InventoryGridItem item;
        protected override void Awake()
        {
            base.Awake();
            following = new CustomCour(this, new System.Func<IEnumerator>(DnDPlatformFollow));
        }
        public void Init(InventoryGridItem _item)
        {
            item=_item;
            transform.position = item.transform.position;
            image.sprite = item.image.sprite;
            rectTransform.sizeDelta = item.rectTransform.sizeDelta;
            item.OnDrag(true);
            image.enabled=true;
            following.Run();
        }
        IEnumerator DnDPlatformFollow()
        {
            while (true)
            {
                transform.position = Input.mousePosition;
                yield return null;
            }
        }
        public void Stop()
        {
            if (item != null)
            {
                following.Stop();
                image.enabled=false;
                item.OnDrag(false);
                item = null;
            }
        }
        public void Drop(InventoryGridCell cell)
        {
            Debug.Log($"Dropping {item} on {cell}");
            if(following.IsActive)
            {
                cell.holder.OnItemMoved(item, cell.pos);
            }
        }
    }
}