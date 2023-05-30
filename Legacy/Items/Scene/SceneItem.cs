using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;

namespace Items
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class SceneItem : Soft
    {

        public Item item;
        new SpriteRenderer renderer;
        private void Awake()
        {
            renderer = GetComponent<SpriteRenderer>();
            if(item!=null)
                renderer.sprite = item.gameSprite;
        }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if(collision.tag == "Player")
        //    {
        //        TriggerEntered(GameSystems.UseAction.TAKE);
        //    }
        //}
        //private void OnTriggerExit2D(Collider2D collision)
        //{
        //    if (collision.tag == "Player")
        //    {
        //        TriggerExited();
        //    }
        //}
    }
}