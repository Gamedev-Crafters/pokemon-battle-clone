using System.Threading.Tasks;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public interface ITeamView
    {
        Task SendPokemon(Pokemon pokemon, Sprite sprite);
        void UpdateHealth();

        Task PlayAttackAnimation();
        Task PlayHitAnimation();
        Task PlayFaintAnimation();
    }
}