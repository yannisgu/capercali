using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public class ControlViewModel : ReactiveObject
    {
        public ControlViewModel(Control control)
        {
            Number = control.Number;
            ControlNumber = control.ControlNumber;

        }

        private int number;
        private string controlNumber;

        public int Number
        {
            get { return number; }
            set { this.RaiseAndSetIfChanged(ref number, value); }
        }

        public string ControlNumber
        {
            get { return controlNumber; }
            set { this.RaiseAndSetIfChanged(ref controlNumber, value); }
        }

        public Control ToModel()
        {
            return new Control(){ControlNumber = ControlNumber, Number = Number};
        }
    }
}