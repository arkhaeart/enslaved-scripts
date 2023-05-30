using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Units;
namespace UI
{
    public class UseActionItem : UIMono
    {
        public static System.Action<Unit> Called;
        Unit stored;
        public Text text;
        protected override void Awake()
        {
            base.Awake();
            text = GetComponentInChildren<Text>();
        }
        public void Store()
        {
            gameObject.SetActive(false);
        }
        public void Show(string message,Units.Unit stored)
        {
            this.stored = stored;
            gameObject.SetActive(true);
            text.text = message;
        }
        public void Call()
        {
            Called?.Invoke(stored);
        }
    }
}