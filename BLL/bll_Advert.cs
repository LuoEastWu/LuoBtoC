using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class bll_Advert
    {
        public bll_Advert() { }
        DAL.dal_Advert dal = new DAL.dal_Advert();
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<SqlModel.Advert> GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
    }
}
