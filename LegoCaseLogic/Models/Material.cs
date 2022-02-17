using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoCaseLogic.Models
{

    public class Material
    {
        public int ID { get => materialSource.ID; }
        public string Name { get => materialSource.Name; }
        public int VendorID { get => materialSource.VendorID; }
        public string Color { get => materialSource.Color; }
        public double PricePerUnit { get => materialSource.PricePerUnit; }
        public CurrencyEnumeration Currency { get; }
        public UnitEnumeration Unit { get;  }
        public int MeltingPoint { get => materialSource.MeltingPoint; }
        public string TempUnit { get => materialSource.TempUnit; }
        public int DeliveryTimeDays { get => materialSource.DeliveryTimeDays; }
        private MaterialSource materialSource { get; }


        public Material(MaterialSource source)
        {
            materialSource = source;
            Currency = Enum.Parse<CurrencyEnumeration>(source.Currency);
            Unit = Enum.Parse<UnitEnumeration>(source.Unit);

        }

        
        public enum CurrencyEnumeration
        {
            POUND,
            DKK,
            USD,
            EURO
        }

        public enum UnitEnumeration
        {
            kg,
            lbs
        }

        public override string ToString()
        {
            return $"{ID}. {Name} - {PricePerUnit}{Currency}";
        }
    }
}
