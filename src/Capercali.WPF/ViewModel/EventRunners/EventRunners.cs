using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Capercali.WPF.ViewModel.EventConfiguration;
using Capercali.WPF.ViewModel.Main;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.EventRunners
{
    public class EventRunnersViewModel : ReactiveObject, IEventRunnersViewModel
    {
        private readonly IEventRunnersService runnersService;
        private readonly IEventConfigurationViewModel eventConfiguration;

        public Event Event { get; private set; }

        public EventRunnersViewModel(IEventRunnersService runnersService, IEventConfigurationViewModel eventConfiguration , IMainViewModel mainViewModel)
          {
            this.runnersService = runnersService;
            this.eventConfiguration = eventConfiguration;
            Event = mainViewModel.SelectedEvent;
            InitRegisterRunner();
        }

        private void InitRegisterRunner()
        {
            var collection = eventConfiguration.Courses.CreateDerivedCollection(model => model.ToCourse());
            RegisterRunner = new EditEventRunnerViewModel(new EventRunner(), collection);
            RegisterRunner.Save.Subscribe(_ =>
            {
                runnersService.UpdateRunners(Event.Id, RegisterRunner.Runner);
                RegisterRunner.Runner = new EventRunner();
            });
        }

        private EditEventRunnerViewModel registerRunner;

        public EditEventRunnerViewModel RegisterRunner
        {
            get { return registerRunner; }
            set { this.RaiseAndSetIfChanged(ref registerRunner, value); }
        }
    }
}
