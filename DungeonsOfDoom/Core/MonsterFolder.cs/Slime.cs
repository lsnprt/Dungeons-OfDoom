namespace DungeonsOfDoom.Core
{
    class Slime : Monster
    {
        // Slime monster will have their color randomized and then name will be just the color and type
        // ie Purple Slime
        // Will not have any other flair in name and will not carry an inventory
        // Different colors of slimes will have different attributes
        // ie Black slime will have some physical resistance and purple will have some magic resistance
        public override string MonsterName { get; init; }
        public override Enum SlimeColor { get; init; }
        public override Enum MonsterType { get; init; } = MonsterTypeEnum.Slime;
        public override int LifeLower { get; set; }  = 10;
        public override int LifeHigher { get; set; } = 19;
        public Slime()
        {
            MonsterHealth = RandomHP();
            SlimeColor = RandomSlimeColor();
            MonsterName = $"{SlimeColor} {MonsterType}";
        }
        internal Enum RandomSlimeColor()
        {
            Random randomNumber = new Random();
            Array values = Enum.GetValues(typeof(SlimeColorEnum));
            SlimeColorEnum randomColor = (SlimeColorEnum)values.GetValue(randomNumber.Next(values.Length))!;

            switch (randomColor)
            {
                case SlimeColorEnum.Black:
                    PhysicalResistanceInPercent = 0.50;
                    break;
                case SlimeColorEnum.Blue:
                    break;
                case SlimeColorEnum.Green:
                    break;
                case SlimeColorEnum.Red:
                    break;
                case SlimeColorEnum.White:
                    MonsterStrength += 3;
                    break;
                case SlimeColorEnum.Purple:
                    MagicResistanceInPercent = 0.50;
                    break;
                case SlimeColorEnum.Orange:
                    break;
                default:
                    break;
            }

            return randomColor;
        }
    }
}