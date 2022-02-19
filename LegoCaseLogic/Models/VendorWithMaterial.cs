namespace LegoCaseLogic.Models
{
    public class VendorWithMaterial
    {
        public Material VendorMaterial { get; set; }
        public VendorSource Vendor { get; set; }

        public VendorWithMaterial(Material mat, VendorSource vend)
        {
            VendorMaterial = mat;
            Vendor = vend;
        }

        public override string ToString()
        {
            return $"Material: {VendorMaterial.Name}\nColor: {VendorMaterial.Color}\nPricePerUnit: {VendorMaterial.PricePerUnit}{VendorMaterial.Currency}" +
                $"\nUnit: {VendorMaterial.Unit}\nMeltingPoint: {VendorMaterial.MeltingPoint}{VendorMaterial.TempUnit}\nDeliveryTime: {VendorMaterial.DeliveryTimeDays}" +
                $"\n\nFrom vendor: {Vendor.Name}\nContact Person {Vendor.ContactPerson}\nAddress: {Vendor.PostalCode} {Vendor.Address}\nIs Eco Friendly: {Vendor.ECOFriendly}";
        }
    }
}
