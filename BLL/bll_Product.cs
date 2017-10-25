using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class bll_Product
    {
        public bll_Product() 
        {

        }
        DAL.dal_Product dal = new DAL.dal_Product();
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<SqlModel.Product> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SqlModel.Product GetModel(long ID)
        {

            return dal.GetModel(ID);
        }
        public List<SqlModel.Product> GetPage(string whereStr, string strOrderBy)
        {
            return dal.GetPage(whereStr, strOrderBy);
        }

        public List<SqlModel.Product> GetList(int p1, string p2, string p3)
        {
            return dal.GetList(p1, p2, p3);
        }
    }
}
