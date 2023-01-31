namespace DungeonsOfDoom.Core
{
    class Monster
    {
        public Monster(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public bool IsPlayerAlive { get { return Health > 0; } }

    }
}
