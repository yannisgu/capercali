namespace Capercali.WPF.ViewModel
{
    internal class EventPageViewModel : IEventPageViewModel
    {
        private readonly IMainViewModel mainViewModel;

        public EventPageViewModel(IMainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
    }
}