using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Dal_UserInfo
    {
        public List<SqlModel.UserInfo> GetList(string strSql)
        {
            List<SqlModel.UserInfo> userInfo = new List<SqlModel.UserInfo>();
            Collections.StartSqlSugar.GetInstance((db) =>
            {
                userInfo = db.Queryable<SqlModel.UserInfo>()
                           .Where(strSql)
                           .ToList();
            });
            return userInfo;
        }
    }
}
