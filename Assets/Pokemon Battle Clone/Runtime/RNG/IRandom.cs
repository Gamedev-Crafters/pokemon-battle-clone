namespace Pokemon_Battle_Clone.Runtime.RNG
{
    public interface IRandom
    {
        int Range(int min, int max);
        int Next();
        bool Roll(int chancePercent);
    }
}