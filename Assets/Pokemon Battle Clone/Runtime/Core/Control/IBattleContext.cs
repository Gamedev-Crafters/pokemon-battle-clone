using Pokemon_Battle_Clone.Runtime.Core.Domain;

namespace Pokemon_Battle_Clone.Runtime.Core.Control
{
    public interface IBattleContext
    {
        TeamController GetTeam(Side side);
        TeamController GetOpponentTeam(Side side);
        
    }
}