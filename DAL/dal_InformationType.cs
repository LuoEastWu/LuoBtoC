using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class dal_InformationType
    {
        public dal_InformationType()
        {

        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<SqlModel.InformationType> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            List<SqlModel.InformationType> informationList = new List<SqlModel.InformationType>();
            SqlSugar.StartSqlSugar.GetInstance((db) =>
            {
                informationList = db.Queryable<SqlModel.InformationType>()
                                    .Where(strWhere)
                                    .OrderBy(orderby)
                                    .Skip(startIndex).Take(endIndex)
                                    .ToList();
            });
            return informationList;

        }

        public SqlModel.InformationType GetModel(long p)
        {
            SqlModel.InformationType model = new SqlModel.InformationType();
            DataTable dt = new DataTable();
            SqlSugar.StartSqlSugar.GetInstance((db) =>
            {
                dt = db.Ado.UseStoredProcedure().GetDataTable("InformationType_GetModel", new SqlSugar.SugarParameter[]
                {
                    new SqlSugar.SugarParameter("@ID",p)
                });
            });


            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ID"] != null && dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(dt.Rows[0]["ID"].ToString());
                }
                if (dt.Rows[0]["TypeName"] != null && dt.Rows[0]["TypeName"].ToString() != "")
                {
                    model.TypeName = dt.Rows[0]["TypeName"].ToString();
                }
                if (dt.Rows[0]["Fid"] != null && dt.Rows[0]["Fid"].ToString() != "")
                {
                    model.Fid = int.Parse(dt.Rows[0]["Fid"].ToString());
                }
                if (dt.Rows[0]["Sort"] != null && dt.Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(dt.Rows[0]["Sort"].ToString());
                }
                if (dt.Rows[0]["Depth"] != null && dt.Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(dt.Rows[0]["Depth"].ToString());
                }
                if (dt.Rows[0]["Remark"] != null && dt.Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = dt.Rows[0]["Remark"].ToString();
                }
                if (dt.Rows[0]["CreateDate"] != null && dt.Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString());
                }
                if (dt.Rows[0]["IsDelete"] != null && dt.Rows[0]["IsDelete"].ToString() != "")
                {
                    if ((dt.Rows[0]["IsDelete"].ToString() == "1") || (dt.Rows[0]["IsDelete"].ToString().ToLower() == "true"))
                    {
                        model.IsDelete = true;
                    }
                    else
                    {
                        model.IsDelete = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public List<SqlModel.InformationType> GetList(string p)
        {
            List<SqlModel.InformationType> infList=new List<SqlModel.InformationType>();
            SqlSugar.StartSqlSugar.GetInstance((db) =>
            {
                infList = db.Queryable<SqlModel.InformationType>()
                          .Where(p)
                          .ToList();

            });
            return infList;
        }
    }
}
