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
            frm_Show_Items frm = new frm_Show_Items();
            frm.onGetItem+=_LoadDateToCartAndHandelActiualQuauntity;
            frm.ShowDialog();
        }

        private void _LoadDateToCartAndHandelActiualQuauntity(string SKU)
        {
            Common_StockDetails item = POS_General.lItemsWarehouse.FirstOrDefault(x => x.SKU==SKU);

            if (item !=null)
            {
                //we update the quantity in this Warehouse -1
                POS_General.lItemsWarehouse[item.Index].Quantity -= 1;
                // PO[0]["Quantity"] = (int)foundRows[0]["Quantity"]-1 ;
                POS_General.CartItems.Add(
                    new Common_StockDetails
                    {
                        SKU = item.SKU,
                        ProductName = item.ProductName,
                        ReorderLevel = item.ReorderLevel,
                        UnitPrice = item.UnitPrice,

                        StockID= item.StockID,
                        WarehouseID= item.WarehouseID,
                        ProductID= item.ProductID,
                        Quantity = 1,

                        WarehouseName= item.WarehouseName,

                        CategoryName = item.CategoryName,

                        Index = item.Index


                    });

            }
            //Add new item to cart 

            dgvCartMenuItems.Rows.Add(item.SKU, item.ProductName, 1, item.UnitPrice);



        }

        private void dgvCartMenuItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex  >=0 && e.ColumnIndex == dgvCartMenuItems.Columns["clmDelete"].Index)
            {
                try
                {
                    // Get the SKU of the item to be deleted
                    string skuToDelete = dgvCartMenuItems.Rows[e.RowIndex].Cells["clmSKU"].Value.ToString();
                    // Find the item in the warehouse list
                    Common_StockDetails itemToDelete = POS_General.lItemsWarehouse.FirstOrDefault(x => x.SKU == skuToDelete);
                    if (itemToDelete != null)
                    {
                        // Update the quantity in the warehouse
                        itemToDelete.Quantity += (int)dgvCartMenuItems.Rows[e.RowIndex].Cells["clmQuantity"].Value;
                        // Remove the row from the DataGridView

                        dgvCartMenuItems.Rows.RemoveAt(e.RowIndex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the item: {ex.Message}");

                }

            }
        }

        private void dgvCartMenuItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCartMenuItems.Columns["clmQuantity"].Index)
            {
                // Get the new quantity value
                decimal newQuantity;
                if (decimal.TryParse(dgvCartMenuItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(), out newQuantity))
                {
                    // Update the quantity in the warehouse
                    string sku = dgvCartMenuItems.Rows[e.RowIndex].Cells["clmSKU"].Value.ToString();
                    Common_StockDetails item = POS_General.lItemsWarehouse.FirstOrDefault(x => x.SKU == sku);
                    Common_StockDetails Cartitem = POS_General.CartItems.FirstOrDefault(x => x.SKU == sku);

                    if (item != null && Cartitem != null&&Cartitem.SKU == item.SKU)
                    {
                        // Calculate the difference between the old and new quantity
                        decimal oldQuantity = item.Quantity;
                        decimal difference = newQuantity - oldQuantity;
                        if (newQuantity>0)
                        {
                            POS_General.CartItems[Cartitem.Index].Quantity = newQuantity;
                        }
                        // Update the warehouse quantity
                        if (difference > 0)
                            POS_General.lItemsWarehouse[item.Index].Quantity -= difference;
                        else
                        {
                            MessageBox.Show("You cannot increase the quantity beyond the available stock.");
                            dgvCartMenuItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value=1;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    // Optionally, reset the cell value to the previous valid quantity
                    dgvCartMenuItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;// POS_General.lItemsWarehouse.FirstOrDefault(x => x.SKU == dgvCartMenuItems.Rows[e.RowIndex].Cells["clmSKU"].Value.ToString())?.Quantity ?? 1;
                }
            }
        }



        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            for (int i = dgvCartMenuItems.Rows.Count - 1; i >= 0; i--)
            {
                try
                {


                    string skuToDelete = dgvCartMenuItems.Rows[i].Cells["clmSKU"].Value.ToString();
                    Common_StockDetails itemToDelete = POS_General.lItemsWarehouse.FirstOrDefault(x => x.SKU == skuToDelete);
                    if (itemToDelete != null)
                    {
                        // Update the quantity in the warehouse
                        itemToDelete.Quantity += (int)dgvCartMenuItems.Rows[i].Cells["clmQuantity"].Value;
                        dgvCartMenuItems.Rows.RemoveAt(i);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the item: {ex.Message}");
                }
            }
        }



        private void btnPayments_Click(object sender, EventArgs e)
        {

            POS_Payments frm =new POS_Payments
            ();
            frm.ShowDialog();
            //        لازم انشاء جدول في قاعدة البيانات باسم POS_Invoice_Header و
            //          POS_Invoice_Details وربطهم مع بعضهم البعض وربطهم مع جدول المخزن


            //   وجدول لمعاملات الدفع POS_Payment_Transactions وربطهم مع بعضهم البعض وربطهم مع جدول الفاتورة

            {
                //Common_StockDetails g =new Common_StockDetails();
                //g.
                //اسماء الاعمدة في جدول POS_Invoice_Header
                //    و جدول POS_Invoice_Details و جدول POS_Payment_Transactions

                //    التي يجب تمريرها ك  متغير من نوع تايب تيبول 

              
//            [PaymentMethod][nvarchar](30) NOT NULL,

                //[Amount] [decimal](18, 2) NOT NULL,

                //[PaymentStatus] [nvarchar] (20) NOT NULL,

                //[TransactionReference] [nvarchar] (200) NULL,
                //	[PaymentProvider][nvarchar](150) NULL,
                //	[CardLast4][nvarchar](4) NULL,
                //	[PaymentDate][datetime2](0) NULL,
                //	[ProcessedByUserID][int] NULL,
                //	[Notes][nvarchar](1000) NULL


              

                //[ProductID][int] NOT NULL,

                //    [ProductName] [nvarchar] (300) NOT NULL,

                //    [SKU] [nvarchar] (100) NULL,
                //	[Quantity][decimal](18, 3) NOT NULL,

                //    [UnitPrice] [decimal](18, 2) NOT NULL,

                //    [DiscountAmount] [decimal](18, 2) NOT NULL,

                //    [TaxRate] [decimal](5, 2) NOT NULL,

                //    [TaxAmount] [decimal](18, 2) NOT NULL,

                //    [UnitCost] [decimal](18, 2) NOT NULL


            }
        
        }
       
        private void btnReports_Click(object sender, EventArgs e)
        {
            //لازم نسوي جدول في قاعدة البيانات باسم POS_Reports وربطهم مع بعضهم البعض وربطهم
            //    مع جدول المخزن وجدول الفاتورة وجدول معاملات الدفع
            //     ونعمل باصفحة في البرنامج لعرض التقارير حسب التاريخ ونوع الفاتورة ونوع الدفع ونوع المخزن ونوع المنتج
            //    والتاريخ بين فترتين
        }
    }
}
