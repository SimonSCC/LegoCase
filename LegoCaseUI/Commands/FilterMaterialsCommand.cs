using LegoCaseLogic.Models;
using LegoCaseUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoCaseUI.Commands
{
    public class FilterMaterialsCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly Func<object, List<Material>> filterMethod;


        public FilterMaterialsCommand(MainViewModel mainViewModel, Func<object, List<Material>> filterMethod)
        {
            this.mainViewModel = mainViewModel;
            this.filterMethod = filterMethod;
        }

        public override void Execute(object parameter)
        {
            //Clear observable collection and add to it, to trigger INotifyCollectionChanged.
            mainViewModel.MaterialsFiltered.Clear();
            foreach (Material material in filterMethod(parameter))
            {
                mainViewModel.MaterialsFiltered.Add(material);
            }
        }
    }
}
