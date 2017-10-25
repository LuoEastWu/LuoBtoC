using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    
    public class Bll_Collection
    {
        DAL.Dal_Collection dal = new DAL.Dal_Collection();
        public List<SqlModel.Collection> getPape(string strWhere, string filedOrder) 
        {
            
           return dal.getBasePage(strWhere, filedOrder);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SqlModel.Collection GetModel(long ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(SqlModel.Collection model)
        {
            return dal.Update(model);
        }
    }
}
