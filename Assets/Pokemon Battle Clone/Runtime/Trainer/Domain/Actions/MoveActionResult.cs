namespace Pokemon_Battle_Clone.Runtime.Trainer.Domain.Actions
{
    public class MoveActionResult : TrainerActionResult
    {
        public string MoveName;
        public string UserName;
        public bool Failed;
        public bool TargetFainted;
        public bool TargetDamaged;
    }
}