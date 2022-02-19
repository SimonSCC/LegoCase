using System;

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
        public TempUnitEnumeration TempUnit { get; }
        public int DeliveryTimeDays { get => materialSource.DeliveryTimeDays; }
        private MaterialSource materialSource { get; }


        public Material(MaterialSource source)
        {
            materialSource = source;
            Currency = Enum.Parse<CurrencyEnumeration>(source.Currency);
            Unit = Enum.Parse<UnitEnumeration>(source.Unit);
            TempUnit = Enum.Parse<TempUnitEnumeration>(source.TempUnit);
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

        public enum TempUnitEnumeration
        {
            C,
            F
        }

        public override string ToString()
        {
            return $"{ID}. {Name} - {PricePerUnit}{Currency}";
        }
    }
}
