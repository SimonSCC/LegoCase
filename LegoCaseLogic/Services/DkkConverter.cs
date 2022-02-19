using LegoCaseLogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoCaseLogic.Services
{
    public class DkkConverter
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

        public double ConvertToDKK(Material input, double pricePerUnitInKg)
        {
            return pricePerUnitInKg * ConversionRates.Where(x => x.Key == input.Currency).First().Value;
        }
    }
}
