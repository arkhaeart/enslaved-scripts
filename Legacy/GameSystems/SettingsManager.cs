using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containment;
using Items;
using System.Linq;
namespace GameSystems
{
    public class SettingsManager 
    {
        const string infoPath = "Info/";
        const string eqSlotsName = "EqSlotsList";
        const string workShopSlotsName = "WorkShopSlots";
        public ItemDatabase itemDatabase;
        public CrimeCodex crimeCodex;
        // public EquipmentSlotsConfig eqSlots;
        // public EquipmentSlotsConfig workShopSlots;
        public InventoryInfoPresetHolder presetHolder;

        public void Init()
        {
            LoadSettings();
            InitSettings();
        }
        
        void LoadSettings()
        {
            var infos = Resources.LoadAll(infoPath);
            itemDatabase = infos.First((n) => n is ItemDatabase) as ItemDatabase;
            //crimeCodex = infos.First((n) => n is CrimeCodex) as CrimeCodex;
            // eqSlots = infos.First(n => n.name==eqSlotsName ) as EquipmentSlotsConfig;
            // workShopSlots=infos.First(n => n.name == workShopSlotsName) as EquipmentSlotsConfig;
            presetHolder = infos.First((n) => n is InventoryInfoPresetHolder) as InventoryInfoPresetHolder;
        }
        void InitSettings()
        {
            crimeCodex.Init();
            itemDatabase.Init();
        }
    }
}