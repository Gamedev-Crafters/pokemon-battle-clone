using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Battles.Domain.Events;
using Pokemon_Battle_Clone.Runtime.Battles.Infrastructure.Dialogs;

namespace Pokemon_Battle_Clone.Runtime.Battles.Control.EventHandlers
{
    public class RecoilEventHandler : IBattleEventHandler<RecoilEvent>
    {
        private readonly IBattleContext _battleContext;
        private readonly IDialogDisplay _dialogDisplayer;

        public RecoilEventHandler(IBattleContext battleContext, IDialogDisplay dialogDisplayer)
        {
            _battleContext = battleContext;
            _dialogDisplayer = dialogDisplayer;
        }
        
        public async Task Handle(RecoilEvent battleEvent)
        {
            var view = _battleContext.GetTeamView(battleEvent.Side);
            
            view.UpdateHealth(battleEvent.PokemonHealth.Max, battleEvent.PokemonHealth.Current, animated: true);
            await view.PlayHitAnimation();
            await _dialogDisplayer.DisplayAsync($"{battleEvent.PokemonName} was damage by recoil!");
        }
    }
}