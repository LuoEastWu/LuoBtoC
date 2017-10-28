using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class bll_Member
    {
        public bll_Member() { }

        DAL.dal_Member dal = new DAL.dal_Member();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<SqlModel.Member> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SqlModel.MemberModel.Member GetModel(long ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(SqlModel.MemberModel.Member model)
        {
            return dal.Add(model);
        }
    }
}
