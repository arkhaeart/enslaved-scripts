using System.Collections;
using System.Collections.Generic;
using Develop.Behaviour;
using UnityEngine;
using Units;
using Items;
namespace Units.Modules
{
    public class InventoryModule : BehaviourModuleBase<InventoryInteractionPayload>,IItemBasedModule
    {
   
        public enum Type
        {
            AGENT,
            CONTAINER
        }

        public Type type;
        public Item[] inventory;
        public GridCell[,] invGrid;

        int width, height; 
        const int maxItemCount= 50;

        public event System.Action<int> CellsClear;
        public InventoryModule(Type type)
        {
            inventory = new Item[maxItemCount];
            InitCellGrid(type);
        }
        void InitCellGrid(Type type)
        {
            this.type = type;
            switch((int)type)
            {
                case 0:
                    width=5;
                    height = 10;
                    break;
                case 1:
                    width = 8;
                    height = 12;
                    break;
            }
            invGrid = new GridCell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int y = 0; y < height; y++)
                {
                    invGrid[i, y] = new GridCell(new Vector2Int(i, y));
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index">Parse GridCell or null for auto placement</param>
        public void AddItem(Item item, GridCell givenCell=null)
        {

                if (givenCell!=null )
                {
                    PlaceItem(item, givenCell);
                    //Draw();
                }
                else
                {
                    if (FindCellForItem(item, out GridCell cell))
                    {
                        PlaceItem(item, cell);
                        //Draw();
                    }
                    else DropItem(item);
                }
            


        }

        

        public Item RemoveItem(int index)
        {
            if (index is int i)
            {
                Item item = inventory[i];
                inventory[i] = null;
                //itemsToDraw.Remove(i);
                CellsClear?.Invoke(i);
                //Debug.Log($"Item {item} was removed from {mono}");

                //Draw();
                return item;
            }
            throw new System.Exception("Tried to remove from inventory by non-integer");
        }
        public Item GetItem(int index)
        {
            
            return inventory[index];
            
        }
        public void MoveItem(IItemBasedModule from,int index, Vector2Int pos)
        {
            Item moved=from.GetItem(index);
            GridCell pCell = GetOffsetCell(moved,pos);
            if (CheckFittable(moved, pCell) && CheckPlacable(moved, pCell))
            {
                from.RemoveItem(index);
                AddItem(moved, pCell);
            }
            else if (FindCellForItem(moved, out GridCell cell))
            {
                from.RemoveItem(index);
                AddItem(moved,null);
            }
            else return;

        }
        public void DropItem(Item item)
        {

        }
        bool FindCellForItem(Item item, out GridCell cell)
        {
            for (int i = 0; i < width; i++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (CheckFittable(item, invGrid[i, y]))
                    {
                        if (CheckPlacable(item, invGrid[i, y]))
                        {
                            cell = invGrid[i, y];
                            return true;
                        }
                    }
                }
            }
            cell = null;
            return false;
        }
        bool CheckFittable(Item item, GridCell cell)
        {
            int xCheck = cell.pos.x + item.X;
            int yCheck = cell.pos.y + item.Y;
            if (xCheck > width || yCheck > height)
            {
                return false;
            }
            else return true;
        }
        bool CheckPlacable(Item item, GridCell cell)
        {
            int maxWidth = Mathf.Clamp(cell.pos.x + item.X, 0, width);
            int maxHeight = Mathf.Clamp(cell.pos.y + item.Y, 0, height);
            for (int i = cell.pos.x; i < maxWidth; i++)
            {
                for (int y = cell.pos.y; y < maxHeight; y++)
                {

                    if (invGrid[i, y].current != -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void EraseItem(int index)
        {
            CellsClear?.Invoke(index);

        }
        void PlaceItem(Item item, GridCell cell)
        {
            int index = GetEmptyIndex();
            inventory[index] = item;
            // Debug.Log($"Item {item} was added to {mono}");
            // itemsToDraw.Add(index, new GridItem(cell, item));
            CellsClear?.Invoke(index);
            for (int i = cell.pos.x; i < cell.pos.x + item.X; i++)
            {
                for (int y = cell.pos.y; y < cell.pos.y + item.Y; y++)
                {
                    invGrid[i, y].Placed(index);
                }
            }
        }

        int GetEmptyIndex()
        {
            for (int i = 0; i < maxItemCount; i++)
            {
                if (inventory[i]== null)
                {
                    return i;
                }
            }
            throw new System.Exception("Inventory max item count exceeded!");
        }
        GridCell GetOffsetCell(Item item, Vector2Int pos)
        {
            int xOffset = Mathf.Clamp(pos.x - item.X / 2, 0, width);
            int yOffset = Mathf.Clamp(pos.y - item.Y / 2, 0, height);
            return invGrid[xOffset, yOffset];
        }

        public override void Interact(InventoryInteractionPayload payload)
        {
            throw new System.NotImplementedException();
        }
    }
}