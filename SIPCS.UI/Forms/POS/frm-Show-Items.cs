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
        public frm_Show_Items()
        {
            InitializeComponent();
        }

        void _LoadDate()
        {
            DataTable dt = new DataTable();
            dt=BLL.Services.POSModule.SalesService.GetAllProducts(-1);
            General_Classes.POS_General.dtItemsWarehouse=dt;
            //string SKC = "";
            //string UnitPrice = "";
            //string ProductName = "";
            //string Quantity = "";
            //string CategoryName = "";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {

                    dgvCartMenuItems.Rows.Add(item["SKC"], item["ProductName"], item["CategoryName"], item["Quantity"], item["UnitPrice"]);
                }
            }

        }
        private void frm_Show_Items_Load(object sender, EventArgs e)
        {
            _LoadDate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //we return data row use observable  because we need update general data table 
            عشان لما نضيف عصنر للسلة ينقص من الداتا تيبول الاساسي عشان مانضيف كميات بلا حدود ونبيع فاتورة ونتفاجاء ان 
                ان محتوى السلة من الكمية اكبر من المخزون
            
        }
    }
}
