using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI
{
    public abstract class UIDrawer : MonoBehaviour
    {
        // Start is called before the first frame update
        protected virtual void Awake()
        {
            //DrawManager.drawers.Add(GetType(), this);
        }
    }
}