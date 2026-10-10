using Microsoft.Data.SqlClient;
using SIPCS.Common.Models;
using SIPCS.DAL.Helpers;

namespace SIPCS.DAL.Repositories
{
    public class WarehousesRepository : IRepository<Warehouse>
    {
        public List<Warehouse> GetAll()
        {
            var warehouses = new List<Warehouse>();
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT WarehouseID, WarehouseName, Location
                FROM Warehouses
                ORDER BY WarehouseName", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                warehouses.Add(new Warehouse
                {
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                    Location = reader.IsDBNull(reader.GetOrdinal("Location"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("Location"))
                });
            }

            return warehouses;
        }

        public Warehouse? GetById(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                SELECT WarehouseID, WarehouseName, Location
                FROM Warehouses
                WHERE WarehouseID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Warehouse
                {
                    WarehouseID = reader.GetInt32(reader.GetOrdinal("WarehouseID")),
                    WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                    Location = reader.IsDBNull(reader.GetOrdinal("Location"))
                        ? null
                        : reader.GetString(reader.GetOrdinal("Location"))
                };
            }

            return null;
        }

        public bool Insert(Warehouse warehouses)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                INSERT INTO Warehouses (WarehouseName, Location)
                VALUES (@WarehouseName, @Location)", conn);

            cmd.Parameters.AddWithValue("@WarehouseName", warehouses.WarehouseName);
            cmd.Parameters.AddWithValue("@Location",
                (object?)warehouses.Location ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Warehouse warehouses)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(@"
                UPDATE Warehouses
                SET WarehouseName = @WarehouseName,
                    Location = @Location
                WHERE WarehouseID = @WarehouseID", conn);

            cmd.Parameters.AddWithValue("@WarehouseName", warehouses.WarehouseName);
            cmd.Parameters.AddWithValue("@Location",
                (object?)warehouses.Location ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@WarehouseID", warehouses.WarehouseID);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = DatabaseHelper.GetConnection();
            conn.Open();

            var cmd = new SqlCommand(
                "DELETE FROM Warehouses WHERE WarehouseID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return cmd.ExecuteNonQuery() > 0;
        }

       
    }
}
