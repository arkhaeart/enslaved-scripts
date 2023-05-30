using Items;

namespace Develop.Behaviour
{
    public class GridItem
    {
        public GridCell cell;
        public Item item;
        public GridItem(GridCell cell, Item item)
        {
            this.cell = cell;
            this.item = item;
        }
    }
}