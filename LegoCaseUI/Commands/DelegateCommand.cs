using System;

namespace LegoCaseUI.Commands
{
    public class DelegateCommand : CommandBase
    {
        private readonly Action<object> delegateMethod;

        public DelegateCommand(Action<object> delegateMethod)
        {
            this.delegateMethod = delegateMethod;
        }


        public override void Execute(object parameter)
        {
            delegateMethod(parameter);
        }   
    }
}
