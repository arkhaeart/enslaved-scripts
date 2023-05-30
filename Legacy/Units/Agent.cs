using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units.Modules;
using Items;
using GameSystems;
using Pathfinding;
using Zenject;
using Develop.Behaviour.Modules;
//using EquipmentModule = Units.Modules.EquipmentModule;

namespace Units
{
    public abstract class Agent:Unit,IDestroyable,IInventoryUser//,IEqupmentUser
    {
        public delegate void AgentDelegate(Agent agent);
        public event AgentDelegate OnHitReceived;
        public AnimationSkeleton skeleton;
        public MovementModule mModule;
        public CombatModule cModule;
        public AnimationModule aModule;
        InventoryModule iModule;
        //EquipmentModule eModule;
        public HealthModule hModule;
        public CharacterSkeletonModule csModule;
        protected Rigidbody2D rgbd;
        public InventoryInfoPreset inventoryPreset;
        public InventoryModule IModule => iModule;

        //public EquipmentModule EModule => eModule;
        [Inject]
        public void OnSpawned(IPathFinder pathFinder)
        {

            // rgbd = GetComponent<Rigidbody2D>();
            //
            // mModule = new MovementModule(this, rgbd,pathFinder);
            // cModule = new CombatModule(this);
            // aModule = new AnimationModule(this, skeleton);
            // hModule = new HealthModule(this);
            // iModule = new InventoryModule(this, InventoryModule.Type.AGENT);
            // eModule = new EquipmentModule(this, EquipmentModule.Type.CHARACTER);
            // if (inventoryPreset != null)
            // {
            //     //InventoryInfoUtil.UnpackAndInitInventoryInfo(inventoryPreset.info, IModule, EModule);
            // }
            // csModule = new CharacterSkeletonModule(this);
            // csModule.Init(eModule);
            // OnHitReceived += cModule.RegisterHit;
        }
        public  void GetHit(Agent agent)
        {
            OnHitReceived?.Invoke(agent);
        }
        public void Death()
        {
            //PoolManager.Instance.Store(this);
        }
    }
}