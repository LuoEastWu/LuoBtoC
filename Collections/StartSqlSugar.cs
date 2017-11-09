using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Collections
{
    public class StartSqlSugar
    {
        public static string _connectionString { get; set; }
        /// <summary>
        /// SqlSugar静态执行方法
        /// </summary>
        public static void GetInstance(Action<SqlSugar.SqlSugarClient> func)
        {
            using (SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = _connectionString, DbType = DbType.SqlServer, IsAutoCloseConnection = true }))
            {
                func(db);
            }
        }
    }
}
