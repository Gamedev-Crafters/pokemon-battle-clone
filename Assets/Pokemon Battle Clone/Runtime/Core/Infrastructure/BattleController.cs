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

                _battleFinished = await CheckBattleEndAsync();
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
                await action.Execute();
        }

        private async Task EndTurnAsync()
        {
            Debug.Log("End turn...");
            await Task.Delay(500);
        }

        private async Task<bool> CheckBattleEndAsync()
        {
            await Task.Delay(200);

            if (_turnCount >= 3)
            {
                Debug.Log("Battle end condition met!");
                return true;
            }

            return false;
        }

#region DEBUG
        private Team BuildPlayerTeam()
        {
            var iceFang = A.Move.WithName("Ice Fang")
                .WithAccuracy(100)
                .WithPower(65)
                .WithPP(16)
                .WithCategory(MoveCategory.Physical)
                .WithType(ElementalType.Ice);
            var waterGun = A.Move.WithName("Water Gun")
                .WithAccuracy(100)
                .WithPower(50)
                .WithPP(16)
                .WithCategory(MoveCategory.Special)
                .WithType(ElementalType.Water);
            var totodile = A.Pokemon.WithName("Totodile")
                .WithLevel(50)
                .WithBaseStats(new StatSet(hp: 50, attack: 65, defense: 64, spcAttack: 44, spcDefense: 48, speed: 43))
                .WithTypes(ElementalType.Water)
                .WithNature(Nature.Adamant())
                .WithIVs(new StatSet(31, 31, 31, 31, 31, 31))
                .WithEVs(new StatSet(hp: 6, attack: 252, defense: 0, spcAttack: 0, spcDefense: 0, speed: 252))
                .WithMoves(iceFang, waterGun);

            return new Team(totodile);
        }

        private Team BuildRivalTeam()
        {
            var wingAttack = A.Move.WithName("Wing attack")
                .WithAccuracy(100)
                .WithPower(65)
                .WithPP(16)
                .WithCategory(MoveCategory.Physical)
                .WithType(ElementalType.Flying);
            var pidgey = A.Pokemon.WithName("Pidgey")
                .WithLevel(50)
                .WithBaseStats(new StatSet(hp: 40, attack: 45, defense: 40, spcAttack: 35, spcDefense: 35, speed: 56))
                .WithTypes(ElementalType.Flying, ElementalType.Normal)
                .WithNature(Nature.Adamant())
                .WithIVs(new StatSet(31, 31, 31, 31, 31, 31))
                .WithEVs(new StatSet(hp: 6, attack: 252, defense: 0, spcAttack: 0, spcDefense: 0, speed: 252))
                .WithMoves(wingAttack);

            return new Team(pidgey);
        }
#endregion
    }
}