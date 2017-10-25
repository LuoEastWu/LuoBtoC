using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class dal_MenuInfo
    {
        public dal_MenuInfo() { }

        public List<SqlModel.MenuInfo> GetList(string strWhere, string filedOrder)
        {
            List<SqlModel.MenuInfo> list = new List<SqlModel.MenuInfo>();
            SqlSugar.StartSqlSugar.GetInstance((db) =>
            {
                list = db.Queryable<SqlModel.MenuInfo>()
                       .Where(strWhere)
                       .OrderBy(filedOrder)
                       .ToList();
            });
            return list;
        }
    }
}
