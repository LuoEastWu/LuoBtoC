using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类:ComDataList
    /// </summary>
    public partial class ComDataList
    {
        public ComDataList()
        { }
        #region  Method

        /// <summary>
        /// 获得通用数据
        /// </summary>
        public DataTable GetComList<T>(int top, string fields, string where, string fieldorder) where T : class, new()
        {
            try
            {
                DataTable table = new DataTable();
                top = top == 0 ? int.MaxValue : top;
                Collections.StartSqlSugar.GetInstance((db) =>
                {
                    table = db.Queryable<T>()
                            .Where(where)
                            .Take(top)
                            .OrderByIF(SqlSugar.SqlFunc.HasValue(fieldorder), fieldorder)
                            .Select(fields)
                            .ToDataTable();
                });
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion  Method
    }
}
