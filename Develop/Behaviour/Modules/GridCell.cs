using UnityEngine;

namespace Develop.Behaviour
{
    public class GridCell
    {
        public int current = -1;
        //public InventoryModule module;
        public Vector2Int pos;
        public GridCell(Vector2Int pos)
        {
            current = -1;
            this.pos = pos;
            //this.module = module;
        }
        public void Placed(int index)
        {
            current = index;
        }
        void Clear()
        {
                
            current = -1;
                  
        }
    }
}