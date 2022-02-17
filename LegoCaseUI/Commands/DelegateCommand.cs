using LegoCaseLogic.Models;
using LegoCaseUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
