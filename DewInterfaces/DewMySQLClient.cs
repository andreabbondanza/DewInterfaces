using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.Common;

namespace DewInterfaces.DewDatabase.MySQL
{
    /// <summary>
    /// MySQL Response object for INSERT\DELETE\UPDATE
    /// </summary>
    public interface IMySQLResponse
    {
        /// <summary>
        /// Get last inserted row
        /// </summary>
        /// <returns></returns>
        long GetLastInsertedId();
        /// <summary>
        /// Get affected rows
        /// </summary>
        /// <returns></returns>
        long GetRowsAffected();
    }
    /// <summary>
    /// MySQLClient dew interface
    /// </summary>
    public interface IMySQLClient
    {
        /// <summary>
        /// Perform a query and return result in a list of array
        /// </summary>
        /// <typeparam name="T">Result type object</typeparam>
        /// <param name="query">Query</param>
        /// <param name="values">List of binded values</param>
        /// <returns>List of array objects (rows)</returns>
        Task<List<object[]>> QueryArrayAsync(string query, List<DbParameter> values);
        /// <summary>
        /// Perform a query (good for SELECT) : 
        /// </summary>
        /// <typeparam name="T">Result type object</typeparam>
        /// <param name="query">Query</param>
        /// <param name="values">List of binded values</param>
        /// <returns>List of T objects (rows)</returns>
        Task<List<T>> QueryAsync<T>(string query, List<DbParameter> values) where T : class, new();
        /// <summary>
        /// Select directly in LINQ. NOTE: T name must be the Table Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="tablePrefix"></param>
        /// <returns></returns>
        Task<List<T>> Select<T>(Func<T, bool> predicate, string tablePrefix) where T : class, new();
        /// <summary>
        /// Select directly in LINQ. NOTE: T name must be the Table Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tablePrefix"></param>
        /// <returns></returns>
        Task<List<T>> Select<T>(string tablePrefix) where T : class, new();
        /// <summary>
        /// Perform a query (good for insert, update, delete)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        Task<IMySQLResponse> QueryAsync(string query, List<DbParameter> values);
        /// <summary>
        /// Commit a transaction
        /// </summary>
        Task CommitAsync();
        /// <summary>
        /// Rollback a transaction
        /// </summary>
        Task RoolbackAsync();
        /// <summary>
        /// Begin a transiction
        /// </summary>
        /// <returns></returns>
        Task<bool> BeginTransactionAsync(IsolationLevel isolationLevel);
        /// <summary>
        /// Close database connection
        /// </summary>
        void CloseConnection();
    }
}
