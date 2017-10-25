using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class bll_MenuInfo
    {
        DAL.dal_MenuInfo dal = new DAL.dal_MenuInfo();
        public bll_MenuInfo() { }

        public List<SqlModel.MenuInfo> GetList(string strWhere, string filedOrder)
        {
            return dal.GetList(strWhere, filedOrder);
        }

    }
}
