using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Battles.Domain.Events;
using Pokemon_Battle_Clone.Runtime.Battles.Infrastructure.Dialogs;

namespace Pokemon_Battle_Clone.Runtime.Battles.Control.EventHandlers
{
    public class RecoverHealthEventHandler : IBattleEventHandler<RecoverHealthEvent>
    {
        private readonly IBattleContext _battleContext;
        private readonly IDialogDisplay _dialogDisplayer;

        public RecoverHealthEventHandler(IBattleContext battleContext, IDialogDisplay dialogDisplayer)
        {
            _battleContext = battleContext;
            _dialogDisplayer = dialogDisplayer;
        }
        
        public async Task Handle(RecoverHealthEvent battleEvent)
        {
            var view = _battleContext.GetTeamView(battleEvent.Side);
            
            view.UpdateHealth(battleEvent.PokemonHealth.Max, battleEvent.PokemonHealth.Current, animated: true);
            await _dialogDisplayer.DisplayAsync($"{battleEvent.PokemonName} regained health!");
        }
    }
}