using System.Threading.Tasks;
using PokeApiNet;
using Pokemon_Battle_Clone.Runtime.Builders;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using Pokemon_Battle_Clone.Runtime.Stats.Domain;
using UnityEngine;
using Nature = Pokemon_Battle_Clone.Runtime.Stats.Domain.Nature;
using Pokemon = Pokemon_Battle_Clone.Runtime.Core.Domain.Pokemon;

namespace Pokemon_Battle_Clone.Runtime.TeamBuilder
{
    public enum NatureEnum
    {
        Hardy, Lonely, Brave, Adamant, Naughty, Bold, Docile, Relaxed, Impish, Lax, Timid, Hasty, Serious, Jolly, Naive,
        Modest, Mild, Quiet, Bashful, Rash, Calm, Gentle, Sassy, Careful, Quirky
    }
    
    [CreateAssetMenu(menuName = "Pokemon Battle Clone/Pokemon/Config", fileName = "Pokemon Config")]
    public class PokemonConfig : ScriptableObject
    {
        public int ID;
        public string name;
        public int level = 100;
        public StatSet baseStats;
        public ElementalType type1;
        public ElementalType type2;
        public NatureEnum nature;
        public StatSet ivs = new StatSet(31, 31, 31, 31, 31, 31);
        public StatSet evs;

        private static PokeApiClient _pokeClient;

        private static PokeApiClient PokeClient
        {
            get
            {
                if (_pokeClient == null)
                    _pokeClient = new PokeApiClient();
                return _pokeClient;
            }
        }

        public Pokemon Build()
        {
            return A.Pokemon.WithID((uint)ID)
                .WithName(name)
                .WithLevel(level)
                .WithBaseStats(baseStats)
                .WithTypes(type1, type2)
                .WithNature(GetNature(nature))
                .WithIVs(ivs)
                .WithEVs(evs);
        }

        [ContextMenu("Load From API")]
        public async Task LoadFromAPI()
        {
            var pokemon = await PokeClient.GetResourceAsync<PokeApiNet.Pokemon>(name);

            ID = pokemon.Id;
            baseStats = new StatSet(
                hp: pokemon.Stats[0].BaseStat,
                attack: pokemon.Stats[1].BaseStat,
                defense: pokemon.Stats[2].BaseStat,
                spcAttack: pokemon.Stats[3].BaseStat,
                spcDefense: pokemon.Stats[4].BaseStat,
                speed: pokemon.Stats[5].BaseStat
            );
            type1 = GetElementalType(pokemon.Types[0].Type.Name);
            type2 = GetElementalType(pokemon.Types[1].Type.Name);
        }

        private Nature GetNature(NatureEnum natureEnum)
        {
            return natureEnum switch
            {
                NatureEnum.Adamant => Nature.Adamant(),
                NatureEnum.Bashful => Nature.Bashful(),
                NatureEnum.Bold => Nature.Bold(),
                NatureEnum.Brave => Nature.Brave(),
                NatureEnum.Calm => Nature.Calm(),
                NatureEnum.Careful => Nature.Careful(),
                NatureEnum.Docile => Nature.Docile(),
                NatureEnum.Gentle => Nature.Gentle(),
                NatureEnum.Hardy => Nature.Hardy(),
                NatureEnum.Hasty => Nature.Hasty(),
                NatureEnum.Impish => Nature.Impish(),
                NatureEnum.Jolly => Nature.Jolly(),
                NatureEnum.Lax => Nature.Lax(),
                NatureEnum.Lonely => Nature.Lonely(),
                NatureEnum.Mild => Nature.Mild(),
                NatureEnum.Modest => Nature.Modest(),
                NatureEnum.Naive => Nature.Naive(),
                NatureEnum.Naughty => Nature.Naughty(),
                NatureEnum.Quiet => Nature.Quiet(),
                NatureEnum.Quirky => Nature.Quirky(),
                NatureEnum.Rash => Nature.Rash(),
                NatureEnum.Relaxed => Nature.Relaxed(),
                NatureEnum.Sassy => Nature.Sassy(),
                NatureEnum.Serious => Nature.Serious(),
                NatureEnum.Timid => Nature.Timid(),
                _ => Nature.Bashful()
            };
        }

        private ElementalType GetElementalType(string type)
        {
            return type switch
            {
                "bug" => ElementalType.Bug,
                "dark" => ElementalType.Dark,
                "dragon" => ElementalType.Dragon,
                "electric" => ElementalType.Electric,
                "fairy" => ElementalType.Fairy,
                "fighting" => ElementalType.Fighting,
                "fire" => ElementalType.Fire,
                "flying" => ElementalType.Flying,
                "ghost" => ElementalType.Ghost,
                "grass" => ElementalType.Grass,
                "ground" => ElementalType.Ground,
                "ice" => ElementalType.Ice,
                "normal" => ElementalType.Normal,
                "poison" => ElementalType.Poison,
                "psychic" => ElementalType.Psychic,
                "rock" => ElementalType.Rock,
                "steel" => ElementalType.Steel,
                "water" => ElementalType.Water,
                _ => ElementalType.None
            };
        }
    }
}