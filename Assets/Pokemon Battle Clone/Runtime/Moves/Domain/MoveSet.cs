using System.Collections.Generic;
using Pokemon_Battle_Clone.Runtime.Core.Domain;
using UnityEngine.Assertions;

namespace Pokemon_Battle_Clone.Runtime.Moves.Domain
{
    public class MoveSet
    {
        public List<Move> Moves { get; private set; } = new List<Move>();

        public void AddMoves(IEnumerable<Move> moves)
        {
            foreach (var move in moves)
                AddMove(move);
        }
        
        public void AddMove(Move move)
        {
            Assert.IsNotNull(move);
            
            if (Moves.Count < 4)
                Moves.Add(move);
        }

        public void ExecuteMove(int index, Pokemon user, Pokemon target)
        {
            Assert.IsTrue(index >= 0 && index < Moves.Count);
            
            Moves[index].Execute(user, target);
        }
    }
}