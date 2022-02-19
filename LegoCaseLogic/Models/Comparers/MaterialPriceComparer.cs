using LegoCaseLogic.Services;
using System.Collections.Generic;
namespace LegoCaseLogic.Models.Comparers
{
    public class MaterialPriceComparer : Comparer<Material>
    {
        private readonly DkkConverter dkkConverter;
        private readonly KiloConverter kiloConverter;

        public MaterialPriceComparer(DkkConverter dkkConverter, KiloConverter kiloConverter)
        {
            this.dkkConverter = dkkConverter;
            this.kiloConverter = kiloConverter;
        }

        public override int Compare(Material firstElem, Material secondElem)
        {
            double mat1PriceInDkkPerKg = kiloConverter.ConvertToKg(firstElem);
            double mat2PriceInDkkPerKg = kiloConverter.ConvertToKg(secondElem);
            mat1PriceInDkkPerKg = dkkConverter.ConvertToDKK(firstElem, mat1PriceInDkkPerKg);
            mat2PriceInDkkPerKg = dkkConverter.ConvertToDKK(secondElem, mat2PriceInDkkPerKg);

            if (mat1PriceInDkkPerKg < mat2PriceInDkkPerKg)
                return -1;

            if (mat1PriceInDkkPerKg > mat2PriceInDkkPerKg)
                return 1;

            return 0;
        }
    }
}
