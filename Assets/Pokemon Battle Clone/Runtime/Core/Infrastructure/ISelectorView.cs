namespace Pokemon_Battle_Clone.Runtime.Core.Infrastructure
{
    public interface ISelectorView<T>
    {
        void Hide();
        void Show(bool forceSelection, T data);
    }
}