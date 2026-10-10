using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SIPCS.BLL.Exceptions;

namespace SIPCS.Common.Exceptions
{
    public class ExceptionHelper
    {


        public ExceptionHelper() { }
       
        public BusinessException Convert( Exception ex)
        {
            if (ex is SqlException sqlEx)
            {
                return new(GetSQLMessage(sqlEx));
            }else
                {
                return new("There an unexpected error: " + ex.Message);
            }
        }

    public static string GetSQLMessage(SqlException ex)
        {
            return ex.Number switch
            {
                547 => "This record cannot be deleted because it is related to other data.",
                2601 => "The data already exists.",
                2627 => "The data is duplicated.",
                _ => "An error occurred while interacting with the database."

            };
        }
    }
}
