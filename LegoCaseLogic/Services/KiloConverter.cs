using LegoCaseLogic.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LegoCaseLogic.Services
{
    public class KiloConverter
    {
        //Conversion rate for different units of measurements to KG

        private readonly ReadOnlyDictionary<Material.UnitEnumeration, double> UnitConversionRates = new ReadOnlyDictionary<Material.UnitEnumeration, double>(
          new Dictionary<Material.UnitEnumeration, double>()
          {
                    { Material.UnitEnumeration.kg, 1 },
                    { Material.UnitEnumeration.lbs, 2.205 },

          });

        public double ConvertToKg(Material input)
        {
            return input.PricePerUnit * UnitConversionRates.Where(x => x.Key == input.Unit).First().Value;
        }
    }
}
