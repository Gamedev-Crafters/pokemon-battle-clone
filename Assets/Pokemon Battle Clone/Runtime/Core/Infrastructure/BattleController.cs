using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Builders;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using Pokemon_Battle_Clone.Runtime.Stats.Domain;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public class BattleController : MonoBehaviour
    {
        public TeamView playerTeamView;
        public TeamView rivalTeamView;
        
        [Space(10)]
        
        public Sprite playerDebugSprite;
        public Sprite rivalDebugSprite;
        
        private TeamController _playerTeamController;
        private TeamController _rivalTeamController;

        private int _turnCount;
        private bool _battleFinished;
        
        private void Start()
        {
            var playerTeam = BuildPlayerTeam();
            var rivalTeam = BuildRivalTeam();

            _playerTeamController = new TeamController(true, playerTeam, playerTeamView, playerDebugSprite);
            _rivalTeamController = new TeamController(false, rivalTeam, rivalTeamView, rivalDebugSprite);

            _ = RunBattleAsync();
        }

        private void Update()
        {
            _playerTeamController.Update();
            _rivalTeamController.Update();
        }

        private async Task RunBattleAsync()
        {
            _playerTeamController.Init(_rivalTeamController);
            _rivalTeamController.Init(_playerTeamController);
            
            Debug.Log("Battle started!");
            
            while (!_battleFinished)
            {
                _turnCount++;
                Debug.Log($"--- TURN {_turnCount} ---");

                await StartTurnAsync();
                var actions = await SelectActionsAsync();
                await ExecuteActionsAsync(actions);
                await EndTurnAsync();

                _battleFinished = CheckBattleEnd();
            }
            
            Debug.Log("Battle finished!");
        }

        private async Task StartTurnAsync()
        {
            Debug.Log("Start turn...");
            await Task.Delay(500);
        }

        private async Task<List<TrainerAction>> SelectActionsAsync()
        {
            Debug.Log("Selecting actions...");
            var playerActionTask = _playerTeamController.SelectActionTask();
            var rivalActionTask = _rivalTeamController.SelectActionTask();

            await Task.WhenAll(playerActionTask, rivalActionTask);
            
            return new List<TrainerAction> { playerActionTask.Result, rivalActionTask.Result };
        }

        private async Task ExecuteActionsAsync(List<TrainerAction> actions)
        {
            var random = new System.Random();
            var orderedActions = actions.OrderByDescending(a => a.Priority)
                .ThenByDescending(a => a.PokemonInFieldSpeed)
                .ThenBy(_ => random.Next())
                .ToList();

            foreach (var action in orderedActions)
            {
                await action.Execute();
                if (CheckBattleEnd())
                    break;
            }
        }

        private async Task EndTurnAsync()
        {
            Debug.Log("End turn...");
            await Task.Delay(500);
        }

        private bool CheckBattleEnd()
        {
            if (_playerTeamController.Defeated)
            {
                Debug.Log("The rival has won!");
                return true;
            }
            if (_rivalTeamController.Defeated)
            {
                Debug.Log("The player has won!");
                return true;
            }

            return false;
        }

#region DEBUG
        private Team BuildPlayerTeam()
        {
            var totodile = PokemonFactory.Totodile();
            totodile.MoveSet.AddMoves(new List<Move>
            {
                MoveFactory.IceFang(),
                MoveFactory.WaterGun(),
                MoveFactory.QuickAttack()
            });

            return new Team(totodile);
        }

        private Team BuildRivalTeam()
        {
            var pidgey = PokemonFactory.Pidgey();
            pidgey.MoveSet.AddMoves(new List<Move>
            {
                MoveFactory.WingAttack()
            });

            return new Team(pidgey);
        }
#endregion
    }
}