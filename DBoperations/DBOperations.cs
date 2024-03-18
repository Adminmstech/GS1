using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GS.DBoperations
{
    public class DBOperations<T> : IDisposable
    {
        private IDbConnection connection;
        public DBOperations(string _connectionKey)
        {
            //** get connection string **//
            string cs = ConfigurationManager.ConnectionStrings[_connectionKey].ConnectionString;

            this.connection = new SqlConnection(cs);

        }
        public DBOperations()
        {
            //** get connection string **//
            string cs = ConfigurationManager.ConnectionStrings["PMS"].ConnectionString;

            this.connection = new SqlConnection(cs);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    connection.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Get multiple records of a single table
        /// </summary>
        /// <param name="spName">Stored procedure name or Query text</param>
        /// <param name="commandType">if sp stored procedure else text</param>
        /// <param name="Parameters">Parameters</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Get(string spName, DynamicParameters Parameters = null)
        {
            return (IEnumerable<T>)await connection.QueryAsync<T>(spName, commandType: CommandType.StoredProcedure, param: Parameters);

        }
        /// <summary>
        /// Insert and update tables
        /// </summary>
        /// <param name="spName">Stored procedure name or Query text</param>
        /// <param name="commandType">if sp stored procedure else text</param>
        /// <param name="Parameters">Parameters</param>
        /// <returns></returns>
        public async Task<int> Save(string spName, DynamicParameters Parameters = null)
        {

            return await connection.ExecuteAsync(spName, commandType: CommandType.StoredProcedure, param: Parameters);

        }

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="spName">Stored procedure name</param>
        /// <param name="Parameters">Parameters</param>
        /// <returns></returns>.
        public async void Delete(string spName, DynamicParameters Parameters = null)
        {

            await connection.QueryAsync(spName, commandType: CommandType.StoredProcedure, param: Parameters);

        }
        /// <summary>
        /// Get Single Record Result
        /// </summary>
        /// <param name="spName">Stored procedure name or Query text</param>
        /// <param name="commandType">if sp stored procedure else text</param>
        /// <param name="Parameters">Parameters</param>
        /// <returns></returns>
        public async Task<T> GetResult(string spName, DynamicParameters Parameters = null)
        {
            return ((IEnumerable<T>)await connection.QueryAsync<T>(spName, commandType: CommandType.StoredProcedure, param: Parameters)).FirstOrDefault();

        }
        /// <summary>
        /// Get multiple result sets i.e  multiple table data
        /// </summary>
        /// <param name="spName">Stored procedure name or Query text</param>
        /// <param name="commandType">if sp stored procedure else text</param>
        /// <param name="resNames">send alias names of table results with cama separated 
        /// Ex: "User,Client,Company"</param>
        /// <param name="Parameters">Parameters</param>
        /// <returns></returns>
        public async Task<Dictionary<string, object>> GetMultipleResult(string spName, string resNames, DynamicParameters Parameters = null)
        {

            var res = await connection.QueryMultipleAsync(spName, commandType: CommandType.StoredProcedure, param: Parameters);
            Dictionary<string, object> _res = new Dictionary<string, object>();
            foreach (string key in resNames.Trim(',').Split(','))
            {
                object obj = new object();
                obj = res.Read<object>();
                _res.Add(key, obj);
            }
            return _res;

        }

        /// <summary>
        /// Get Single value 
        /// </summary>
        /// <param name="spName">Stored procedure name or Query text</param>
        /// <param name="commandType">if sp stored procedure else text</param>
        /// <param name="Parameters">Parameters</param>
        /// <returns></returns>
        public async Task<T> GetScalarResult(string spName, DynamicParameters Parameters = null)
        {

            return (T)await connection.ExecuteScalarAsync<T>(spName, commandType: CommandType.StoredProcedure, param: Parameters);

        }
        /// <summary>
        /// Get multiple result sets i.e  multiple table data
        /// </summary>
        /// <param name="spName">Stored procedure name or Query text</param>
        /// <param name="commandType">if sp stored procedure else text</param>
        /// <param name="Parameters">Parameters</param>
        /// <returns>T where T Has Some class objects</returns>
        public async Task<T> GetReadMultipleResult(string spName, DynamicParameters Parameters = null)
        {
            var type = typeof(T);
            var pro = type.GetProperties();

            var res = await connection.QueryMultipleAsync(spName, commandType: CommandType.StoredProcedure, param: Parameters);
            Dictionary<string, object> _res = new Dictionary<string, object>();
            foreach (var p in pro)
            {
                object obj = new object();
                obj = res.Read<object>();
                _res.Add(p.Name, obj);
            }
            var jstring = JsonConvert.SerializeObject(_res);
            T Res = JsonConvert.DeserializeObject<T>(jstring);
            return Res;


        }
    }
}
