using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class bll_ComDataList
	{
        private readonly DAL.dal_ComDataList dal = new DAL.dal_ComDataList();
        public bll_ComDataList()
        { }
        #region  Method

        /// <summary>
        /// 获得通用数据
        /// </summary>
        public DataTable GetComList<T>(int top, string fields,  string where, string fieldorder) where T : class, new()
        {
            try
            {
                return dal.GetComList<T>(top, fields,  where, fieldorder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion  Method
    }
}
