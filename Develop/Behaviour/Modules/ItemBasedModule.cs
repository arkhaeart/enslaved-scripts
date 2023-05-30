using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Items;
namespace Develop.Behaviour
{
    public interface IItemBasedModule 
    {
        public abstract void AddItem(Item item, GridCell index);
        public abstract void MoveItem(IItemBasedModule from, int index, Vector2Int pos);
        public abstract Item RemoveItem(int index);
        public abstract Item GetItem(int index);
    }
}