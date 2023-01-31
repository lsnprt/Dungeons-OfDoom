namespace DungeonsOfDoom.Core
{
    class Player
    {
        public Player(int health, int rowPosition, int columnPosition)
        {
            Health = health;
            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
            Inventory = new List<Item>();
        }

        public int Health { get; set; }
        public bool IsAlive { get { return Health > 0; } }
        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }
        public List<Item> Inventory { get; set; }

        public void AddToInventory(Item item)
        {
            Inventory.Add(item);
        }
    }
}
