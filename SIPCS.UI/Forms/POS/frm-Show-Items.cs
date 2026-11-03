using SIPCS.BLL.Services.InventoryModule;
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
    public partial class frm_Show_Items : SIPCS.UI.Forms.SIPCSStyles
    {
        public delegate void frm_Show_ItemsEventHandler(string SKU);
        public event frm_Show_ItemsEventHandler onGetItem;
        public frm_Show_Items()
        {
            InitializeComponent();
        }

        void _LoadDate()
        {
            List<Common_StockDetails> ls = new List<Common_StockDetails>();
            ls=StockService.GetAllProducts(-1);
            General_Classes.POS_General.lItemsWarehouse=ls;
            //string SKC = "";
            //string UnitPrice = "";
            //string ProductName = "";
            //string Quantity = "";
            //string CategoryName = "";
            if (ls.Count > 0)
            {
                foreach (Common_StockDetails item in ls)
                {

                    dgvCartMenuItems.Rows.Add(item.SKU, item.ProductName, item.CategoryName, item.Quantity, item.UnitPrice);
                }
            }

        }
        private void frm_Show_Items_Load(object sender, EventArgs e)
        {
            _LoadDate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvCartMenuItems.Rows.Count<=0||dgvCartMenuItems.CurrentRow.Cells[0]==null)
                return;
            
            //we return data row use observable  because we need update general data table 
            if (onGetItem != null)
            {
                onGetItem?.Invoke(dgvCartMenuItems.CurrentRow.Cells[0].ToString());
            }

          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
