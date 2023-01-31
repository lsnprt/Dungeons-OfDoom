namespace DungeonsOfDoom.Core
{
    class Monster
    {
        public virtual string Name { get; init; }
        public int Health { get; set; }
        public virtual Enum SlimeColor { get; init; }
        public virtual Enum MonsterType { get; init; } = MonsterTypes.Slime;
        public virtual int LifeLower { get; set; }  = 10;
        public virtual int LifeHigher { get; set; } = 19;
        //// Eliminated for now!
        // public bool IsPlayerAlive { get { return Health > 0; } }
        internal int RandomHP()
        {
        Random randomNumber = new Random();
        int life = randomNumber.Next(LifeLower, LifeHigher);
        return life;
        }

        internal Enum RandomColor()
        {
        Random randomNumber = new Random();
        Array values = Enum.GetValues(typeof(SlimeColor));
        SlimeColor randomColor = (SlimeColor)values.GetValue(randomNumber.Next(values.Length))!;
        return randomColor;
        }


    }
}
