using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI
{
    public class UseActionsMenu : UIMono
    {
        public int basicWidth = 100;
        public int basicHeight=20;
        public void SetSize(int count)
        {
            gameObject.SetActive(true);
            rectTransform.sizeDelta = new Vector2(basicWidth, count * basicHeight);
        }
        public void Store()
        {
            gameObject.SetActive(false);
        }
    }
}