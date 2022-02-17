using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoCaseLogic.Models
{
    public class MaterialSource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int VendorID { get; set; }
        public string Color { get; set; }
        public int PricePerUnit { get; set; }
        public string Currency { get; set; }
        public string Unit { get; set; }
        public int MeltingPoint { get; set; }
        public string TempUnit { get; set; }
        public int DeliveryTimeDays { get; set; }


        public MaterialSource()
        {
        }


        
    }
}
