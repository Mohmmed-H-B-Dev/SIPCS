namespace SIPCS.DAL.Repositories
{
    internal static interface IRepositoryHelpers<T>
    {
        T? GetById(int id);
    }
}