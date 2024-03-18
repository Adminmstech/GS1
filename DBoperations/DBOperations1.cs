using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GS.DBoperations
{
    public class DBOperations1
    {
        private static string connectionString = @"Data Source=Gmiaustraliadb.c93jjclziv58.ap-southeast-2.rds.amazonaws.com;User Id=GmiAus;password=^HStAg3b;Initial Catalog=PMS;persist security info=True";

       
        /// <summary>
        /// Get multiple records of a single table
        /// </summary>
        /// <param name="spName">Stored procedure name or Query text</param>
        /// <param name="commandType">if sp stored procedure else text</param>
        /// <param name="Parameters">Parameters</param>
        /// <returns></returns>
        public static IEnumerable<T> Get<T>(string spName, DynamicParameters Parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                return sqlConnection.Query<T>(spName, commandType: CommandType.StoredProcedure, param: Parameters);
            }

        }
        public static void ExecutewithoutReturn(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                sqlConnection.Open();

                sqlConnection.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                return (T)Convert.ChangeType(sqlConnection.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));

            }
        }
        
    }
}
