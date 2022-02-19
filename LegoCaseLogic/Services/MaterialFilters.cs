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
        private readonly List<Material> _allMaterials;
        private readonly KiloConverter _kiloConverter;
        private readonly DkkConverter _dkkConverter;
        public MaterialFilters(List<Material> mats)
        {
            _allMaterials = mats;
            _kiloConverter = new();
            _dkkConverter = new();
        }

        public List<Material> GetMaterialsByName(string name)
        {
            return _allMaterials.Where(x => x.Name == name).ToList();
        }

        public List<string> GetOneOfEachMaterialName()
        {
            return _allMaterials.GroupBy(x => x.Name).Select(x => x.First().Name).ToList();
        }

        public List<Material> FilterByVendorId(int id)
        {
            return _allMaterials.Where(x => x.VendorID == id).ToList();
        }

        public void SortByPricePerUnit(List<Material> input)
        {
            input.Sort(new MaterialPriceComparer(_dkkConverter, _kiloConverter)); ;
        }

        public void SortByFastestDelivery(List<Material> input)
        {
            input.Sort(new MaterialByFastestDeliveryComparer());
        }

        /// <summary>
        /// Sorts list of materials by best choice.
        /// A candidate for best choice is determined by including every cheaper than average and faster devlivery time than average materials.
        /// Then it is determined whether the vendor of said material is ECO friendly. If this is the case, the candidate will be included.
        /// At last the remaining candidates are sorted by price and the list is returned.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="vendorSources"></param>
        /// <returns></returns>
        public List<Material> SortByBestChoice(List<Material> input, List<VendorSource> vendorSources)
        {
            //Filter by melting point
            input = FilterByMeltingPointF(200, 300, input);

            double averagePricePerUnitInDkk = GetAveragePricePerUnit(input);
            double averageDeliveryTime = GetAverageDeliveryTime(input);

            List<Material> candidates = new();
            foreach (Material mat in input)
            {
                if (mat.PricePerUnit < averagePricePerUnitInDkk && mat.DeliveryTimeDays < averageDeliveryTime)
                {
                    foreach (VendorSource vendor in vendorSources)
                    {
                        if (vendor.ID == mat.VendorID && vendor.ECOFriendly)
                        {
                            candidates.Add(mat);
                            break;
                        }
                    }

                }
            }
            SortByPricePerUnit(candidates);
            return candidates;
        }

        private double GetAverageDeliveryTime(List<Material> input)
        {
            List<int> listOfDeliveryTimes = new();
            foreach (Material mat in input)
            {
                listOfDeliveryTimes.Add(mat.DeliveryTimeDays);
            }
            return listOfDeliveryTimes.Average();
        }

        private double GetAveragePricePerUnit(List<Material> input)
        {
            List<double> priceInDkkAndUnitInKg = new();
            foreach (Material mat in input)
            {
                double pricePerKgInDkk = _kiloConverter.ConvertToKg(mat);
                pricePerKgInDkk = _dkkConverter.ConvertToDKK(mat, pricePerKgInDkk);
                priceInDkkAndUnitInKg.Add(pricePerKgInDkk);
            }
            return priceInDkkAndUnitInKg.Average();
        }

        public List<Material> FilterByMeltingPointF(int startMeasureInC, int endMeasureInC, List<Material> listToFilter)
        {
            // Conversion f to c formula: (37,4°F − 32) × 5/9 = 3°C
            List<Material> relevantMaterials = new();
            foreach (Material mat in listToFilter)
            {
                int tempMeasureInC;
                if (mat.TempUnit != Material.TempUnitEnumeration.C)
                    tempMeasureInC = ((mat.MeltingPoint - 32) * 5 / 9);
                else
                    tempMeasureInC = mat.MeltingPoint;

                if (tempMeasureInC >= startMeasureInC && tempMeasureInC <= endMeasureInC)
                    relevantMaterials.Add(mat);
            }
            return relevantMaterials;
        }
    }



}
