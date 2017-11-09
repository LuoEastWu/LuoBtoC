using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class dal_ComDataList
    {
        public dal_ComDataList()
        { }
        public DataTable GetComList<T>(int top, string fields, string where, string fieldorder) where T : class, new()
        {
            try
            {
                DataTable table = new DataTable();
                Collections.StartSqlSugar.GetInstance((db) =>
                {
                    table= db.Queryable<T>()
                            .Where(where)
                            .OrderByIF(SqlSugar.SqlFunc.HasValue(fieldorder), fieldorder)
                            .Select(fields)
                            .Take(top)
                            .ToDataTable();
                });
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
