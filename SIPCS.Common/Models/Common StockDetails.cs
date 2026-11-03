using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPCS.Common.Models
{
    public class Common_StockDetails
    {
        // Stock Information
        public int StockID { get; set; }
        public int WarehouseID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        // Warehouse Information
        public string WarehouseName { get; set; } = string.Empty;

        // Product Information
        public string ProductName { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public int ReorderLevel { get; set; }
        public decimal UnitPrice { get; set; }

        // Category Information
        public string CategoryName { get; set; } = string.Empty;



        public int Index {  get; set; }

    }
}

