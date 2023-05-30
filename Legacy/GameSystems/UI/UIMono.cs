using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UI {
    public abstract class UIMono : MonoBehaviour
    {
        public Image image;
        public RectTransform rectTransform;
        protected virtual void Awake()
        {
            image = GetComponent<Image>();
            rectTransform = GetComponent<RectTransform>();
        }
        protected void SetInactive(bool flag)
        {
            if(flag)
            {
                Color color = image.color;
                color.a = 0.5f;
                image.color = color;
                image.raycastTarget = false;
            }
            else
            {
                Color color = image.color;
                color.a = 1;
                image.color = color;
                image.raycastTarget = true;

            }
        }
    }
}