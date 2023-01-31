namespace DungeonsOfDoom.Core
{
    class Slime : Monster
    {
        public override string Name { get; init; }
        public override Enum SlimeColor { get; init; }
        public override Enum MonsterType { get; init; } = MonsterTypes.Slime;
        public override int LifeLower { get; set; }  = 10;
        public override int LifeHigher { get; set; } = 19;
        public Slime()
        {
            Health = RandomHP();
            SlimeColor = RandomColor();
            Name = $"{SlimeColor} {MonsterType}";
        }
    }
}