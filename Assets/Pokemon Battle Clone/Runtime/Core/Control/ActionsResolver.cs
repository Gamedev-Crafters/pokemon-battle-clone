using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain;

namespace Pokemon_Battle_Clone.Runtime.Core.Control
{
    public class ActionsResolver
    {
        public async Task Resolve(TrainerActionResult actionResult, IBattleContext context)
        {
            switch (actionResult)
            {
                case MoveActionResult moveResult:
                    await HandleMoveVisuals(moveResult, context);
                    break;
                case SwapActionResult swapResult:
                    await HandleSwapVisuals(swapResult, context);
                    break;
            }
        }
        
        private async Task HandleMoveVisuals(MoveActionResult actionResult, IBattleContext context)
        {
            var userTeam = context.GetTeam(actionResult.Side);
            var rivalTeam = context.GetOpponentTeam(actionResult.Side);

            await userTeam.View.PlayAttackAnimation();

            rivalTeam.UpdatePokemonHealthBar(animated: true);
            if (actionResult.TargetFainted)
                await rivalTeam.View.PlayFaintAnimation();
            else
                await rivalTeam.View.PlayHitAnimation();
        }

        private async Task HandleSwapVisuals(SwapActionResult actionResult, IBattleContext context)
        {
            var userTeam = context.GetTeam(actionResult.Side);
            await userTeam.SendFirstPokemon();
        }
    }
}