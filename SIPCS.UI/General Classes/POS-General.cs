using SIPCS.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPCS.UI.General_Classes
{
    public class POS_General
    {
        public static List<Common_StockDetails> lItemsWarehouse {  get; set; }

        public static List<Common_StockDetails> CartItems { get; set; }
        public static double TaxPercentage = 0.15;

        public static string BranchName = Environment.MachineName;
        static int IdWarehouse = 1;
      //  static string NameWarehouse = "Oud Elite";
    }
}
