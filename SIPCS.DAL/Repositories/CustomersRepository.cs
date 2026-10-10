using System;
using System.Collections.Generic;
using SIPCS.Common.Models;
using System.Threading.Tasks;
using SIPCS.DAL.Helpers;
using Microsoft.Data.SqlClient;

namespace SIPCS.DAL.Repositories
{
    public class CustomersRepository : IRepository<Customer>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using var conn =DatabaseHelper.GetConnection();
            var cmd =new SqlCommand ("SELECT CustomerID, CustomerName, Phone, TaxNumber FROM Customers", conn);

            using var reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                var customer = new Customer
                {
                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                    CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null :
                    reader.GetString(reader.GetOrdinal("Phone")),
                    TaxNumber = reader.IsDBNull(reader.GetOrdinal("TaxNumber")) ? null : reader.GetString(reader.GetOrdinal("TaxNumber"))
                };
                customers.Add(customer);
            }

            return customers;
        }

        public Customer? GetById(int id)
        {
                        using var conn = DatabaseHelper.GetConnection();
            var cmd = new SqlCommand("SELECT 1 FROM Customers WHERE CustomerID = @CustomerID", conn);
            cmd.Parameters.AddWithValue("@CustomerID", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Customer
                {
                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                    CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null :
                    reader.GetString(reader.GetOrdinal("Phone")),
                    TaxNumber = reader.IsDBNull(reader.GetOrdinal("TaxNumber")) ? null : reader.GetString(reader.GetOrdinal("TaxNumber"))
                };
            }

            return null;
        }

        public bool Insert(Customer entity)
        {
         using var conn = DatabaseHelper.GetConnection();
            var cmd = new SqlCommand("INSERT INTO Customers (CustomerName, Phone, TaxNumber) VALUES (@CustomerName, @Phone, @TaxNumber)", conn);
            cmd.Parameters.AddWithValue("@CustomerName", entity.CustomerName);
            cmd.Parameters.AddWithValue("@Phone",(object?)entity.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TaxNumber", (object?)entity.TaxNumber ?? DBNull.Value);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public bool Update(Customer entity)
        {
            using var conn = DatabaseHelper.GetConnection();
            var cmd = new SqlCommand("UPDATE Customers SET CustomerName = @CustomerName, Phone = @Phone, TaxNumber = @TaxNumber WHERE CustomerID = @CustomerID", conn);
            cmd.Parameters.AddWithValue("@CustomerID", entity.CustomerID);
            cmd.Parameters.AddWithValue("@CustomerName", entity.CustomerName);
            cmd.Parameters.AddWithValue("@Phone", (object?)entity.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TaxNumber", (object?)entity.TaxNumber ?? DBNull.Value);
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
