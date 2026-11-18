using System.Data;

namespace SIPCS.DAL.Repositories;

public static class DataTableExtensions
{
    public static DataTable ToShortDataTable<T>(
        this IEnumerable<T> source)
    {
        var dataTable = new DataTable();
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            var propertyType =
                Nullable.GetUnderlyingType(property.PropertyType)
                ?? property.PropertyType;

            dataTable.Columns.Add(property.Name, propertyType);
        }

        foreach (var item in source)
        {
            var values = properties
                .Select(property => property.GetValue(item) ?? DBNull.Value)
                .ToArray();

            dataTable.Rows.Add(values);
        }

        return dataTable;
    }
}