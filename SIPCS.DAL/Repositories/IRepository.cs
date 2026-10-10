using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIPCS.DAL.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// This Method is used to get all the records from the database.
        /// </summary>
        /// <returns>Returns a List Of Objects of type T</returns>
        List<T> GetAll();

        /// <summary>
        /// Gets a record from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>Return an object of type T if found, otherwise null</returns>
        T? GetById(int id);

        /// <summary>
        /// Inserts a new record into the database.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>Returns true if the insert was successful, otherwise false.</returns>
        bool Insert(T entity);
        /// <summary>
        /// This Method is used to update a record in the database.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>Returns true if the update was successful, otherwise false.</returns>
        bool Update(T entity);
        /// <summary>
        /// This Method is used to delete a record from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>Returns true if the delete was successful, otherwise false.</returns>
        bool Delete(int id);

    }
}
