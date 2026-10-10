# 🛒 SIPCS — Smart Inventory · Point of Sale · Commission System

## هيكل المشروع

```
SIPCS_Solution/
├── SIPCS.Common/          ← النماذج والـ Enums المشتركة
│   ├── Models/            ← كلاسات البيانات (Product, User, ...)
│   └── Enums/             ← التعدادات (PaymentType, ...)
│
├── SIPCS.DAL/             ← طبقة الوصول للبيانات
│   ├── Helpers/           ← DatabaseHelper (إعداد الاتصال هنا)
│   └── Repositories/      ← كلاس لكل جدول (CRUD)
│
├── SIPCS.BLL/             ← طبقة منطق العمل
│   └── Services/
│       ├── InventoryModule/   ← منطق المخزون والجرد
│       ├── POSModule/         ← منطق نقطة البيع
│       ├── CommissionModule/  ← منطق العمولات
│       └── UserModule/        ← منطق المستخدمين
│
└── SIPCS.UI/              ← واجهة المستخدم (WinForms)
    └── Forms/
        ├── LoginForm      ← شاشة تسجيل الدخول ✅
        └── MainForm       ← الشاشة الرئيسية ✅
```

## خطوات التشغيل

1. **أنشئ قاعدة البيانات** في SQL Server باسم `SIPCS_DB`
2. **نفّذ ملف الـ ERD** لإنشاء الجداول
3. **عدّل الاتصال** في `SIPCS.DAL/Helpers/DatabaseHelper.cs`
4. **افتح** `SIPCS.sln` في Visual Studio 2022
5. **Restore NuGet Packages** ثم **Build Solution**
6. **شغّل** المشروع SIPCS.UI

## الاتصال بقاعدة البيانات
```csharp
// في DatabaseHelper.cs - عدّل هذا السطر
private static string _connectionString =
    "Server=.;Database=SIPCS_DB;Integrated Security=True;TrustServerCertificate=True;";
```

## الوحدات المكتملة ✅
- [x] هيكل المشروع الكامل (4 طبقات)
- [x] جميع النماذج (Models)
- [x] UserRepository + ProductRepository
- [x] UserService (تسجيل دخول + تشفير)
- [x] StockService (مخزون + سندات استلام)
- [x] SalesService (فاتورة كاملة + خصم مخزون)
- [x] CommissionService (احتساب تلقائي)
- [x] LoginForm + MainForm

## الوحدات القادمة 🚧
- [ ] شاشة إدارة المنتجات
- [ ] شاشة نقطة البيع (POS)
- [ ] شاشة الجرد الذاتي
- [ ] شاشة العمولات
- [ ] التقارير
