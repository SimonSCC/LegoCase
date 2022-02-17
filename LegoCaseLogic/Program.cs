using LegoCaseLogic.Models;
using LegoCaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LegoCaseLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonService serv = new();
            MaterialVendorDataSource dataAsObjs = serv.JSONToObjList<MaterialVendorDataSource>("material_vendor_data.json");
            List<MaterialSource> matsVendor1 = dataAsObjs.Materials.Where(x => x.VendorID == 1).ToList();
            Console.WriteLine();
        }
    }
}
