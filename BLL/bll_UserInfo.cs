using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class bll_UserInfo
    {
        DAL.Dal_UserInfo dal = new DAL.Dal_UserInfo();
        public List<SqlModel.UserInfo> GetList(string strSql)
        {
            return dal.GetList(strSql);
        }
    }
}
