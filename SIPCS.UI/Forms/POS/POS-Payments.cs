using SIPCS.BLL.Services.UserModule;
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
    public partial class POS_Payments : SIPCSStyles
    {
        decimal grandTotal = 0; // لحساب إجمالي الفاتورة بالكامل
        public POS_Payments()
        {
            InitializeComponent();
            LoadData();
            txtTotal.Text = "0.00 ر.س"; // عرض صفر إذا كانت السلة فارغة
            LoadCartToListView();
        }

        void LoadData()
        {
            // إعداد خصائص الـ ListView الأساسية
            listViewCart.View = View.Details;
            listViewCart.FullRowSelect = true;
            listViewCart.GridLines = true; // اختياري: لإظهار خطوط جدول فاصلة بين الأعمدة

            // إضافة الأعمدة (اسم المنتج، الكمية، السعر الفردي، الإجمالي)
            listViewCart.Columns.Clear();
            listViewCart.Columns.Add("Name Product", 150, HorizontalAlignment.Left);
            listViewCart.Columns.Add("Quantity", 70, HorizontalAlignment.Center);
            listViewCart.Columns.Add("Price", 80, HorizontalAlignment.Right);
            //     listViewCart.Columns.Add("Total", 90, HorizontalAlignment.Right);

        }

        // افترض أنك تملك كلاس أو نموذج للمنتج (Product) أو عنصر السلة (CartItem)
        public void LoadCartToListView()
        {
            // تفريغ أي بيانات قديمة لمنع التكرار
            listViewCart.Items.Clear();
            if (General_Classes.POS_General.CartItems == null || General_Classes.POS_General.CartItems.Count == 0)
            {
                txtTotal.Text = "0.00 ر.س"; // عرض صفر إذا كانت السلة فارغة
                return;
            }
          

            // المرور على عناصر السلة العامة (مثلا GlobalCart.Items أو أي اسم لديك)
            foreach (var item in General_Classes.POS_General.CartItems)
            {
                // حساب إجمالي السطر (الكمية × السعر)
                decimal rowTotal = item.Quantity * item.UnitPrice;
                grandTotal += rowTotal;

                // إنشاء العنصر الأساسي (اسم المنتج)
                ListViewItem lvi = new ListViewItem(item.ProductName);

                // إضافة التفاصيل الفرعية (SubItems) بنفس ترتيب الأعمدة التي أضفناها
                lvi.SubItems.Add(item.Quantity.ToString());
                lvi.SubItems.Add(item.UnitPrice.ToString("N2")); // تنسيق المبلغ برقمين عشريين
                lvi.SubItems.Add(rowTotal.ToString("N2"));

                // ربط الكائن الأصلي بـ Tag لسهولة الوصول إليه لاحقاً إذا أردت
                lvi.Tag = item;

                // إضافة الصف إلى الـ ListView
                listViewCart.Items.Add(lvi);
            }

            // عرض إجمالي الفاتورة النهائي في الـ TextBox المخصص تحته
            txtTotal.Text = grandTotal.ToString("N2") + " ر.س";
        }

        private void btnPayed_Click(object sender, EventArgs e)
        {

        }


        List<Common.Models.TVP.PaymentMethodTableType> _AddPaymentMethod()
        {
            // هنا يمكنك إضافة الكود لإضافة طريقة الدفع إلى قائمة طرق الدفع
            // على سبيل المثال، يمكنك إنشاء كائن جديد من نوع PaymentMethodTableType وإضافته إلى قائمة


            List<Common.Models.TVP.PaymentMethodTableType> paymentMethods = new List<Common.Models.TVP.PaymentMethodTableType>();

            if (txtCash.Text != "")
            {
                decimal cashAmount = decimal.Parse(txtCash.Text);
                paymentMethods.Add(new Common.Models.TVP.PaymentMethodTableType
                {
                    PaymentMethod = txtCash.Tag.ToString(), // أو أي معرف آخر لطريقة الدفع
                    Amount = cashAmount,
                    PaymentStatus="Completed",
                    ProcessedByUserID=UserService.CurrentUser.UserID
                });
            }

            if (txtCredit.Text != "")
            {
                decimal creditCardAmount = decimal.Parse(txtCredit.Text);
                paymentMethods.Add(new Common.Models.TVP.PaymentMethodTableType
                {
                    PaymentMethod = txtCredit.Tag.ToString(), // أو أي معرف آخر لطريقة الدفع
                    Amount = creditCardAmount,
                    PaymentStatus="Completed",
                    ProcessedByUserID=UserService.CurrentUser.UserID
                });
            }
            if (txtCard.Text != "")
            {
                decimal cardAmount = decimal.Parse(txtCard.Text);
                paymentMethods.Add(new Common.Models.TVP.PaymentMethodTableType
                {
                    PaymentMethod = txtCard.Tag.ToString(), // أو أي معرف آخر لطريقة الدفع
                    Amount = cardAmount,
                    PaymentStatus="Completed",
                    ProcessedByUserID=UserService.CurrentUser.UserID
                });
            }

            if (txtWallet.Text != "")
            {
                decimal walletAmount = decimal.Parse(txtWallet.Text);
                paymentMethods.Add(new Common.Models.TVP.PaymentMethodTableType
                {
                    PaymentMethod = txtWallet.Tag.ToString(), // أو أي معرف آخر لطريقة الدفع
                    Amount = walletAmount,
                    PaymentStatus="Completed",
                    ProcessedByUserID=UserService.CurrentUser.UserID
                });
            }
            if (txtBankTransfer.Text != "")
            {
                decimal bankTransferAmount = decimal.Parse(txtBankTransfer.Text);
                paymentMethods.Add(new Common.Models.TVP.PaymentMethodTableType
                {
                    PaymentMethod = txtBankTransfer.Tag.ToString(), // أو أي معرف آخر لطريقة الدفع
                    Amount = bankTransferAmount,
                    PaymentStatus="Completed",
                    ProcessedByUserID=UserService.CurrentUser.UserID
                });
            }

            return paymentMethods;


        }

        bool CheckPaymentMethodsTotal()
        {
            decimal totalPaid = 0;


            if (txtCash.Text != "")
            {
                decimal cashAmount = decimal.Parse(txtCash.Text);
                totalPaid+= cashAmount;
            }

            if (txtCredit.Text != "")
            {
                decimal creditCardAmount = decimal.Parse(txtCredit.Text);
                totalPaid+= creditCardAmount;
              
            }
            if (txtCard.Text != "")
            {
                decimal cardAmount = decimal.Parse(txtCard.Text);
                totalPaid+= cardAmount;
            }

            if (txtWallet.Text != "")
            {
                decimal walletAmount = decimal.Parse(txtWallet.Text);
                totalPaid+= walletAmount;
            }
            if (txtBankTransfer.Text != "")
            {
                decimal bankTransferAmount = decimal.Parse(txtBankTransfer.Text);
                totalPaid+= bankTransferAmount;
            }

            if (totalPaid != grandTotal)
            {
             //   MessageBox.Show($"The total paid amount ({totalPaid}) does not match the grand total ({grandTotal}). Please adjust the payment methods.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  throw new InvalidOperationException("Payment methods total does not match grand total.");
            return false;
            }

            return true;
        }
        void _SeverPayed()
        {
                // هنا يمكنك وضع الكود لمعالجة الدفع، مثل إرسال البيانات إلى قاعدة البيانات أو أي عملية أخرى
                // بعد معالجة الدفع، يمكنك مسح السلة وتحديث واجهة المستخدم
                // General_Classes.POS_General.CartItems.Clear();
                //LoadCartToListView();


            if(!CheckPaymentMethodsTotal())
                {
                    MessageBox.Show($"The total paid amount does not match the grand total ({grandTotal}). Please adjust the payment methods.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            List<Common.Models.TVP.PaymentMethodTableType> paymentMethods = new List<Common.Models.TVP.PaymentMethodTableType>();
            List<Common.Models.TVP.InvoiceDetailTableType> invoiceDetails = new List<Common.Models.TVP.InvoiceDetailTableType>();
            

            paymentMethods=_AddPaymentMethod();

            foreach (var item in General_Classes.POS_General.CartItems)
                {
                    invoiceDetails.Add(new Common.Models.TVP.InvoiceDetailTableType
                    {
                        ProductId = item.ProductID,
                        SKU = item.SKU,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        DiscountAmount = 0,
                        TaxRate =(decimal) General_Classes.POS_General.TaxPercentage,
                        TaxAmount =(item.Quantity * item.UnitPrice )* (decimal) General_Classes.POS_General.TaxPercentage,
                        UnitCost = item.UnitPrice-item.UnitPrice * 0.1m // افترض خصم 10% كمثال
                    });
              
                }





        }
    }  
}