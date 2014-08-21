namespace Capercali.WPF.ViewModel
{
    class EventPageViewModel : IEventPageViewModel
    {
        private readonly IMainViewModel mainViewModel;

        public EventPageViewModel(IMainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
    }
}