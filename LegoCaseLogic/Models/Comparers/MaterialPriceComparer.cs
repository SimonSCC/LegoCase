using LegoCaseLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LegoCaseLogic.Models.Comparers
{
    public class MaterialPriceComparer : Comparer<Material>
    {
        //Exchange rate to DKK ex. 1 usd == 6.5476 dkk
        private readonly ReadOnlyDictionary<Material.CurrencyEnumeration, double> ConversionRates = new ReadOnlyDictionary<Material.CurrencyEnumeration, double>(
           new Dictionary<Material.CurrencyEnumeration, double>()
           {
                    { Material.CurrencyEnumeration.DKK, 1 },
                    { Material.CurrencyEnumeration.EURO, 7.43902  },
                    { Material.CurrencyEnumeration.POUND, 8.91158  },
                    { Material.CurrencyEnumeration.USD,  6.54096  },
           });

        //Conversion rate for different units of measurements to KG
        private readonly ReadOnlyDictionary<Material.UnitEnumeration, double> UnitConversionRates = new ReadOnlyDictionary<Material.UnitEnumeration, double>(
          new Dictionary<Material.UnitEnumeration, double>()
          {
                    { Material.UnitEnumeration.kg, 1 },
                    { Material.UnitEnumeration.lbs, 2.205 },

          });

        public double ConvertToDKK(Material input, double pricePerUnitInKg)
        {
            return pricePerUnitInKg * ConversionRates.Where(x => x.Key == input.Currency).First().Value;
        }


        public double ConvertToKg(Material input)
        {
            return input.PricePerUnit * UnitConversionRates.Where(x => x.Key == input.Unit).First().Value;
        }

        public override int Compare(Material firstElem, Material secondElem)
        {
            double mat1PriceInDkkPerKg = ConvertToKg(firstElem);
            double mat2PriceInDkkPerKg = ConvertToKg(secondElem);
            mat1PriceInDkkPerKg = ConvertToDKK(firstElem, mat1PriceInDkkPerKg);
            mat2PriceInDkkPerKg = ConvertToDKK(secondElem, mat2PriceInDkkPerKg);

            if (mat1PriceInDkkPerKg < mat2PriceInDkkPerKg)
                return -1;

            if (mat1PriceInDkkPerKg > mat2PriceInDkkPerKg)
                return 1;

            return 0;
        }
    }
}
