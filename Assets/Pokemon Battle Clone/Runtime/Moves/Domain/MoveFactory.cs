using Pokemon_Battle_Clone.Runtime.Builders;
using Pokemon_Battle_Clone.Runtime.Core.Domain;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain
{
    public static class MoveFactory
    {
        public static Move IceFang()
        {
            return A.Move.WithName("Ice Fang")
                .WithAccuracy(95)
                .WithPower(65)
                .WithPP(15)
                .WithCategory(MoveCategory.Physical)
                .WithType(ElementalType.Ice);
        }

        public static Move WaterGun()
        {
            return A.Move.WithName("Water Gun")
                .WithAccuracy(100)
                .WithPower(40)
                .WithPP(25)
                .WithCategory(MoveCategory.Special)
                .WithType(ElementalType.Water);
        }

        public static Move QuickAttack()
        {
            return A.Move.WithName("Quick Attack")
                .WithAccuracy(100)
                .WithPower(40)
                .WithPP(30)
                .WithCategory(MoveCategory.Physical)
                .WithType(ElementalType.Normal)
                .WithPriority(1);
        }

        public static Move WingAttack()
        {
            return A.Move.WithName("Wing attack")
                .WithAccuracy(100)
                .WithPower(60)
                .WithPP(35)
                .WithCategory(MoveCategory.Physical)
                .WithType(ElementalType.Flying);
        }
    }
}