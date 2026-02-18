using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure;

namespace Pokemon_Battle_Clone.Runtime.Core.Control
{
    public interface IBattleViewContext
    {
        ITeamView GetTeamView(Side side);
        ITeamView GetOpponentView(Side side);
        
    }
}