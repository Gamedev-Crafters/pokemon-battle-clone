namespace Pokemon_Battle_Clone.Runtime.Builders
{
    public static class A
    {
        public static PokemonBuilder Pokemon => new PokemonBuilder();
        public static MoveBuilder Move => new MoveBuilder();
    }
}