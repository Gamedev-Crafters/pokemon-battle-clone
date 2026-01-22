using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain
{
    public class MoveAction : TrainerAction
    {
        public override int Priority => 0;
        
        private readonly int _moveIndex;
        private readonly TeamController _userTeamController;

        public MoveAction(Side side, int moveIndex, TeamController userTeamController) : base(side)
        {
            _moveIndex = moveIndex;
            _userTeamController = userTeamController;
        }
        
        public override async Task Execute()
        {
            await _userTeamController.PerformMove(_moveIndex);
        }
    }
}