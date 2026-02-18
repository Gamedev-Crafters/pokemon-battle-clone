namespace Pokemon_Battle_Clone.Runtime.Core.Domain
{
    public enum Side
    {
        Player, Rival
    }
    
    public class Battle
    {
        private readonly Team _playerTeam;
        private readonly Team _rivalTeam;

        public Battle(Team playerTeam, Team rivalTeam)
        {
            _playerTeam = playerTeam;
            _rivalTeam = rivalTeam;
        }

        public Team GetTeam(Side side)
        {
            return side switch
            {
                Side.Player => _playerTeam,
                Side.Rival => _rivalTeam,
                _ => null
            };
        }

        public Team GetOpponentTeam(Side side)
        {
            return side switch
            {
                Side.Player => _rivalTeam,
                Side.Rival => _playerTeam,
                _ => null
            };
        }

        public bool PokemonFainted(Side side)
        {
            return side switch
            {
                Side.Player => _playerTeam.FirstPokemon.Defeated,
                Side.Rival => _rivalTeam.FirstPokemon.Defeated,
                _ => false
            };
        }
    }
}