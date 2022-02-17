using LegoCaseLogic.Models;
using LegoCaseLogic.Models.Comparers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoCaseLogic.Services
{
    public class MaterialFilters
    {
        private readonly List<Material> AllMaterials;
        public MaterialFilters(List<Material> mats)
        {
            AllMaterials = mats;
        }

        public List<Material> GetMaterialsByName(string name)
        {
            return AllMaterials.Where(x => x.Name == name).ToList();
        }

        public List<string> GetOneOfEachMaterialName()
        {
            return AllMaterials.GroupBy(x => x.Name).Select(x => x.First().Name).ToList();
        }

        public List<Material> FilterByVendorId(int id)
        {
            return AllMaterials.Where(x => x.VendorID == id).ToList();
        }

        public void SortByPricePerUnit(List<Material> input)
        {
            input.Sort(new MaterialPriceComparer());
        }

        public void SortByFastestDelivery(List<Material> input)
        {
            input.Sort(new MaterialByFastestDeliveryComparer());
        }
    }
    

    
}
