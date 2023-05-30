using Containment;
using GameSystems;
using Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Settings/GameSettings")]
public class GameSettings : ScriptableObject
{
    public ItemDatabase itemDatabase;
    public CrimeCodex.Settings crimeCodex;
    // public EquipmentSlotsConfig eqSlots;
    // public EquipmentSlotsConfig workShopSlots;
    public InventoryInfoPresetHolder presetHolder;
}
