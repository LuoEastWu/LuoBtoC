using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlModel;

namespace BLL
{
    public class Bll_ProductType
    {
       
        DAL.Dal_ProductType dal = new DAL.Dal_ProductType();
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<ProductType> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex) 
        {
            if (string.IsNullOrEmpty(orderby)) 
            {
                orderby = "ID desc";
            }
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public List<SqlModel.ProductType> GetPage(string whereStr,string strOrderBy) 
        {
          return  dal.GetPage(whereStr, strOrderBy);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SqlModel.ProductType GetModel(long ID)
        {
            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SqlModel.ProductType> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
