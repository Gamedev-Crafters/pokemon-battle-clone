using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Moves.Domain;
using UnityEngine;

namespace Pokemon_Battle_Clone.Runtime.Moves.Infrastructure
{
    public struct MoveDTO
    {
        public int MaxPP;
        public int CurrentPP;
        public string Name;
    }
    
    public struct MoveSetDTO
    {
        public List<MoveDTO> Moves;

        public static MoveSetDTO Get(MoveSet moveSet)
        {
            var dto = new MoveSetDTO { Moves = new List<MoveDTO>() };

            foreach (var move in moveSet.Moves)
            {
                Debug.Log($"Adding move {move.Name} to DTO");
                dto.Moves.Add(new MoveDTO
                {
                    MaxPP = move.PP.Max,
                    CurrentPP = move.PP.Value,
                    Name = move.Name
                });
            }
            
            return dto;
        }
    }
}