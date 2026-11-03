using SIPCS.Common.Models;
using SIPCS.UI.General_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPCS.UI.Forms.POS
{
    public partial class POS_Main : SIPCS.UI.Forms.SIPCSStyles
    {
        public POS_Main()
        {
            InitializeComponent();
        }

        private void btnShowItems_Click(object sender, EventArgs e)
        {
            frm_Show_Items frm =new frm_Show_Items();
            frm.onGetItem+=_LoadDateToCartAndHandelActiualQuauntity;
            frm.ShowDialog();
        }

        private void _LoadDateToCartAndHandelActiualQuauntity(string SKU )
        {
            Common_StockDetails item = POS_General.lItemsWarehouse.FirstOrDefault(x=> x.SKU==SKU);
      
            if (item !=null)
            {
                //we update the quantity in this Warehouse -1
                POS_General.lItemsWarehouse[item.Index].Quantity -= 1;
               // PO[0]["Quantity"] = (int)foundRows[0]["Quantity"]-1 ;
            }
           //Add new item to cart 
            dgvCartMenuItems.Rows.Add(item.SKU, item.ProductName, 1, item.UnitPrice);

     
            
        }

    }
}
