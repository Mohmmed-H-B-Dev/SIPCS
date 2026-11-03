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

      
        //General Info

        static int IdWarehouse = 1;
        static string NameWarehouse = "Oud Elite";
    }
}
