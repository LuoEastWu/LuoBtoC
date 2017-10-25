using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class dal_Information
    {
        public List<SqlModel.Information> GetPage(string whereStr, string p)
        {
            List<SqlModel.Information> inflist = new List<SqlModel.Information>();
            SqlSugar.StartSqlSugar.GetInstance((db) =>
            {
                inflist = db.Queryable<SqlModel.Information>()
                          .Where(whereStr)
                          .OrderBy(p)
                          .ToList();
            });
            return inflist;
        }
    }
}
