using Items;
using JetBrains.Annotations;
using UnityEngine;

namespace Develop.Behaviour
{
    public class InventoryInteractionPayload:IBehaviourInteractionData
    {
        private IInteractionProcessor interactionProcessor;

        public void Process(IItemBasedModule itemBasedModule)
        {
            interactionProcessor.Process(itemBasedModule);
        }
        public interface IInteractionProcessor
        {
             void Process(IItemBasedModule itemBasedModule);
        }

        public struct AddItemInteractionProcessor:IInteractionProcessor
        {
            private Item item;
            [CanBeNull] private GridCell gridCell;
            public void Process(IItemBasedModule itemBasedModule)
            {
                itemBasedModule.AddItem(item,gridCell);
            }
        }
        public struct RemoveItemInteractionProcessor:IInteractionProcessor
        {
            public int index;

            public void Process(IItemBasedModule itemBasedModule)
            {
                itemBasedModule.RemoveItem(index);
            }
        }
        public struct MoveItemInteractionProcessor:IInteractionProcessor
        {
            public IItemBasedModule from;
            public int index;
            public Vector2Int position;
            public void Process(IItemBasedModule itemBasedModule)
            {
                itemBasedModule.MoveItem(from,index,position);
            }
        }
        public struct GetItemInteractionProcessor:IInteractionProcessor
        {
            public int index;
            public void Process(IItemBasedModule itemBasedModule)
            {
                itemBasedModule.GetItem(index);
            }
        }
    }
}