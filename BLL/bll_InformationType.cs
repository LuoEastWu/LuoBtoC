using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class bll_InformationType
    {
        public bll_InformationType() 
        {

        }
        DAL.dal_InformationType dal = new DAL.dal_InformationType();
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<SqlModel.InformationType> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            if (string.IsNullOrEmpty(orderby))
            {
                orderby = "ID desc";
            }
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public SqlModel.InformationType GetModel(long p)
        {
           return dal.GetModel(p);
        }

        public List<SqlModel.InformationType> GetList(string p)
        {
            return dal.GetList(p);
        }
    }
}
