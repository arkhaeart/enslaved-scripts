using Develop.Behaviour;
using GameSystems;
using Units.Modules;
namespace UI
{
    public class InventoryCard
    {
        public IItemBasedModule module;
        public InventoryGridHolder holder;
        public InventoryCard( InventoryGridHolder holder)
        {

            this.holder = holder;
        }
    }
    public class PlayerInventoryCard : InventoryCard
    {
        public PlayerInventoryCard(InventoryGridHolder holder) : base(holder)
        {
            //if (holder.holderType == "player")
            //{
            //    module = LevelManager.Instance.player.IModule;
            //}
            //else if (holder.holderType == "playere")
            //    module = LevelManager.Instance.player.EModule;
        }
    }
}