namespace SIPCS.DAL.Repositories
{
    internal  interface IRepositoryHelpers<T>
    {
        static T? GetById(int id)
        {
            return default; // ضمان إرجاع قيمة حتى لو لم يتحقق الشرط
        }
    }
}