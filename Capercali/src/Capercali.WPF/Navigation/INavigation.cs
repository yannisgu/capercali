namespace Capercali.WPF.Navigation
{
    public interface INavigation
    {
        void Open<T>();
        void GoBack();
    }
}