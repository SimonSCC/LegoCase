using LegoCaseLogic.Models;
using LegoCaseLogic.Services;
using LegoCaseUI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LegoCaseUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MaterialVendorData MaterialVendorDataObj { get; private set; }
        public ObservableCollection<Material> MaterialsFiltered { get; set; }

        public List<string> AllMaterialNames { get; set; }


        private VendorWithMaterial cheapestMaterialFromVendor;

        public VendorWithMaterial CheapestMaterialFromVendor
        {
            get { return cheapestMaterialFromVendor; }
            set
            {
                cheapestMaterialFromVendor = value;
                OnPropertyChanged(nameof(CheapestMaterialFromVendor));
            }
        }



        private readonly JsonService _jsonService;
        private readonly MaterialFilters _materialFilter;


        public ICommand FilterByVendorIDCommand { get; private set; }
        public ICommand GetCheapestMaterialCommand { get; private set; }
        public MainViewModel()
        {
            _jsonService = new JsonService();
            MaterialsFiltered = new();

            MaterialVendorDataObj = new MaterialVendorData(_jsonService.JSONToObjList<MaterialVendorDataSource>("material_vendor_data.json"));
            _materialFilter = new(MaterialVendorDataObj.Materials);

            AllMaterialNames = _materialFilter.GetOneOfEachMaterialName();
            FilterByVendorIDCommand = new FilterMaterialsCommand(this, FilterByVendorId);
            GetCheapestMaterialCommand = new DelegateCommand(GetCheapestMaterial);


        }

        private List<Material> FilterByVendorId(object parameter)
        {
            VendorSource vendor = (VendorSource)parameter;
            if (vendor == null || vendor.ID == 0)
            {
                Console.WriteLine("vendor or ID is null");
                return default;
            }
            return _materialFilter.FilterByVendorId(vendor.ID);
        }

        private void GetCheapestMaterial(object parameter)
        {
            if (String.IsNullOrEmpty((string)parameter))
            {
                Console.WriteLine("Material name is null");
                return;
            }
            List<Material> materialByName = _materialFilter.GetMaterialsByName((string)parameter);
            _materialFilter.SortByPricePerUnit(materialByName);
            CheapestMaterialFromVendor = new VendorWithMaterial(materialByName[0], MaterialVendorDataObj.Vendors.Where(x => x.ID == materialByName[0].VendorID).First());
        }


    }
}
