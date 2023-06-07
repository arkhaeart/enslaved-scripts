using System.Collections.Generic;
using Develop.Utilities;
using UnityEngine;

namespace Develop.Items.Mono
{
    public class MonoMeshSlot:MonoBehaviour
    {
        public SkinnedMeshRenderer skinnedMeshRenderer;
        [Sirenix.OdinInspector.ValueDropdown("GetMeshSlots")]
        public string meshSlot;

        public List<string> GetMeshSlots()
        {
            return StringDropdownUtility.GetMeshSlots();
        }
    }
}