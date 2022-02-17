using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoCaseLogic.Models.Comparers
{
    public class MaterialByFastestDeliveryComparer : Comparer<Material>
    {
       
        public override int Compare(Material x, Material y)
        {
            if (x.DeliveryTimeDays > y.DeliveryTimeDays)
                return 1;
            if (x.DeliveryTimeDays < y.DeliveryTimeDays)
                return -1;

            return 0;
        }
    }
}
