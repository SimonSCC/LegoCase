using System.Collections.Generic;

namespace LegoCaseLogic.Models
{
    public class MaterialVendorData
    {
        public List<Material> Materials { get; set; }
        public List<VendorSource> Vendors { get; set; }

        public MaterialVendorData(MaterialVendorDataSource sourceData)
        {
            Materials = new();
            foreach (MaterialSource sourcemat in sourceData.Materials)
            {
                Materials.Add(new Material(sourcemat));
            }
            Vendors = sourceData.Vendors;
        }
    }
}
