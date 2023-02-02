namespace DungeonsOfDoom.Core
{
    class Monster
    {
        // I have done some commentating for easier to understand how I am thinking
        // If anyone has any other ideas or feedback, write it under here or hit me up for discussion!  // Jens

        public virtual string MonsterName { get; init; }
        // MonsterHealth will be randomized from RandomHP method
        // Using the numbers on LifeLower and LifeHigher to randomize between
        // Each monster type will have their own range which will override these base values
        public int MonsterHealth { get; set; }
        public virtual int LifeLower { get; set; }  = 2;
        public virtual int LifeHigher { get; set; } = 5;
        public virtual Enum SlimeColor { get; init; }
        // Base monster is a random squirrel which gives nothing, rest of the monster types are overriding this
        public virtual Enum MonsterType { get; init; } = MonsterTypeEnum.Squirrel;
        // Base flair is tiny for now, but will be changed, just to have something for those monsters that doesnt have flairs
        // will mostly be for the slime, I guess!
        public virtual Enum MonsterNameFlairs { get; init; } = MonsterFlairsEnum.Tiny;
        public int ArmorLevel { get; set; } = 0;
        // Hit Power * PhysicalResistanceInPercent = Damage
        public double PhysicalResistanceInPercent { get; set; } = 1;
        // Magic Power * MagicResistanceInPercent = Damage
        public double MagicResistanceInPercent { get; set; } = 1;
        // Will most likely make some kind of randomize on Strength as well
        public int MonsterStrength { get; set; } = 2;
        // Monster level will scale up and will make monsters stronger and harder to beat
        // This will be override from each monster type how they will be leveling up
        public int MonsterLevel { get; set; } = 1;
        // Monster can carry and use items, some will just be held and dropped when dying
        // and some will be used by monster to make it stronger
        // will use some kind of random for what item monster will carry
        // but each monster type will have their own sets of items they can have
        public List<Item> Inventory { get; set; }
        //// Eliminated for now!
        // public bool IsPlayerAlive { get { return Health > 0; } }
        internal int RandomHP()
        {
            Random randomNumber = new Random();
            int life = randomNumber.Next(LifeLower, LifeHigher);
            return life;
        }
        internal void MonsterInventory()
        {
            Inventory = new List<Item>();
        }
        internal void RandomInventory()
        {

        }
    }
}
