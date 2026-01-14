using Pokemon_Battle_Clone.Runtime.Builders;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Moves;
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
        
        private void Start()
        {
            var playerTeam = BuildPlayerTeam();
            var rivalTeam = BuildRivalTeam();

            _playerTeamController = new TeamController(playerTeam, playerTeamView, playerDebugSprite);
            _rivalTeamController = new TeamController(rivalTeam, rivalTeamView, rivalDebugSprite);
            
            _playerTeamController.Init();
            _rivalTeamController.Init();
        }

        private Team BuildPlayerTeam()
        {
            var team = new Team();
            team.Add(A.Pokemon.WithName("Totodile")
                .WithLevel(50)
                .WithBaseStats(new StatSet(hp: 50, attack: 65, defense: 64, spcAttack: 44, spcDefense: 48, speed: 43))
                .WithTypes(ElementalType.Water)
                .WithNature(Nature.Adamant())
                .WithIVs(new StatSet(31, 31, 31, 31, 31, 31))
                .WithEVs(new StatSet(hp: 6, attack: 252, defense: 0, spcAttack: 0, spcDefense: 0, speed: 252))
                .WithMoves(A.Move.WithName("Ice Fang")
                    .WithAccuracy(100)
                    .WithPower(65)
                    .WithPP(16)
                    .WithCategory(MoveCategory.Physical)
                    .WithType(ElementalType.Ice)));

            return team;
        }

        private Team BuildRivalTeam()
        {
            var team = new Team();
            team.Add(A.Pokemon.WithName("Pidgey")
                .WithLevel(50)
                .WithBaseStats(new StatSet(hp: 40, attack: 45, defense: 40, spcAttack: 35, spcDefense: 35, speed: 56))
                .WithTypes(ElementalType.Flying, ElementalType.Normal)
                .WithNature(Nature.Adamant())
                .WithIVs(new StatSet(31, 31, 31, 31, 31, 31))
                .WithEVs(new StatSet(hp: 6, attack: 252, defense: 0, spcAttack: 0, spcDefense: 0, speed: 252))
                .WithMoves(A.Move.WithName("Wing attack")
                    .WithAccuracy(100)
                    .WithPower(65)
                    .WithPP(16)
                    .WithCategory(MoveCategory.Physical)
                    .WithType(ElementalType.Flying)));

            return team;
        }
    }
}