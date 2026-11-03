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
                int newQuantity;
                if (int.TryParse(dgvCartMenuItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(), out newQuantity))
                {
                    // Update the quantity in the warehouse
                    string sku = dgvCartMenuItems.Rows[e.RowIndex].Cells["clmSKU"].Value.ToString();
                    Common_StockDetails item = POS_General.lItemsWarehouse.FirstOrDefault(x => x.SKU == sku);
                    if (item != null)
                    {
                        // Calculate the difference between the old and new quantity
                        int oldQuantity = item.Quantity;
                        int difference = newQuantity - oldQuantity;
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
            لازم انشاء جدول في قاعدة البيانات باسم POS_Invoice_Header و
                POS_Invoice_Details وربطهم مع بعضهم البعض وربطهم مع جدول المخزن


                وجدول لمعاملات الدفع POS_Payment_Transactions وربطهم مع بعضهم البعض وربطهم مع جدول الفاتورة

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            لازم نسوي جدول في قاعدة البيانات باسم POS_Reports وربطهم مع بعضهم البعض وربطهم
                مع جدول المخزن وجدول الفاتورة وجدول معاملات الدفع
                 ونعمل باصفحة في البرنامج لعرض التقارير حسب التاريخ ونوع الفاتورة ونوع الدفع ونوع المخزن ونوع المنتج
                والتاريخ بين فترتين
        }
    }
}
