using System.Threading.Tasks;

namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain
{
    public enum Side
    {
        Player, Rival
    }
    
    public abstract class TrainerAction
    {
        public abstract int Priority { get; }
        public readonly Side Side;

        protected TrainerAction(Side side)
        {
            Side = side;
        }

        public abstract Task Execute();
    }
}