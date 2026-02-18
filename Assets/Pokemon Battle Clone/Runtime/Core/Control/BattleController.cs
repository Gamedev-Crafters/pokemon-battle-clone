using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Core.Infrastructure;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using Pokemon_Battle_Clone.Runtime.Trainer.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Control
{
    public class BattleController : MonoBehaviour
    {
        public TeamView playerTeamView;
        public TeamView rivalTeamView;
        
        private Battle _battle;
        private TeamController _playerTeamController;
        private TeamController _rivalTeamController;
        
        private int _turnCount;
        private bool _battleFinished;
        
        private void Start()
        {
            var spriteLoader = new SpritesLoader("Assets/Pokemon Battle Clone/Sprites/Pokemon");
            
            var playerTeam = BuildPlayerTeam();
            var rivalTeam = BuildRivalTeam();
            
            _battle = new Battle(playerTeam, rivalTeam);
            
            var playerSprites = spriteLoader.LoadAllBack(playerTeam.PokemonList.Select(pokemon => pokemon.ID).ToList());
            _playerTeamController = new TeamController(true, playerTeam, playerTeamView, playerSprites);
            
            var rivalSprites = spriteLoader.LoadAllFront(rivalTeam.PokemonList.Select(pokemon => pokemon.ID).ToList());
            _rivalTeamController = new TeamController(false, rivalTeam, rivalTeamView, rivalSprites);

            _ = RunBattleAsync();
        }

        private async Task RunBattleAsync()
        {
            await _playerTeamController.Init(_rivalTeamController);
            await _rivalTeamController.Init(_playerTeamController);
            
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
            
            var tasks = new List<Task<TrainerAction>>();
            if (_playerTeamController.IsFirstPokemonDefeated)
                tasks.Add(_playerTeamController.SelectActionTask());
            if (_rivalTeamController.IsFirstPokemonDefeated)
                tasks.Add(_rivalTeamController.SelectActionTask());
            
            if (tasks.Count > 0)
            {
                await Task.WhenAll(tasks);
                foreach (var task in tasks)
                    task.Result.Execute(_battle);
            }
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
            var orderedActions = TrainerAction.OrderActions(actions);

            foreach (var action in orderedActions)
            {
                if (CheckPokemonFainted(action.Side))
                    continue;
                action.Execute(_battle);
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

        private bool CheckPokemonFainted(Side side)
        {
            return side switch
            {
                Side.Player => _playerTeamController.IsFirstPokemonDefeated,
                Side.Rival => _rivalTeamController.IsFirstPokemonDefeated,
                _ => false
            };
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
            var pidgey = PokemonFactory.Pidgey();
            pidgey.MoveSet.AddMoves(new List<Move>
            {
                MoveFactory.WingAttack(),
                MoveFactory.QuickAttack()
            });

            var team = new Team(new List<Pokemon> { totodile, pidgey });
            
            Debug.Log($"Player team: {string.Join(',', team.PokemonList.Select(p => p.Name))}");
            
            return team;
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