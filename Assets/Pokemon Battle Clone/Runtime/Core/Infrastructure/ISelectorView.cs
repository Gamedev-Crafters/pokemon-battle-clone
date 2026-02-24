namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public interface ISelectorView
    {
        void Hide();
        void Show(bool forceSelection);
    }
}